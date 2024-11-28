using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Comunicacao
{
    public int IdDados { get; private set; }

    public int IdEquipamento { get; private set; }   

    public DateTime Data { get; private set; }
    public decimal Latitude { get; private set; }

    public decimal Longitude { get; private set; }

    public virtual Equipamento Equipamento { get; set; }        

    protected Comunicacao() { }
    public Comunicacao(int idDados, int idEquipamento, int idCatraca, DateTime data, Equipamento equipamento,
        Catraca idCatracaNavigation, decimal latitude, decimal longitude)
    {
        DomainExceptionValidation.When(idDados < 0, "O Id da comunicação deve ser positivo");
        IdDados = idDados;
        ValidateDomain(idEquipamento, data, equipamento, latitude, longitude
        );
    }

    public void Update(int idEquipamento, DateTime data, Equipamento equipamento, decimal latitude, decimal longitude
         )
    {
        ValidateDomain(idEquipamento, data, equipamento, latitude, longitude
         );
    }

    public void ValidateDomain(int idEquipamento, DateTime data, Equipamento equipamento, decimal latitude, decimal longitude
       )
    {
        DomainExceptionValidation.When(idEquipamento < 0, "O Id do equipamento deve ser positivo");       

        IdEquipamento = idEquipamento;        
        Data = data;
        Equipamento = equipamento;
        Latitude = latitude;
        Longitude = longitude;
        
    }
}
