using System;
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

        [Required(ErrorMessage = "O nome da rota é obrigatório.")]
        public string Nome_Rota { get; set; }

        public ICollection<RotasPontosDTO>? RotasPontos { get; set; } = new List<RotasPontosDTO>();
    }
}
