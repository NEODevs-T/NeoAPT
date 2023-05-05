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
        public List<Personal> personals { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<List<Personal>> GetPersonal(string centro)
        {

            personals = await _neocontext.Personals
                .Include(m => m.Resumen)
                .Where(l => l.PeGrupo.Contains('N'))
                .ToListAsync();
            return personals;
        }
    }
}
