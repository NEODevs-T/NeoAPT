using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.NeoModels;

namespace NeoAPTB.Data
{
    public class PersonalService : PersonalInterface
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

            personals = await _neocontext.Personals
                .Include(m => m.Plantillas)              
                .Where(l => (l.PeGrupo == grupo & (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro & l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == linea)) | (l.Plantillas.Count == 0 | (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro & l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == 0)))
                .AsNoTracking()
                .ToListAsync();
            return personals;
        }
        public async Task<List<Personal>> GetPersonalPlantilla(int centro, int linea)
        {

            personals = await _neocontext.Personals
                .Include(m => m.Plantillas)
                .AsNoTracking().Where(l =>l.Plantillas.Count==0 | (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro & l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == 0) | l.Plantillas.FirstOrDefault(f => f.PidCentro==centro).PidLinea ==linea  )
                
                .ToListAsync();
            return personals;

        }   
        public async Task<List<Plantilla>> GetPlantillaPersonal(int centro, int linea)
        {

            plantilla = await _neocontext.Plantillas
                .Include(m => m.IdPersonalNavigation).AsNoTracking()
                .Where(l => l.PidLinea == linea & l.PidCentro == centro)
                
                .ToListAsync();
            return plantilla;
        
        }

        //inserta el personal y la Plantilla
        public async Task<string> InsertarPlantilla(Plantilla plantilla)
        {
            if (plantilla.IdPersonalNavigation.IdPersonal >0 )
            {
                plantilla.IdPersonalNavigation = null;
            }
            _neocontext.Plantillas.Add(plantilla);    
            await _neocontext.SaveChangesAsync();

            //Desactiva el tracking para poder modificar o insertar el mismo ID
            _neocontext.Entry(plantilla).State = EntityState.Detached;
            if (plantilla.IdPersonalNavigation != null)
            {
                _neocontext.Entry(plantilla.IdPersonalNavigation).State = EntityState.Detached;
            }
        
            return "success";
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

            _neocontext.Personals.Add(personal);
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

        public async Task<string> InsertarListPersonal(List<Personal> personal)
        {
            foreach(var  person in personal)
            {
                _neocontext.Personals.Add(person);
            }
            
            await _neocontext.SaveChangesAsync();
            foreach (var person in personal)
            {
                _neocontext.Entry(person).State = EntityState.Detached;
            }
            return "success";
        }
    }
}
