using NeoAPTB.NeoModels;
using static System.Net.WebRequestMethods;

namespace NeoAPTB.Data
{
    public class APIService:APIInterface
    {
        private readonly HttpClient _http;
        public List<Centro> centro { get; set; } = new List<Centro>();
       
        public List<Division> divisions { get; set; } = new List<Division>();
        public List<Linea> lineas { get; set; } = new List<Linea>();

   
        public async Task GetCentros(string cent)

        {
            var result = await _http.GetFromJsonAsync<List<Centro>>($"http://neo.paveca.com.ve/ReunionApi/Lineas/{cent}");
            // var result = await _http.GetFromJsonAsync<List<Centro>>($"http://localhost:5258/Lineas/{cent}");
            if (result != null)
                centro = result;

        }

        public async Task GetCentrosxEmpresa(string cent)
        {
            var result = await _http.GetFromJsonAsync<List<Centro>>($"http://neo.paveca.com.ve/ReunionApi/Empresas/Centros/{cent}");
            //var result = await _http.GetFromJsonAsync<List<Centro>>($"http://localhost:5258/Empresas/Centros/{cent}");
            if (result != null)
                centro = result;

        }
        public async Task GetDivision(string centro, string div)
        {
            var result = await _http.GetFromJsonAsync<List<Division>>($"http://neo.paveca.com.ve/ReunionApi/Lineas/Division/{centro}/{div}");
            //var result = await _http.GetFromJsonAsync<List<Division>>($"http://localhost:5258/Lineas/Division/{centro}/{div}");
            if (result != null)
                divisions = result;

        }
        public async Task GetLineas(int div)
        {
            var result = await _http.GetFromJsonAsync<List<Linea>>($"http://neo.paveca.com.ve/ReunionApi/Empresas/Lineas/{div}");
            //var result = await _http.GetFromJsonAsync<List<Linea>>($"http://localhost:5258/Empresas/Lineas/{div}");
            if (result != null)
                lineas = result;

        }
    }
}
