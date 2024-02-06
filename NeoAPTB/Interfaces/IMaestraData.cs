using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NeoAPTB.NeoModels;
using static System.Net.WebRequestMethods;

namespace NeoAPTB.Interfaces
{
    public interface IMaestraData
    {
        List<Centro> centro { get; set; }
        List<Linea> lineas { get; set; }
        List<Division> divisions { get; set; }

        Task GetCentros(string centro);
        Task GetDivision(string centro, string div);
        Task GetLineas(int div);
        Task<List<Centro>> GetCentrosxEmpresa(string centro);
    }
}
