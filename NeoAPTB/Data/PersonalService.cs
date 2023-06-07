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

        public async Task<List<Personal>> GetPersonal(string centro)
        {

            personals = await _neocontext.Personals
                .Include(m => m.Plantillas)
                .Where(l => l.PeGrupo == "N")
                .ToListAsync();
            return personals;
        }
        public async Task<List<Personal>> GetPersonalPlantilla(int centro, int linea)
        {

            personals = await _neocontext.Personals
                .Include(m => m.Plantillas)
                .Where(l =>l.Plantillas.Count==0 | (l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidCentro == centro & l.Plantillas.FirstOrDefault(f => f.PidCentro == centro).PidLinea == 0) | l.Plantillas.FirstOrDefault(f => f.PidCentro==centro).PidLinea ==linea  )
                .AsNoTracking()
                .ToListAsync();
            return personals;

        }   
        public async Task<List<Plantilla>> GetPlantillaPersonal(int centro, int linea)
        {

            plantilla = await _neocontext.Plantillas
                .Include(m => m.IdPersonalNavigation)
                .Where(l => l.PidLinea == linea & l.PidCentro == centro)
                .AsNoTracking()
                .ToListAsync();
            return plantilla;
        
        }

        public async Task<string> InsertarPlantilla(Plantilla plantilla)
        {

            _neocontext.Plantillas.Add(plantilla);
            await _neocontext.SaveChangesAsync();
            return "success";
        }
        public async Task<string> InsertarPersonal(Personal personal)
        {

            _neocontext.Personals.Add(personal);
            await _neocontext.SaveChangesAsync();
            return "success";
        }

        public async Task<string> UpdatePersonal(Personal personal)
        {           

            _neocontext.Entry(personal).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();
            return "success";   
        }
        public async Task<string> UpdatePlantilla(Plantilla plantilla)
        {
            _neocontext.Entry(plantilla).State = EntityState.Modified;
            await _neocontext.SaveChangesAsync();
            return "success";   
        }
    }
}
