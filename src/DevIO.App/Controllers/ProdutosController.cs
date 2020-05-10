using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Interface;
using DevIO.Business.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository
            , IMapper mapper
            , IFornecedorRepository fornecedorRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null) return NotFound();
            return View(produtoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            ProdutoViewModel produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);
            if (!ModelState.IsValid) return View(produtoViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(produtoViewModel.ImageUpload, imgPrefixo))
                return View(produtoViewModel);

            produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImageUpload.FileName;
            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoatualizacao = await ObterProduto(id);
            produtoViewModel.Fornecedor = produtoatualizacao.Fornecedor;
            produtoViewModel.Imagem = produtoatualizacao.Imagem;
            if (!ModelState.IsValid) return View(produtoatualizacao);

            if (produtoViewModel.ImageUpload != null)
            {
                string img_prefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(produtoViewModel.ImageUpload, img_prefixo))
                {
                    return View(produtoViewModel);
                }

                produtoatualizacao.Imagem = img_prefixo + produtoViewModel.ImageUpload.FileName;
            }

            produtoatualizacao.Nome = produtoViewModel.Nome;
            produtoatualizacao.Descricao = produtoViewModel.Descricao;
            produtoatualizacao.Valor = produtoViewModel.Valor;
            produtoatualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoatualizacao));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null) return NotFound();

            await _produtoRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produtoViewModel;
        }

        private async Task<bool> UploadArquivo(IFormFile imagemUpload, string imgPrefixo)
        {
            if (imagemUpload.Length == 0) return false;

            var path = Path
                .Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + imagemUpload.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError("", "Já existe um arquivo com ese nome");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imagemUpload.CopyToAsync(stream);
            }

            return true;
        }
    }
}
