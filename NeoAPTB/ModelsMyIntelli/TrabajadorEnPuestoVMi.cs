using System;
using System.Collections.Generic;

namespace NeoAPTB.ModelsMyIntelli;

public partial class TrabajadorEnPuestoVMi
{
    public string CodigoTrabajador { get; set; } = null!;

    public string? FechaHora { get; set; }

    public string FechaHoraCompleta { get; set; } = null!;

    public string FechaHoraSubida { get; set; } = null!;

    public string? NombreTrab { get; set; }

    public string CodigoDpto { get; set; }

    public string? NombreDpto { get; set; }

    public int EnPuesto { get; set; }

    public int IdTransaccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int CodigoCia { get; set; }
}
