using System;
using System.Collections.Generic;

namespace NeoAPTB.NeoModels;

/// <summary>
/// Nivel de los puestos de trabako
/// </summary>
public partial class NivePue
{
    public int IdNivePues { get; set; }

    /// <summary>
    /// descripcion de los puestos de trabajo
    /// </summary>
    public string Npdescrip { get; set; } = null!;

    /// <summary>
    /// 1 activo , 0 inactivo
    /// </summary>
    public bool Npestado { get; set; }

    /// <summary>
    /// fecha de creacion del registro
    /// </summary>
    public DateTime Npfcreaci { get; set; }

    public virtual ICollection<PuesTrab> PuesTrabs { get; set; } = new List<PuesTrab>();
}
