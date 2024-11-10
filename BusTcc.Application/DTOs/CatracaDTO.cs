using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class CatracaDTO
    {
        [Required(ErrorMessage = "O ID da catraca é obrigatório.")]
        public int IdCatraca { get; set; }

        public int? IdEquipamento { get; set; }

        [StringLength(255, ErrorMessage = "O local deve ter no máximo 255 caracteres.")]
        public string? Local { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade de entrada deve ser um número positivo.")]
        public int? QuantidadeEntrada { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade de saída deve ser um número positivo.")]
        public int? QuantidadeSaida { get; set; }
    }
}
