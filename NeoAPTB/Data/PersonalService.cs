using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.Interfaces;
using NeoAPTB.NeoModels;
using System;

namespace NeoAPTB.Data
{
    public class PersonalService : IPersonal
    {
        private readonly DbNeoContext _neocontext;
        private readonly NavigationManager _navigationManager;


        public PersonalService(NavigationManager navigationManager, DbNeoContext _NeoContext)
        {

            _navigationManager = navigationManager;
            _neocontext = _NeoContext;
        }
        public List<Personal> personals { get; set; }
        public List<Plantilla> plantilla { get; set; }

        public async Task<List<Personal>> GetPersonal(int centro, int linea, string grupo)
        {

            //personals = await _neocontext.Personals
            //.Include(m => m.Plantillas)
            //.Where(l => ((l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro && l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == linea)) 
            //    || l.Plantillas.Count == 0 || (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro) && (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == null)
            //    || (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro     && l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == 0))
            //.AsNoTracking()
            //.ToListAsync();
            personals = await _neocontext.Personals
                .AsNoTracking()
                .Include(m => m.Plantillas)
                .Where(l => l.Plantillas.Any(f => f.PidCentro == centro))
                //.Select(l => new {
                 
                //    IdPersonal = l.IdPersonal,
                //    PeFicha = l.PeFicha,
                //    PeNombre = l.PeNombre,
                //    PeApellido = l.PeApellido,
                //    PeGrupo = l.PeGrupo,
                //    Plantillas = l.Plantillas.Select(p => new {
                //        PidLinea = p.PidLinea,
                //        Plinea = p.Plinea,
                //        PidCentro = p.PidCentro,
                //        Pcentro = p.Pcentro,
                //    })
                //})
                .ToListAsync();

            return personals;
        }
        public async Task<List<Personal>> GetPersonalPlantilla(int centro, int linea)
        {



            if (linea == 0)
            {

                personals = await _neocontext.Personals
                .Include(m => m.Plantillas)
                .AsNoTracking().Where(l => l.Plantillas.Count == 0 
                    || (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro) 
                    || (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == null))
                .ToListAsync();

            }
            else
            {
                personals = await _neocontext.Personals
                .Include(m => m.Plantillas)
                .AsNoTracking().Where(l => l.Plantillas.Count == 0 
                    || (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro & l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == 0) 
                    || l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == linea)
                .ToListAsync();

            }
            return personals;
        }

        public async Task<Dictionary<int, string>> GetPersonalFichas(int linea)
        {
            var diccionario = _neocontext.Personals.Where(l => l.Plantillas.Any(l => l.PidLinea == linea)).ToDictionary(p => p.IdPersonal, p => p.PeFicha);
            return diccionario;

        }

        public async Task<List<Personal>> GetPersonalAlResumen(string ficha)
        {
            personals = await _neocontext.Personals.Where(id=>id.PeFicha == ficha).ToListAsync();
            return personals;
        }
        public async Task<List<Plantilla>> GetPlantillaPersonal(int centro, int linea)
        {
            if (linea == 0)
            {
                plantilla = await _neocontext.Plantillas
              .Include(m => m.IdPersonalNavigation).AsNoTracking()
              .Where(l => l.PidCentro == centro)
              .ToListAsync();
            }
            else
            {
                plantilla = await _neocontext.Plantillas
               .Include(m => m.IdPersonalNavigation).AsNoTracking()
               .Where(l => l.PidLinea == linea & l.PidCentro == centro)
               .ToListAsync();
            }

            return plantilla;

        }

        //inserta el personal y la Plantilla
        public async Task<string> InsertarPlantilla(Plantilla plantilla)
        {
            string operacion = "success";

            if (plantilla.IdPersonalNavigation.IdPersonal > 0)
            {
                await UpdatePersonal(plantilla.IdPersonalNavigation);
                plantilla.IdPersonalNavigation = null;
            }

            if (plantilla.IdPersonalNavigation is not null)
            {
                if (!_neocontext.Plantillas.Any(P => P.IdPersonalNavigation.PeFicha == plantilla.IdPersonalNavigation.PeFicha))
                {
                    _neocontext.Plantillas.Add(plantilla);
                    await _neocontext.SaveChangesAsync();
                }
                else
                {
                    operacion = "Ya Existe";
                }

            }
            else
            {
                _neocontext.Plantillas.Add(plantilla);
                await _neocontext.SaveChangesAsync();
            }    




            //Desactiva el tracking para poder modificar o insertar el mismo ID
            _neocontext.Entry(plantilla).State = EntityState.Detached;
            if (plantilla.IdPersonalNavigation != null)
            {
                _neocontext.Entry(plantilla.IdPersonalNavigation).State = EntityState.Detached;
            }

            return operacion;
        }


        //Edita el personal y la plantilla
        public async Task<string> UpdatePlantilla(Plantilla plantilla)
        {
            _neocontext.Entry(plantilla).State = EntityState.Modified;
            _neocontext.Entry(plantilla.IdPersonalNavigation).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();
            //Desactiva el tracking para poder modificar o insertar el mismo ID
            _neocontext.Entry(plantilla).State = EntityState.Detached;
            _neocontext.Entry(plantilla.IdPersonalNavigation).State = EntityState.Detached;
            return "success";
        }
        public async Task<string> InsertarPersonal(Personal personal)
        {
            if (!_neocontext.Personals.Any(P => P.PeFicha == personal.PeFicha))
            {
                _neocontext.Personals.Add(personal);
            }

            await _neocontext.SaveChangesAsync();
            _neocontext.Entry(personal).State = EntityState.Detached;
            return "success";
        }

        public async Task<string> UpdatePersonal(Personal personal)
        {

            _neocontext.Entry(personal).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();
            _neocontext.Entry(personal).State = EntityState.Detached;
            return "success";

        }
        //desde resumen puesto
        public async Task<string> InsertarListPersonal(List<Personal> personal, int idcentro, string centro)
        {
            Plantilla plantilla = new Plantilla();
            List<Plantilla> listapl = new List<Plantilla>(); 

            foreach (var person in personal)
            {
                if (!_neocontext.Personals.Any(P => P.PeFicha == person.PeFicha))
                {
                    plantilla = new Plantilla();
                    plantilla.PidCentro = idcentro;
                    plantilla.Pcentro = centro;
                    plantilla.IdPersonalNavigation = person;
                    listapl.Add(plantilla);
                    //_neocontext.Plantillas.Add(plantilla);
                    //_neocontext.Personals.Add(person);
                }                
            }
            _neocontext.AddRange(listapl);
            await _neocontext.SaveChangesAsync();
            foreach (var person in personal)
            {
                _neocontext.Entry(person).State = EntityState.Detached;
            }
            return "success";
        }


    }
}
