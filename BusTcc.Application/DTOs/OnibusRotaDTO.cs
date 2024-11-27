using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class OnibusRotaDTO
    {
        [Required(ErrorMessage = "O ID do Ônibus é obrigatório.")]
        public int IdOnibus { get; set; }

        [Required(ErrorMessage = "O ID da Rota é obrigatório.")]
        public int IdRotas { get; set; }

        public RotaDTO Rota { get; set; } = null!;


    }
}
