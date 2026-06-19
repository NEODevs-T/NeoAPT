namespace NeoAPTB.DTOs.Bono;

public class HistorialEspecialResponseDto
{
    public string Message { get; set; } = string.Empty;
    public int IdEspecial { get; set; }
    public int Total { get; set; }
    public List<HistorialEspecialItemDto> Data { get; set; } = new();
}

public class HistorialEspecialItemDto
{
    public int IdAprobacion { get; set; }
    public int IdEspecial { get; set; }
    public int Nivel { get; set; }
    public string UsuarioAprobador { get; set; } = string.Empty;
    public string Accion { get; set; } = string.Empty;
    public string? Comentario { get; set; }
    public DateTime FechaAccion { get; set; }
}