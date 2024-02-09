
using NeoAPTB.ModelsDOCIng;

namespace NeoAPTB.Interfaces
{
    public interface IGlobalData  
    {
        Task<RotaCalidum> GetRotacion(int IdPais);     
    }
}