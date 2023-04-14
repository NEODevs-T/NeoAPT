using NeoAPT.NeoModels;

namespace NeoAPT.Data
{
    public interface MontosInterface
    {
        List<Monto> MontosPuesto{ get; set; }
        List<Monto> MontosPuestoLinea{ get; set; }
        List<Monto> MontosPuestoCentro{ get; set; }

        Task<List<Monto>> GetMontosxPuesto(int idPuesto);
        Task<List<Monto>> GetMontosxLinea(int idlinea);
        Task<List<Monto>> GetMontosxCentro(int idcentro);

        Task InsertarMontosPuesto(Monto monto);
        Task UpdateMontoPuesto(Monto moto, int id);

    }
}
