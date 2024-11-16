using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int IdUsuario { get; set; }                

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(60, ErrorMessage = "O nome completo deve ter no máximo 60 caracteres.")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de celular é obrigatório.")]
        [Range(100000000, 999999999, ErrorMessage = "O número de celular deve ter entre 9 e 10 dígitos.")] // Ajuste conforme o formato desejado
        public int NumeroCelular { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [StringLength(30, ErrorMessage = "O e-mail deve ter no máximo 30 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ter um formato válido.")]
        public string Email { get; set; } = string.Empty;
    }
}
