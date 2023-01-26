using System;
using System.Collections.Generic;

namespace NeoAPT.ModelsAPT;

public partial class TipoPer
{
    public int IdTipoPer { get; set; }

    public string? TpDesc { get; set; }

    public bool? TpEsta { get; set; }

    public virtual ICollection<Personal> Personals { get; } = new List<Personal>();
}
