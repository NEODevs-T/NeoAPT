using System;
using System.Collections.Generic;

namespace NeoAPT.ModelsAPT;

public partial class Plantum
{
    public int IdPlanta { get; set; }

    public string? PlCodigo { get; set; }

    public string? PlDescri { get; set; }

    public bool? PlEstado { get; set; }

    public int IdEmpresa { get; set; }

    public virtual ICollection<AreaTra> AreaTras { get; } = new List<AreaTra>();

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
