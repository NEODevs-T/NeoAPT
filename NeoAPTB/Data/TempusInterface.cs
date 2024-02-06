using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;

namespace NeoAPTB.Data
{
    public interface TempusInterface
    {
        List<TrabajadorEnPuestoV> tempusenpuesto { get; set; }
        Task<List<TrabajadorEnPuestoV>> GetListaConversion();
        Task<Dictionary<string, string>> GetDiccionarioTempusConversion();
        Task<List<TrabajadorEnPuestoV>> GetResumenxCentro();
    }
}
