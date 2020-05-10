using DevIO.Business.Interface;
using DevIO.Business.Model;
using DevIO.Business.Model.Validation;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task Adicionar(Fornecedor fornecedor)
        {
            //validar o estado da entidade
            var validator = new FornecedorValidation();
            if (!ExecutarValidacao(validator, fornecedor)
                && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco))
                return;
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor))
                return;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco))
                return;
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
