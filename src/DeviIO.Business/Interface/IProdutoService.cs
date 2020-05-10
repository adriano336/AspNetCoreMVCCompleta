using DevIO.Business.Model;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interface
{
    public interface IProdutoService
    {
        Task Adicionar(Produto fornecedor);
        Task Atualizar(Produto fornecedor);
        Task Remover(Guid id);        
    }
}
