namespace NeoAPTB.DTOs.Bono;

public class ApiResponseDto<T>
{
    public string Message { get; set; } = string.Empty;
    public int? Total { get; set; }
    public T? Data { get; set; }
}