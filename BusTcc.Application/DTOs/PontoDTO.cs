using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class PontoDTO
    {              

        [Required(ErrorMessage = "A rua ou avenida é obrigatória.")]
        [StringLength(200, ErrorMessage = "A rua ou avenida deve ter no máximo 200 caracteres.")]
        public string RuaAvenida { get; set; } = null!;
                
        [StringLength(30, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
        public string? Bairro { get; set; }
                
        [StringLength(30, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string? Estado { get; set; }

        [NotMapped]
        public int? Ordem { get; set; }
        

    }
}
