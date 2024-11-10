using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Onibu
{
    public int IdOnibus { get; set; }

    public int IdDados { get; set; }

    public int IdRotas { get; set; }

    public string Modelo { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public int AnoFabricacao { get; set; }

    public decimal TaxaOnibus { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual Comunicacao IdDadosNavigation { get; set; } = null!;

    public virtual Rota IdRotasNavigation { get; set; } = null!;

    public virtual ICollection<Rota> Rota { get; set; } = new List<Rota>();
}
