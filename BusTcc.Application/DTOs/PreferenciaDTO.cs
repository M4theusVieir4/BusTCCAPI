using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class PreferenciaDTO
    {
        [Required(ErrorMessage = "O ID da preferência é obrigatório.")]
        public int IdPreferencia { get; set; }

        [Required(ErrorMessage = "A preferência de deficiência é obrigatória.")]
        public bool Deficiencia { get; set; }

        [Required(ErrorMessage = "A preferência de notificação é obrigatória.")]
        public bool Notificacao { get; set; }
    }
}
