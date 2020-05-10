using DevIO.Business.Model;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interface
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
