using NeoAPTB.DTOs.Bono;

namespace NeoAPTB.Interfaces.Bono;

public interface IBonoApiService
{
    Task<InsertarResumenResponseDto?> InsertarResumenAsync(CrearResumenDto dto);
    Task<bool> ActualizarEstadoEspecialAsync(int idEspecial, ActualizarEstadoEspecialDto dto);
    Task<HistorialEspecialResponseDto?> ObtenerHistorialEspecialAsync(int idEspecial);
    Task<List<EspecialPendienteDto>> ObtenerEspecialesPendientesAsync();
    Task<List<EspecialHistoricoDto>> ObtenerHistoricoEspecialesAsync();
}