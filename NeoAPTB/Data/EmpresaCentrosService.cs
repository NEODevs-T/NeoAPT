using NeoAPTB.NeoModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using NeoAPTB.Interfaces;

namespace NeoAPTB.Data
{
    public class EmpresaCentrosService : IEmpresasCentros
    {
        private readonly HttpClient _http;
        private readonly DbNeoContext _neocontext;
        private readonly NavigationManager _navigationManager;


        public EmpresaCentrosService(HttpClient http, NavigationManager navigationManager, DbNeoContext _NeoContext)
        {
            _http = http;
            _navigationManager = navigationManager;
            _neocontext = _NeoContext;
        }

        public List<Centro> centros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Division> divisions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Linea> lineas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task GetCentros(string centro)
        {
            throw new NotImplementedException();
        }

        public async Task GetCentrosxEmpresa(string centro)
        {
            //All1 para traer los centros y divisiones de la empesa
            var result = await _http.GetFromJsonAsync<List<Centro>>($"http://neo.paveca.com.ve/ReunionApi/Empresas/Centros/{centro}");
            //var result = await _http.GetFromJsonAsync<List<Centro>>($"http://localhost:5258/Empresas/Centros/{cent}");
            if (result != null)
                centros = result; 
        }

        public Task GetDivision(string centro, string div)
        {
            throw new NotImplementedException();
        }

        public async Task GetLineas(int div)
        {
            var result = await _http.GetFromJsonAsync<List<Linea>>($"http://neo.paveca.com.ve/ReunionApi/Empresas/Lineas/{div}");
            //var result = await _http.GetFromJsonAsync<List<Centro>>($"http://localhost:5258/Empresas/Centros/{cent}");
            if (result != null)
                lineas = result;
        }
    }
}