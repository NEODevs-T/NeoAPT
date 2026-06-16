namespace NeoAPTB.ModelsMyIntelli;

public partial class TrabajadorEnPuestoVMi
{
    public string? Cedula { get; set; }
    public string? CodigoTrabajador { get; set; }
    public string? NombreTrabajador { get; set; }
    public string? IdTipoTrabajador { get; set; }
    public string? FechaBpcs { get; set; }

    public DateTime? FechaEntrada { get; set; }
    public DateTime? FechaSalida { get; set; }

    public string? HoraEntrada { get; set; }
    public string? HoraSalida { get; set; }

    public int CodigoDpto { get; set; }
    public string? NombreDpto { get; set; }
    public string? Grupo { get; set; }

    public string? CodigoPermiso { get; set; }
    public string? Permiso { get; set; }

    public double? HorasDelPermiso { get; set; }   // <- float en SQL => double en C#
    public int? DiasDelPermiso { get; set; }       // <- int en SQL => int en C#
}
