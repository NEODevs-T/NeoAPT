namespace NeoAPTB.DTOs.Bono;

public class InsertarResumenResponseDto
{
    public string Message { get; set; } = string.Empty;
    public InsertarResumenDataDto Data { get; set; } = new();
}

public class InsertarResumenDataDto
{
    public int IdResumen { get; set; }
    public bool EsEspecial { get; set; }
    public int? IdEspecial { get; set; }
    public int? EstadoInicial { get; set; }
}