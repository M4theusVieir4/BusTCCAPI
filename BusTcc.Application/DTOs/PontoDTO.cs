using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class PontoDTO
    {
        [Required(ErrorMessage = "O ID do ponto é obrigatório.")]
        public int IdPonto { get; set; }

        [Required(ErrorMessage = "O ID da rota é obrigatório.")]
        public int IdRotas { get; set; }

        [Required(ErrorMessage = "A rua ou avenida é obrigatória.")]
        [StringLength(100, ErrorMessage = "A rua ou avenida deve ter no máximo 100 caracteres.")]
        public string RuaAvenida { get; set; } = null!;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string Estado { get; set; } = null!;
    }
}
