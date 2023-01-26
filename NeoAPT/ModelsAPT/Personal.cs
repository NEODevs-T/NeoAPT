using System;
using System.Collections.Generic;

namespace NeoAPT.ModelsAPT;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public int? IdTipoPer { get; set; }

    public string? PeNombre { get; set; }

    public string? PeApellido { get; set; }

    public string? PeFicha { get; set; }

    public bool? PeEstado { get; set; }

    public int? IdGrupo { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }

    public virtual TipoPer? IdTipoPerNavigation { get; set; }

    public virtual ICollection<Resuman> Resumen { get; } = new List<Resuman>();
}
