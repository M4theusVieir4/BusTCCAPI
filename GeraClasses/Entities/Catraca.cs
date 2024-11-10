using System;
using System.Collections.Generic;

namespace BusTCC.Domain.Entities;

public partial class Catraca
{
    public int IdCatraca { get; set; }

    public int? IdEquipamento { get; set; }

    public string? Local { get; set; }

    public int? QuantidadeEntrada { get; set; }

    public int? QuantidadeSaida { get; set; }

    public virtual ICollection<Comunicacao> Comunicacaos { get; set; } = new List<Comunicacao>();

    public virtual Equipamento? IdEquipamentoNavigation { get; set; }
}
