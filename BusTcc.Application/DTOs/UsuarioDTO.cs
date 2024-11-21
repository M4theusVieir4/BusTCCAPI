using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class UsuarioDTO
    {        
        public int IdUsuario { get; set; }                

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(60, ErrorMessage = "O nome completo deve ter no máximo 60 caracteres.")]
        public string NomeCompleto { get; set; } = string.Empty;        

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [StringLength(30, ErrorMessage = "O e-mail deve ter no máximo 30 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ter um formato válido.")]
        public string Email { get; set; } = string.Empty;

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public PreferenciaDTO? Preferencia { get; set; }
    }
}
