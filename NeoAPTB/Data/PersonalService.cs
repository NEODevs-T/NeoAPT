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
                .Include(m => m.Resumen)
                .Where(l => l.PeGrupo == "N")
                .ToListAsync();
            return personals;
        }
        public async Task<List<Plantilla>> GetPersonalPuestos(string centro, string linea)
        {

            plantilla = await _neocontext.Plantillas
                .Include(m => m.IdPersonalNavigation)
                .Where(l => l.PidLinea == int.Parse(linea) & l.PidCentro == int.Parse(centro))
                .ToListAsync();
            return plantilla;
        }

        public async Task<string> InsertarPlantilla(Plantilla plantilla)
        {

            _neocontext.Plantillas.Add(plantilla);
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
