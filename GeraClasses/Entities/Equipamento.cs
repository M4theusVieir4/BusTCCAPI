using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Equipamento
{
    public int IdEquipamento { get; set; }

    public int IdDados { get; set; }

    public string NumeroSerie { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual ICollection<Catraca> Catracas { get; set; } = new List<Catraca>();

    public virtual ICollection<Comunicacao> Comunicacaos { get; set; } = new List<Comunicacao>();

    public virtual Comunicacao IdDadosNavigation { get; set; } = null!;
}
