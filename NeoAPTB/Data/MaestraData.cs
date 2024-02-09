using NeoAPTB.ModelsViews;
using Microsoft.AspNetCore.Components;
using NeoAPTB.Interfaces;
using NeoAPTB.NeoModels;
using static System.Net.WebRequestMethods;

namespace NeoAPTB.Data
{
    public class MaestraData:IMaestraData
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Maestra/";
        private string url = "";

        public MaestraData(IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;
        }
        public async Task<List<Pai>> GetPaises()
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<List<Pai>>($"{BaseUrl}GetPaises");
                return result ?? new List<Pai>();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw;
            }
        }
        public async Task<List<EmpresasV>> GetEmpresas(int IdPais)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<EmpresasV>>($"{BaseUrl}GetEmpresas/{IdPais}");
            return result ?? new List<EmpresasV>();
        }

        public async Task<List<CentrosV>> GetCentros(int IdEmpresa)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<CentrosV>>($"{BaseUrl}GetCentros/{IdEmpresa}");
            return result ?? new List<CentrosV>();
        }

        public async Task<List<DivisionesV>> GetDivisiones(int IdCentro)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<DivisionesV>>($"{BaseUrl}GetDivisiones/{IdCentro}");
            return result ?? new List<DivisionesV>();
        }

        public async Task<int> GetMaestraPorLinea(int idLinea)
        {
            var client = _clientFactory.CreateClient();
            url = $"http://neo.paveca.com.ve/apineomaster/api/maestra/GetMaestraPorLinea/{idLinea}";
            return await client.GetFromJsonAsync<int>(url);
        }
        public async Task<List<LineaV>> GetLineas(int IdDivision)
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<List<LineaV>>($"{BaseUrl}GetLineas/{IdDivision}");
            return result ?? new List<LineaV>();
        }

        public Task<List<Centro>> GetCentrosxEmpresa(string centro)
        {
            throw new NotImplementedException();
        }
    }
}
