﻿using System;
using System.Collections.Generic;

namespace NeoAPTB.ModelsViews;

public partial class EmpresasV
{
    public int IdPais { get; set; }

    public int IdEmpresa { get; set; }

    public string Empresa { get; set; } = null!;

    public bool Estado { get; set; }
}
