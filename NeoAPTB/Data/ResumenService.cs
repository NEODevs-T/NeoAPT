using Microsoft.AspNetCore.Components;
using NeoAPTB.NeoModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using NeoAPTB.Interfaces;
using NeoAPTB.ModelsDOCIng;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace NeoAPTB.Data
{
    public class ResumenService: IResumen
    {

        private readonly DbNeoContext _neocontext;
        private readonly NavigationManager _navigationManager;


        public ResumenService(NavigationManager navigationManager, DbNeoContext _NeoContext)
        {
            _navigationManager = navigationManager;
            _neocontext = _NeoContext;
        }
        public List<Resuman> resumen { get; set; }
        public List<TipIncen> tipoincentivo { get; set; }
        public List<TipSuple> tiposuple { get; set; }
        public List<Personal> personal { get; set; }
        public List<Resuman> resumenlinea { get; set; }
        public List<Resuman> resumenlineafecha { get; set; }
        public List<Resuman> resumencentro { get; set; }
        public List<Resuman> resumensuplencia { get; set; }


        public Task<List<Personal>> GetPersonal(int id)
        {
            throw new NotImplementedException();
        }

        //Personal registrado del día
        public async Task<List<Resuman>> GetResumenFichas(DateTime f1)
        {
            resumen = await _neocontext.Resumen.Where(f => f.Rfecha >= f1.Date)
                .Include(p => p.IdPersonalNavigation)
                .AsNoTracking()
                .ToListAsync();

            return resumen;
        }

        public async Task<List<Resuman>> GetResumenSuplencias(int idCentro, DateTime f1, DateTime f2)
        {
            resumensuplencia = await _neocontext.Resumen
                .Include(r => r.IdTipIncenNavigation)
                .Include(r => r.IdPersonalNavigation)
                .Include(r => r.IdTipSupleNavigation)
                .Include(r => r.IdMontosNavigation)
                .Include(m => m.IdMontosNavigation.IdPuesTrabNavigation)
                .Include(m => m.IdMontosNavigation.IdLineaNavigation)
                .Where(r => (r.IdMontosNavigation.IdLineaNavigation.IdLinea == idCentro) & (r.IdTipSupleNavigation.IdTipSuple != 1))
                .ToListAsync();


            return resumensuplencia;
        }

        public async Task<List<Resuman>> GetResumenxCentro(int id, int turno)
        {
            var resumencentro = await _neocontext.Resumen
                .AsNoTracking()
                .Include(r => r.IdPersonalNavigation)
                .Include(m => m.IdMontosNavigation.IdPuesTrabNavigation)
                .Include(m => m.IdMontosNavigation.IdLineaNavigation)
                .Where(r => r.IdMontosNavigation.IdLineaNavigation.Master.IdCentro == id && r.Rturno == turno &&
                      r.Rfecha >= DateTime.Today &&
                      r.Rfecha < DateTime.Today.AddDays(1))
                .ToListAsync();

            return resumencentro;
        }

        public async Task<List<Resuman>> GetResumenxLinea(int id)
        {

            resumenlinea = await _neocontext.Resumen
                .AsNoTracking()
                .Include(r => r.IdPersonalNavigation)
                .Include(m => m.IdMontosNavigation.IdPuesTrabNavigation)
                .Include(m => m.IdMontosNavigation.IdLineaNavigation)
                .Where(r => (r.IdMontosNavigation.IdLineaNavigation.Master.IdLinea == id) && (r.Rfecha >= DateTime.Today && r.Rfecha < DateTime.Today.AddDays(1)))
                .ToListAsync();

            return resumenlinea;

        }
        public async Task<List<Resuman>> GetResumenxlineafecha(int id, DateTime f1, DateTime f2)
        {

            resumenlineafecha = await _neocontext.Resumen
              .Include(r => r.IdTipIncenNavigation)
              .Include(r => r.IdPersonalNavigation)
              .Include(r => r.IdTipSupleNavigation)
              .Include(r => r.IdMontosNavigation)
              .Include(m => m.IdMontosNavigation.IdPuesTrabNavigation)
              .Include(m => m.IdMontosNavigation.IdLineaNavigation)
              .Where(r => (r.IdMontosNavigation.IdLineaNavigation.Master.IdLinea == id) & (r.Rfecha >= f1.Date & r.Rfecha <= f2.Date.AddDays(1)))
              .ToListAsync();

            return resumenlineafecha;

        }
        public async Task<List<Monto>> GetMontoPuesto(int lineaid)
        {
            var result = await _neocontext.Montos
                .Include(p => p.IdPuesTrabNavigation)
                .Where(m => m.Mmonto == 0 && m.IdLinea == lineaid && !m.IdPuesTrabNavigation.Ptnombre.Contains("Sin Puesto de Trabajo") && m.IdPuesTrabNavigation.Ptesta == true)
                .ToListAsync();

            return result;
        }

        //Valida que el personal nuevo no este registrada en la bd de personal.
        public async Task<List<Personal>> FiltarListaPersonalNuevo(List<Personal> personals)
        {
            List<Personal> personalnoregistrado = new List<Personal>();

            foreach (Personal personal in personals)
            {
                if (!_neocontext.Personals.Any(P => P.PeFicha == personal.PeFicha))
                {
                    personalnoregistrado.Add(personal);
                }
            }
            return personalnoregistrado;

        }

        public async Task<Personal> GetPersonalSinTempus(string Ficha)
        {
            var result = await _neocontext.Personals.Where(f => f.PeFicha.Contains(Ficha))
                 .Include(p => p.Plantillas).FirstOrDefaultAsync();
            return result ?? new Personal();
        }
        public async Task<List<TipIncen>> GetTipoInce()
        {
            return tipoincentivo = await _neocontext.TipIncens
                 .Where(t => t.Tiesta == true)
                 .ToListAsync();
        }

        public async Task<List<TipSuple>> GetTipoSuple()
        {
            return tiposuple = await _neocontext.TipSuples
                           .Where(t => t.Tsestado == true)
                           .ToListAsync();
        }
        public async Task<List<TipSuple>> GetTipoSupleAll()
        {
            return tiposuple = await _neocontext.TipSuples
                           .ToListAsync();
        }

        public async Task<List<int>> CheckResumen(DateTime? fecha, int idcentro, int turno)
        {
            return await _neocontext.Resumen
                .AsNoTracking()
                .Where(r => r.Rfecha.Value.Date == fecha.Value.Date && r.IdMontosNavigation.IdLineaNavigation.Master.IdCentro == idcentro && r.Rturno == turno)                
                .Select(s => s.IdPersonal)
                .ToListAsync();

        }

        public async Task<List<Resuman>> ListaPersonalRegistrado(List<Resuman> personal)
        {
            List<Resuman> resumen = new List<Resuman>();
            foreach (var res in personal)
            {
                var result = await _neocontext.Resumen
                    .AsNoTracking()
                    .Where(r => r.Rfecha.Value.Date == res.Rfecha.Value.Date && r.IdPersonal == res.IdPersonal && r.Rturno == res.Rturno)
                    .Include(r=>r.IdPersonalNavigation)
                    .Include(r=>r.IdMontosNavigation).ThenInclude(l=>l.IdLineaNavigation)
                    .Include(r=>r.IdMontosNavigation).ThenInclude(p=>p.IdPuesTrabNavigation)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    resumen.Add(result);
                }
            }
            return resumen;

        }

        //public async Task<string> InsertResumen(List<Resuman> resumen)
        //{
        //    try
        //    {

        //        foreach (var rp in resumen)
        //        {
        //            if (rp.IdResumen > 0)
        //            {
        //                _neocontext.Entry(rp).State = EntityState.Modified;
        //            }
        //            else
        //            {
        //                _neocontext.Resumen.Add(rp);
        //            }


        //        }
        //        await _neocontext.SaveChangesAsync();
        //        return "success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
        public async Task<string> InsertResumen(List<Resuman> resumen)
        {
            try
            {
                foreach (var rp in resumen)
                {
                    var registroexistente = _neocontext.Resumen
                        .FirstOrDefault(r => r.Rfecha.Value.Date == rp.Rfecha.Value.Date && r.Rturno == rp.Rturno && r.IdPersonal==rp.IdPersonal);

                    if (registroexistente != null)
                    {
                        rp.IdResumen = registroexistente.IdResumen;
                        _neocontext.Entry(registroexistente).CurrentValues.SetValues(rp);
                    }
                    else
                    {
                        _neocontext.Resumen.Add(rp);
                    }
                }
                await _neocontext.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return "Ocurrió un error al procesar la solicitud.";
            }
        }



        public Task InsertTipoInce(TipIncen tipoince)
        {
            throw new NotImplementedException();
        }

        public async Task InsertTipoSuple(TipSuple tiposuple)
        {
            _neocontext.TipSuples.Add(tiposuple);
            await _neocontext.SaveChangesAsync();
        }



        public Task UpdateTipoInce(TipIncen tipoince)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTipoSuple(TipSuple tiposuple)
        {
            _neocontext.Entry(tiposuple).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();
        }

    }
}
