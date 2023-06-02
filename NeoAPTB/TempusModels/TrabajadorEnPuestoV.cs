using System;
using System.Collections.Generic;

namespace NeoAPTB.TempusModels;

public partial class TrabajadorEnPuestoV
{
    public string CodigoTrabajador { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public string? NombreTrab { get; set; }

    public int IdTipoTrabajador { get; set; }

    public string? DescTipoTrab { get; set; }

    public string CodigoDpto { get; set; } = null!;

    public string? NombreDpto { get; set; }

    public string? Grupo { get; set; }

    public bool? EnPuesto { get; set; }

    public int IdTransaccion { get; set; }

    public string? Descripcion { get; set; }

    public string? DesPuesto { get; set; }

    public string CodigoCia { get; set; } = null!;

    public string? NombreCia { get; set; }

    public string? FechaHora { get; set; }
}
