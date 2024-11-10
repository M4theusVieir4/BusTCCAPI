using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class ComunicacaoDTO
    {
        [Required(ErrorMessage = "O ID dos dados é obrigatório.")]
        public int IdDados { get; set; }

        [Required(ErrorMessage = "O ID do equipamento é obrigatório.")]
        public int IdEquipamento { get; set; }

        [Required(ErrorMessage = "O ID da catraca é obrigatório.")]
        public int IdCatraca { get; set; }

        [Required(ErrorMessage = "A data da comunicação é obrigatória.")]
        public DateOnly Data { get; set; }
    }
}
