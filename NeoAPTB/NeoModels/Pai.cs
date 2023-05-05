using System;
using System.Collections.Generic;

namespace NeoAPTB.NeoModels;

public partial class Pai
{
    public int IdPais { get; set; }

    public string Pnombre { get; set; } = null!;

    public bool Pestado { get; set; }

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
