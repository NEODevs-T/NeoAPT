namespace NeoAPTB.DTOs.Bono;

public class EspecialHistoricoDto
{
    public int IdEspecial { get; set; }
    public int IdResumen { get; set; }
    public int IdEstado { get; set; }

    public string Motivo { get; set; } = string.Empty;
    public DateTime? FechaSolicitud { get; set; }

    public int IdPersonal { get; set; }
    public string PeFicha { get; set; } = string.Empty;
    public string NombreTrabajador { get; set; } = string.Empty;

    public DateTime Rfecha { get; set; }
    public DateTime? RfechaReal { get; set; }
    public int Rturno { get; set; }
    public string Rgrupo { get; set; } = string.Empty;
    public int RhoraTrab { get; set; }
    public string RuserVali { get; set; } = string.Empty;
    public bool RisMarcaje { get; set; }
}