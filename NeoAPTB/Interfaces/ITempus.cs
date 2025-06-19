using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;

namespace NeoAPTB.Interfaces
{
    public interface ITempus
    {
        List<TrabajadorEnPuestoV> tempusenpuesto { get; set; }
        Task<List<TrabajadorEnPuestoV>> GetListaTempus(int idCentro);
        Task<Dictionary<string, string>> GetDiccionarioTempusConversion();
    }
}
