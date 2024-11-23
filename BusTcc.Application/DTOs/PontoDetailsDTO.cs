using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Application.DTOs
{
    public class PontoDetailsDTO
    {
        public int IdPonto { get; set; }
        public string RuaAvenida { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Estado { get; set; } = null!;        
        public List<RotaDTO> Rotas { get; set; } = new List<RotaDTO>();        
        public List<OnibusDTO> Onibus { get; set; } = new List<OnibusDTO>();
    }
}
