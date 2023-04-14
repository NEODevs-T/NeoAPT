using Microsoft.AspNetCore.Mvc;
using NeoAPT.NeoModels;
//using NeoAPT.DTOs;

namespace NeoAPT.Data
{
    public interface PuestosTrabajoInterfaz
    {
        List<PuesTrab> puesTrab { get; set; }

     
        Task<List<PuesTrab>> GetPuestosTrabajo(int id);
        Task InsertarPuestoTrabajo(PuesTrab puesto);
        Task UpdatePuestoTrabajo(PuesTrab puesto, int id);
    }
}
