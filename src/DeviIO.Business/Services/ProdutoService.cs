using DevIO.Business.Interface;
using DevIO.Business.Model;
using DevIO.Business.Model.Validation;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository
                            , INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;

            await _produtoRepository.Atualizar(produto);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
    }
}
