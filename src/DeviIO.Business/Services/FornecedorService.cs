﻿using DevIO.Business.Interface;
using DevIO.Business.Model;
using DevIO.Business.Model.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository
                                , IEnderecoRepository enderecoRepository
                                , INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            //validar o estado da entidade
            var validator = new FornecedorValidation();
            if (!ExecutarValidacao(validator, fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco))
                return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento)
                .Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor))
                return;

            if (_fornecedorRepository
                .Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id)
                .Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco))
                return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepository
                .ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados");
                return;
            }

            await _fornecedorRepository.Remover(id);            
        }
    }
}

