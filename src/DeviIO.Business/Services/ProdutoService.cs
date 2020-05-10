using DevIO.Business.Interface;
using DevIO.Business.Model;
using DevIO.Business.Model.Validation;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
