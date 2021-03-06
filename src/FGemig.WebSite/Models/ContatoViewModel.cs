﻿using System.ComponentModel.DataAnnotations;

namespace FGemig.WebSite.Models
{
    public class ContatoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(250, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0}  obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O Campo {0}  obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0}  obrigatório")]
        [MaxLength(15, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Campo {0}  obrigatório")]
        [MaxLength(1000, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        public string Mensagem { get; set; }
    }
}