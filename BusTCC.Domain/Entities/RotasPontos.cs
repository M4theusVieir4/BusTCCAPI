using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Domain.Entities
{
    public class RotasPontos
    {
        public int IdRota { get; private set; }
        public int IdPonto { get; private set; }
        public int Ordem { get; private set; }

        
        public Rota Rota { get; set; }
        public Ponto Ponto { get; set; }


        protected RotasPontos() { }


        public RotasPontos(int idRota, int idPonto, int ordem,
            Rota rota, Ponto ponto)
        {           

            ValidateDomain(idRota, idPonto, ordem, rota, ponto);

        }

        public void Update(int idRota, int idPonto, int ordem,
            Rota rota, Ponto ponto)
        {
            ValidateDomain(idRota, idPonto, ordem, rota, ponto);
        }

        public void ValidateDomain(int idRota, int idPonto, int ordem,
            Rota rota, Ponto ponto)
        {
            DomainExceptionValidation.When(idRota < 0, "O id da Rota deve ser positivo");
            DomainExceptionValidation.When(idPonto < 0, "O id do Ponto deve ser positivo");

            IdRota = idRota;
            IdPonto = idPonto;
            Ordem = ordem;
            Rota = rota;
            Ponto = ponto;
        }
    }
}
