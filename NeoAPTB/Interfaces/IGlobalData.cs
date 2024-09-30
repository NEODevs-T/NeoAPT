
using NeoAPTB.ModelsDOCIng;
using NeoAPTB.DTOs;

namespace NeoAPTB.Interfaces
{
    public interface IGlobalData  
    {
        Task<RotaCalidum> GetRotacion(int IdPais);    
        Task<PersonalSPIDTO> GetPersonalPorFicha(string ficha);
    }
}