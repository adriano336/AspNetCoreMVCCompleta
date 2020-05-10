﻿using DevIO.App.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Imagem do produto")]
        public IFormFile ImageUpload { get; set; }
        public string Imagem { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Valor { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}