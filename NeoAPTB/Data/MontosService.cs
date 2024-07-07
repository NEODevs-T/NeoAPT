using NeoAPTB.NeoModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.Interfaces;

namespace NeoAPTB.Data
{
    public class MontosService :IMontos
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
                .ThenInclude(m => m.Master.IdCentroNavigation)
                .Where(l => l.IdLineaNavigation.Master.IdCentro == idcentro)
                .ToListAsync();
            return MontosPuestoCentro;
        }

        public async Task<List<Monto>> GetMontosxLinea(int idlinea)
        {
            MontosPuestoLinea = await _neocontext.Montos
                 .Include(m => m.IdPuesTrabNavigation)
                 .Include(m => m.IdLineaNavigation)
                 .Include(m=>m.IdMonedaNavigation)
                 .Where(l => l.IdLineaNavigation.IdLinea == idlinea)
                 .ToListAsync();
            return MontosPuestoLinea;
        }


        public async Task<List<Monto>> GetMontosxPuesto(int idPuesto)
        {
            MontosPuesto = await _neocontext.Montos
                 .Include(m => m.IdPuesTrabNavigation)
                 .Include(m => m.IdLineaNavigation)

                 .ToListAsync();
            return MontosPuesto;
        }

        public async Task<List<Monedum>> GetMonedas()
        {
           var result= await _neocontext.Moneda.Where(m=>m.Mestado==true).AsNoTracking().ToListAsync();
           return result;
        }
        public async Task<string> InsertarMontosPuesto(Monto monto)
        {
            int Check = await CheckMontos(monto);


            if (Check == 0)
            {
                _neocontext.Montos.Add(monto);
                await _neocontext.SaveChangesAsync();
                return "success";
            }
            else
            {
                return "existe";

            }

        }

        public async Task<string> UpdateMontoPuesto(Monto monto)
        {        //puesto.Ptnombre = d.Rdtiempo;
            int Check = await CheckMontos(monto);


            if (Check == 0)
            {
                _neocontext.Entry(monto).State = EntityState.Modified;
                await _neocontext.SaveChangesAsync();
                return "success";
            }
            else
            {
                return "existe";
            }

        }

        //Verificar que el monto y escalon esta desactivado o no existe
        public async Task<int> CheckMontos(Monto monto)
        {
            List<Monto> montos = new List<Monto>();
            montos = await _neocontext.Montos
             .Where(p => p.IdLinea == monto.IdLinea & p.Mescalon == monto.Mescalon & p.Mmonto == monto.Mmonto & p.Mesta == true & p.IdPuesTrab==monto.IdPuesTrab | p.IdLinea == monto.IdLinea & p.Mescalon == monto.Mescalon & p.IdPuesTrab == monto.IdPuesTrab & p.Mesta == true)
             .ToListAsync();
            return montos.Count();
        }

    }
}
