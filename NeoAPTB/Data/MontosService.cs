using NeoAPTB.NeoModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace NeoAPTB.Data
{
    public class MontosService : MontosInterface
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

                 .ToListAsync();
            return MontosPuesto;
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
