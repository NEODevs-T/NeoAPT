using NeoAPT.NeoModels;
namespace NeoAPT.Data
{
    public interface ResumenInterface
    {
        List<Resuman> resumen { get; set; }
        List<TipIncen> tipoincentivo { get; set; }
        List<TipSuple> tiposuple { get; set; }
        List<Personal> personal { get; set; }

        Task<List<Resuman>> GetResumen(int id);
        Task<List<TipIncen>> GetTipoInce(int id);
        Task<List<TipSuple>> GetTipoSuple(int id);
        Task<List<Personal>> GetPersonal(int id);
        Task InsertarPuestoTrabajo(PuesTrab puesto);
        Task UpdatePuestoTrabajo(PuesTrab puesto, int id);
    }
}
