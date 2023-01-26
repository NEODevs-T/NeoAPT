using System;
using System.Collections.Generic;

namespace NeoAPT.ModelsAPT;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string? Ggescrp { get; set; }

    public bool? Gesta { get; set; }

    public virtual ICollection<Personal> Personals { get; } = new List<Personal>();
}
