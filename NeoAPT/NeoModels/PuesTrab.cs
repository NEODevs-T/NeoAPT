using System;
using System.Collections.Generic;

namespace NeoAPT.NeoModels;

public partial class PuesTrab
{
    public int IdPuesTrab { get; set; }

    public string Ptnombre { get; set; } = null!;

    public string? Ptdescri { get; set; }

    public bool? Ptesta { get; set; }

    public int? IdCentro { get; set; }

    public virtual ICollection<Monto> Montos { get; } = new List<Monto>();
}
