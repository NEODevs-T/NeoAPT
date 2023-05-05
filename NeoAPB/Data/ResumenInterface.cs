using NeoAPB.NeoModels;
namespace NeoAPB.Data
{
    public interface ResumenInterface
    {
        List<Resuman> resumenlinea { get; set; }
        List<Resuman> resumencentro { get; set; }
        List<Resuman> resumensuplencia { get; set; }
        List<TipIncen> tipoincentivo { get; set; }
        List<TipSuple> tiposuple { get; set; }
        List<Personal> personal { get; set; }

        Task<List<Resuman>> GetResumenxLinea(int id);
        Task<List<Resuman>> GetResumenxCentro(int id);
        Task<List<Resuman>> GetResumenSuplencias(int idCentro, DateTime f1, DateTime f2);
        Task<List<TipIncen>> GetTipoInce(int id);
        Task<List<TipSuple>> GetTipoSuple(int id);
        Task<List<Personal>> GetPersonal(int id);
        Task InsertarPuestoTrabajo(PuesTrab puesto);
        Task UpdatePuestoTrabajo(PuesTrab puesto, int id);
    }
}
