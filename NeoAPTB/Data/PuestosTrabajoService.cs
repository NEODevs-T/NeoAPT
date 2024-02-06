using Microsoft.AspNetCore.Components;
using NeoAPTB.NeoModels;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.Interfaces;

namespace NeoAPTB.Data
{
    public class PuestosTrabajoService : IPuestosTrabajo
    {
        private readonly DbNeoContext _neocontext;
        private readonly NavigationManager _navigationManager;


        public PuestosTrabajoService(NavigationManager navigationManager, DbNeoContext _NeoContext)
        {

            _navigationManager = navigationManager;
            _neocontext = _NeoContext;
        }
        public List<PuesTrab> puesTrab { get; set; } = new List<PuesTrab>();
        public List<Monto> montos { get; set; } = new List<Monto>();

        public async Task<List<PuesTrab>> GetAllPuestosTrabajo()
        {
          
                puesTrab = await _neocontext.PuesTrabs
                  .Include(m => m.Montos)
                  .Select(p => new PuesTrab
                  {
                      IdPuesTrab = p.IdPuesTrab,
                      Ptnombre = p.Ptnombre,

                  })
                  .AsNoTracking()
                  .ToListAsync();

            return puesTrab;
        }

        public async Task<List<Monto>> GetLineasPuestosTrabajo(int idpuesto)
        {
            montos = await _neocontext.Montos
            .Include(l => l.IdPuesTrabNavigation)
            .Include(l => l.IdLineaNavigation)
            .Where(ip=>ip.IdPuesTrab.Equals(idpuesto))
            .AsNoTracking()
            .ToListAsync();

            return montos;
        }

        public async Task<List<PuesTrab>> GetPuestosTrabajo(int id)
        {
            if(id == 0)
            {
                puesTrab = await _neocontext.PuesTrabs
                .AsNoTracking()
                  .ToListAsync();
            }
            else
            {
                puesTrab = await _neocontext.PuesTrabs
                  .Where(a => a.Montos.Where(x => x.IdLineaNavigation.IdLinea == id).Any())
                  .ToListAsync();
            }

            return puesTrab;
        }

        public async Task<int> InsertarPuestoTrabajo(PuesTrab puesto)
        {
            _neocontext.PuesTrabs.Add(puesto);
            await _neocontext.SaveChangesAsync();
            return puesto.IdPuesTrab;
        }

        public async Task UpdatePuestoTrabajo(PuesTrab puesto)
        {
            _neocontext.Entry(puesto).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();

        }
    }
}
