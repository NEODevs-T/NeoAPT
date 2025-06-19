using NeoAPTB.NeoModels;
//TODO: Revisar al Cambiar el nombre de esta tabla
namespace NeoAPTB.Interfaces
{
    public interface IMontos
    {
        List<Monto> MontosPuestoLinea { get; set; }
        List<Monto> MontosPuestoCentro { get; set; }
        Task<List<Monto>> GetMontosxLinea(int idlinea);
        Task<int> CheckMontos(Monto monto);
        Task<string> InsertarMontosPuesto(Monto monto);

    }
}
