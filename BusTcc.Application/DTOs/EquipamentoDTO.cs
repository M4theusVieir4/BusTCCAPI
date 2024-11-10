using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class EquipamentoDTO
    {
        [Required(ErrorMessage = "O ID do equipamento é obrigatório.")]
        public int IdEquipamento { get; set; }

        [Required(ErrorMessage = "O ID dos dados é obrigatório.")]
        public int IdDados { get; set; }

        [Required(ErrorMessage = "O número de série é obrigatório.")]
        [StringLength(40, ErrorMessage = "O número de série deve possuir no máximo 40 caracteres.")]
        public string NumeroSerie { get; set; } = null!;

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        [StringLength(20, ErrorMessage = "O modelo deve possuir no máximo 20 caracteres.")]
        public string Modelo { get; set; } = null!;

        [Required(ErrorMessage = "A latitude é obrigatória.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória.")]
        public decimal Longitude { get; set; }
    }
}
