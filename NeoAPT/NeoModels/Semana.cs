using System;
using System.Collections.Generic;

namespace NeoAPT.NeoModels;

public partial class Semana
{
    public int IdSemana { get; set; }

    public DateTime SfecIni { get; set; }

    public DateTime SfecFin { get; set; }

    public string Sdescri { get; set; } = null!;

    public virtual ICollection<Resuman> Resumen { get; set; } = new List<Resuman>();
}
