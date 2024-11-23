using BusTCC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BusTCC.Domain.Entities;

public partial class Comunicacao
{
    public int IdDados { get; private set; }

    public int IdEquipamento { get; private set; }   

    public DateOnly Data { get; private set; }

    public virtual Equipamento Equipamento { get; set; }        

    protected Comunicacao() { }
    public Comunicacao(int idDados, int idEquipamento, int idCatraca, DateOnly data, Equipamento equipamento,
        Catraca idCatracaNavigation)
    {
        DomainExceptionValidation.When(idDados < 0, "O Id da comunicação deve ser positivo");
        IdDados = idDados;
        ValidateDomain(idEquipamento, data, equipamento
        );
    }

    public void Update(int idEquipamento, DateOnly data, Equipamento equipamento
         )
    {
        ValidateDomain(idEquipamento, data, equipamento
         );
    }

    public void ValidateDomain(int idEquipamento, DateOnly data, Equipamento equipamento
       )
    {
        DomainExceptionValidation.When(idEquipamento < 0, "O Id do equipamento deve ser positivo");       

        IdEquipamento = idEquipamento;        
        Data = data;
        Equipamento = equipamento;                
        
    }
}
