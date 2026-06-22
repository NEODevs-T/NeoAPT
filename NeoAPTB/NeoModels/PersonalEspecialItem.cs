namespace NeoAPTB.Models;

public class PersonalEspecialItem
{
    public int? IdPersonal { get; set; }
    public string Ficha { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Grupo { get; set; } = string.Empty;
    public string NombreDpto { get; set; } = string.Empty;
    public int CodigoDpto { get; set; }
    public bool ExisteEnSistema { get; set; }
}