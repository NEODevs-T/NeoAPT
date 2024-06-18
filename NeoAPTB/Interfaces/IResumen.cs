using NeoAPTB.NeoModels;
namespace NeoAPTB.Interfaces
{
    public interface IResumen
    {
        List<Resuman> resumenlinea { get; set; }
        List<Resuman> resumenlineafecha { get; set; }
        List<Resuman> resumencentro { get; set; }
        List<Resuman> resumensuplencia { get; set; }
        List<TipIncen> tipoincentivo { get; set; }
        List<TipSuple> tiposuple { get; set; }
        List<Personal> personal { get; set; }

        Task<List<Resuman>> GetResumenFichas(DateTime f1);
        Task<List<Resuman>> GetResumenxLinea(int id);
        Task<List<Resuman>> GetResumenxCentro(int id, int turno);
        Task<List<Resuman>> GetResumenxlineafecha(int idlinea, DateTime f1, DateTime f2);
        Task<List<Resuman>> GetResumenSuplencias(int idCentro, DateTime f1, DateTime f2);
        Task<List<Personal>> FiltarListaPersonalNuevo(List<Personal> personals);
        Task<List<int>> CheckResumen(DateTime? fecha, int idcentro, int turno);
        Task<Personal> GetPersonalSinTempus(string Ficha);
        Task<List<Resuman>> GetReumenSinAutorizar(DateTime? f1, DateTime? f2, int idcentro);
        Task<List<Resuman>> ListaPersonalRegistrado(List<Resuman> personal);
        Task<List<TipIncen>> GetTipoInce();
        Task<List<TipSuple>> GetTipoSuple();
        Task<List<TipSuple>> GetTipoSupleAll();
        Task<List<Personal>> GetPersonal(int id);
        Task<List<Monto>> GetMontoPuesto(int lineaid);
        Task<string> InsertResumen(List<Resuman> resumen);
        Task<string> InsertyUpdateResumen(List<Resuman> resumen);
        Task<string> UpdateResumen(List<Resuman> resumen);
        Task InsertTipoInce(TipIncen tipoince);
        Task InsertTipoSuple(TipSuple tiposuple);
        Task UpdateTipoInce(TipIncen tipoince);
        Task UpdateTipoSuple(TipSuple tiposuple);

    }
}
