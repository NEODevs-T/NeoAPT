using System;
using System.Collections.Generic;

namespace NeoAPTB.NeoModels;

public partial class Linea
{
    public int IdLinea { get; set; }

    public string Lnom { get; set; } = null!;

    public string? Ldetalle { get; set; }

    public bool Lestado { get; set; }

    public string? LcenCos { get; set; }

    public string? Lofic { get; set; }

    public virtual Master? Master { get; set; }

    public virtual ICollection<Monto> Montos { get; set; } = new List<Monto>();
}
