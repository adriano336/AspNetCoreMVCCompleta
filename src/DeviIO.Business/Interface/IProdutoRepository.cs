using DevIO.Business.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interface
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);

    }
}
