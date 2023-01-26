using System;
using System.Collections.Generic;

namespace NeoAPT.ModelsAPT;

public partial class TipSuple
{
    public int IdTipSuple { get; set; }

    public string? Tscodigo { get; set; }

    public string? Tsdescri { get; set; }

    public bool? Tsestado { get; set; }

    public virtual ICollection<Resuman> Resumen { get; } = new List<Resuman>();
}
