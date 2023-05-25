using Microsoft.AspNetCore.Components;
using NeoAPTB.NeoModels;
using Microsoft.EntityFrameworkCore;

namespace NeoAPTB.Data
{
    public class PuestosTrabajoService: PuestosTrabajoInterface
    {
        private readonly DbNeoContext _neocontext;
        private readonly NavigationManager _navigationManager;


        public PuestosTrabajoService( NavigationManager navigationManager, DbNeoContext _NeoContext)
        {

            _navigationManager = navigationManager;
            _neocontext = _NeoContext;
        }
        public List<PuesTrab> puesTrab { get; set; } = new List<PuesTrab>();

        public async Task<List<PuesTrab>> GetPuestosTrabajo(int id)
        {
          puesTrab = await _neocontext.PuesTrabs
                .Where(a => a.Montos.Where(x => x.IdLineaNavigation.IdLinea==id).Any())
                .ToListAsync();

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
