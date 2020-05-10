using System;

namespace DevIO.Business.Model
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}