using System.Net.Http.Json;
using NeoAPTB.DTOs.Bono;
using NeoAPTB.Interfaces.Bono;

namespace NeoAPTB.Services.Bono;

public class BonoApiService : IBonoApiService
{
    private readonly HttpClient _httpClient;

    public BonoApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<InsertarResumenResponseDto?> InsertarResumenAsync(CrearResumenDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Bono/InsertarResumen", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al insertar resumen: {error}");
        }

        return await response.Content.ReadFromJsonAsync<InsertarResumenResponseDto>();
    }

    public async Task<bool> ActualizarEstadoEspecialAsync(int idEspecial, ActualizarEstadoEspecialDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Bono/especial/{idEspecial}/estado", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al actualizar estado especial: {error}");
        }

        return true;
    }

    public async Task<HistorialEspecialResponseDto?> ObtenerHistorialEspecialAsync(int idEspecial)
    {
        var response = await _httpClient.GetAsync($"api/Bono/especial/{idEspecial}/historial");

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al obtener historial: {error}");
        }

        return await response.Content.ReadFromJsonAsync<HistorialEspecialResponseDto>();
    }

    public async Task<List<EspecialPendienteDto>> ObtenerEspecialesPendientesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponseDto<List<EspecialPendienteDto>>>("api/Bono/especiales-pendientes");
        return response?.Data ?? new List<EspecialPendienteDto>();
    }

    public async Task<List<EspecialHistoricoDto>> ObtenerHistoricoEspecialesAsync()
    {
        var response = await _httpClient
            .GetFromJsonAsync<ApiResponseDto<List<EspecialHistoricoDto>>>(
                "api/Bono/especiales-historico");

        return response?.Data ?? new List<EspecialHistoricoDto>();
    }
}