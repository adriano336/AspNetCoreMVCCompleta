using DevIO.Business.Model;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interface
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedor(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
    }
}
