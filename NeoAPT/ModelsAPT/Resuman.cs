using System;
using System.Collections.Generic;

namespace NeoAPT.ModelsAPT;

public partial class Resuman
{
    public int IdResumen { get; set; }

    public int? IdTipSuple { get; set; }

    public DateTime? Rfecha { get; set; }

    public string? Rturno { get; set; }

    public string? Rgrupo { get; set; }

    public int IdPuesto { get; set; }

    public int IdPersonal { get; set; }

    public string? Rsuplido { get; set; }

    public virtual Personal IdPersonalNavigation { get; set; } = null!;

    public virtual Puesto IdPuestoNavigation { get; set; } = null!;

    public virtual TipSuple? IdTipSupleNavigation { get; set; }
}
