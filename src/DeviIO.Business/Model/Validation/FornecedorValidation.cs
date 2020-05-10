using DevIO.Business.Model.Validation.Documentos;
using FluentValidation;

namespace DevIO.Business.Model.Validation
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ser entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(f => f.Documento.Length)
                .Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo documento precisa ter {ComparisonValue} carcteres e foi fornecido {PropertyValue}.");

                RuleFor(f => CpfValidacao.IsCpf(f.Documento)).Equal(true)
                .WithMessage("O documento fornecedor é inválido");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length)
                .Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage("O campo documento precisa ter {ComparisonValue} carcteres e foi fornecido {PropertyValue}.");

                RuleFor(f => CnpjValidacao.IsCnpj(f.Documento)).Equal(true)
                .WithMessage("O documento fornecedor é inválido");
            });
        }
    }
}
