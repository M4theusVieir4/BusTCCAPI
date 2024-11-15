﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class RotaDTO
    {
        [Required(ErrorMessage = "O ID da Rota é obrigatório.")]
        public int IdRotas { get; set; }

        [Required(ErrorMessage = "O ID do Ponto é obrigatório.")]
        public int IdPonto { get; set; }

        [Required(ErrorMessage = "O ID do Ônibus é obrigatório.")]
        public int IdOnibus { get; set; }
    }
}
