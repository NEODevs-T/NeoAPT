﻿using System;
using System.Collections.Generic;

namespace NeoAPB.NeoModels;

public partial class Division
{
    public int IdDivision { get; set; }

    public int? IdCentro { get; set; }

    public string? Dnombre { get; set; }

    public string? Ddetalle { get; set; }

    public bool? Destado { get; set; }

    public virtual Centro? IdCentroNavigation { get; set; }

    public virtual ICollection<Linea> Lineas { get; set; } = new List<Linea>();
}
