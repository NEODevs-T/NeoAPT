using NeoAPTB.DTOs;
using NeoAPTB.Interfaces;

using NeoAPTB.ModelsDOCIng;

namespace NeoAPTB.Data
{
    public class GlobalData : IGlobalData
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://neo.paveca.com.ve/apineomaster/api/Global/";
        private string url = "";
        public GlobalData( IHttpClientFactory clientFactory)
        {
            
            _clientFactory = clientFactory;
        }
        public async Task<RotaCalidum> GetRotacion(int IdPais){
            try
            {
                var client = _clientFactory.CreateClient();
                var result = await client.GetFromJsonAsync<RotaCalidum>($"{BaseUrl}GetRotacion/{IdPais}");
                return result ?? new RotaCalidum();
            }
            catch
            {
                return new RotaCalidum();
            }
        }

        public async Task<PersonalSPIDTO> GetPersonalPorFicha(string ficha){
            try
            {
                var client = _clientFactory.CreateClient();
                PersonalSPIDTO? result = await client.GetFromJsonAsync<PersonalSPIDTO>($"{BaseUrl}GetPersonalPorFicha/{ficha}");
                return result ?? new PersonalSPIDTO();
            }
            catch
            {
                return new PersonalSPIDTO();
            }
        }

        public DateTime ObtenerFechaBPCS(int idEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}