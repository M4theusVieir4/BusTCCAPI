using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Entities
{
    public class OnibusRota
    {
        public int IdOnibus { get; private set; }

        public int IdRota { get; private set; }

        public Onibus Onibus { get; set; } = null!;
        public Rota Rota { get; set; }



        protected OnibusRota() { }
        public OnibusRota(int idOnibus, int idRota, Onibus onibus,
            Rota rota)
        {
            DomainExceptionValidation.When(idOnibus < 0, "O id do Ônibus deve ser positivo");
            IdOnibus = idOnibus;

            ValidateDomain(idRota, onibus, rota);

        }

        public void Update(int idRota, Onibus onibus,
            Rota rota)
        {
            ValidateDomain(idRota, onibus, rota);
        }

        public void ValidateDomain(int idRota, Onibus onibus,
            Rota rota)
        {
            DomainExceptionValidation.When(idRota < 0, "O id da Rota deve ser positivo");
            IdRota = idRota;
            Onibus = onibus;
            Rota = rota;            
        }
    }
}
