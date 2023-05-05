using Microsoft.AspNetCore.Mvc;
using NeoAPB.NeoModels;
//using NeoAPB.DTOs;

namespace NeoAPB.Data
{
    public interface PuestosTrabajoInterface
    {
        List<PuesTrab> puesTrab { get; set; }

     
        Task<List<PuesTrab>> GetPuestosTrabajo(int id);
        Task InsertarPuestoTrabajo(PuesTrab puesto);
        Task UpdatePuestoTrabajo(PuesTrab puesto, int id);
    }
}
