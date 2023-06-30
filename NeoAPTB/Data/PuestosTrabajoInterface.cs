using Microsoft.AspNetCore.Mvc;
using NeoAPTB.NeoModels;
//using NeoAPTB.DTOs;

namespace NeoAPTB.Data
{
    public interface PuestosTrabajoInterface
    {
        List<PuesTrab> puesTrab { get; set; }

     
        Task<List<PuesTrab>> GetPuestosTrabajo(int id);
        Task<List<PuesTrab>> GetAllPuestosTrabajo();
        Task<List<Monto>> GetLineasPuestosTrabajo(int idpuesto);
        Task<int> InsertarPuestoTrabajo(PuesTrab puesto);
        Task UpdatePuestoTrabajo(PuesTrab puesto);
    }
}
