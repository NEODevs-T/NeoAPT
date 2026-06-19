using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;
using NeoAPTB.ModelsMyIntelli;

namespace NeoAPTB.Interfaces
{
    public interface ITempus
    {
        List<TrabajadorEnPuestoV> tempusenpuesto { get; set; }
        Task<List<TrabajadorEnPuestoV>> GetListaTempus(int idCentro);
        Task<Dictionary<string, string>> GetDiccionarioTempusConversion();
        Task<List<TrabajadorEnPuestoVMi>> GetListaMyIntelli(int idCentro);
    }
}
