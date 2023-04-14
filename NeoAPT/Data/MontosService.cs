using NeoAPT.NeoModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace NeoAPT.Data
{
    public class MontosService : MontosInterfaz
    {
        private readonly DbNeoContext _neocontext;
        private readonly NavigationManager _navigationManager;


        public MontosService(NavigationManager navigationManager, DbNeoContext _NeoContext)
        {

            _navigationManager = navigationManager;
            _neocontext = _NeoContext;
        }
        public List<Monto> MontosPuesto { get; set; }
        public List<Monto> MontosPuestoLinea { get; set; }
        public List<Monto> MontosPuestoCentro { get; set; }

        public async Task<List<Monto>> GetMontosxCentro(int idcentro)
        {

            MontosPuestoCentro = await _neocontext.Montos
                .Include(m => m.IdPuesTrabNavigation)
                .Include(m => m.IdLineaNavigation)
                .ThenInclude(m => m.IdCentroNavigation)
                .Where(l => l.IdLineaNavigation.IdCentro == idcentro)
                .ToListAsync();
            return MontosPuestoCentro;
        }

        public async Task<List<Monto>> GetMontosxLinea(int idlinea)
        {
            MontosPuestoLinea = await _neocontext.Montos
                 .Include(m => m.IdPuesTrabNavigation)
                 .Include(m => m.IdLineaNavigation)
                 .Where(l => l.IdLineaNavigation.IdLinea == idlinea)
                 .ToListAsync();
            return MontosPuestoLinea;
        }


        public async Task<List<Monto>> GetMontosxPuesto(int idPuesto)
        {
            MontosPuesto = await _neocontext.Montos
                 .Include(m => m.IdPuesTrabNavigation)
                 .Include(m => m.IdLineaNavigation)
                 .Where(p => p.IdPuesTrab==idPuesto)
                 .ToListAsync();
            return MontosPuesto;
        }

        public async Task InsertarMontosPuesto(Monto monto)
        {
            _neocontext.Montos.Add(monto);
            await _neocontext.SaveChangesAsync();
        }

        public async Task UpdateMontoPuesto(Monto monto, int id)
        {        //puesto.Ptnombre = d.Rdtiempo;

            _neocontext.Entry(monto).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();
        }
    }
}
