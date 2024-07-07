using NeoAPTB.NeoModels;

namespace NeoAPTB.Interfaces
{
    public interface IMontos
    {
        List<Monto> MontosPuesto { get; set; }
        List<Monto> MontosPuestoLinea { get; set; }
        List<Monto> MontosPuestoCentro { get; set; }

        Task<List<Monto>> GetMontosxPuesto(int idPuesto);
        Task<List<Monto>> GetMontosxLinea(int idlinea);
        Task<List<Monto>> GetMontosxCentro(int idcentro);
        Task<List<Monedum>> GetMonedas();
        Task<int> CheckMontos(Monto monto);
        Task<string> InsertarMontosPuesto(Monto monto);
        Task<string> UpdateMontoPuesto(Monto moto);

    }
}
