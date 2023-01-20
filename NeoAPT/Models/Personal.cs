using System;
using System.Collections.Generic;

namespace NeoAPT.Models;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string? PeNombre { get; set; }

    public string? PeApellido { get; set; }

    public string? PeFicha { get; set; }

    public bool? PeEstado { get; set; }

    public string? PeGrupo { get; set; }

    public virtual ICollection<Resuman> Resumen { get; } = new List<Resuman>();
}
