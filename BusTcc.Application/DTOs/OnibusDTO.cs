using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class OnibusDTO
    {
        [Required(ErrorMessage = "O ID do ônibus é obrigatório.")]
        public int IdOnibus { get; set; }

        [Required(ErrorMessage = "O ID dos dados é obrigatório.")]
        public int IdDados { get; set; }

        [Required(ErrorMessage = "O ID da rota é obrigatório.")]
        public int IdRotas { get; set; }

        [Required(ErrorMessage = "O modelo do ônibus é obrigatório.")]
        [StringLength(100, ErrorMessage = "O modelo do ônibus deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; } = null!;

        [Required(ErrorMessage = "A placa do ônibus é obrigatória.")]
        [StringLength(10, ErrorMessage = "A placa do ônibus deve ter no máximo 10 caracteres.")]
        public string Placa { get; set; } = null!;

        [Required(ErrorMessage = "O ano de fabricação é obrigatório.")]
        [Range(1900, 2100, ErrorMessage = "O ano de fabricação deve ser entre 1900 e 2100.")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "A taxa do ônibus é obrigatória.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "A taxa do ônibus deve ser um valor positivo.")]
        public decimal TaxaOnibus { get; set; }

        [Required(ErrorMessage = "A latitude é obrigatória.")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória.")]
        public decimal Longitude { get; set; }
    }
}
