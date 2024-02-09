using NeoAPTB.ModelsViews;
using NeoAPTB.NeoModels;


namespace NeoAPTB.Interfaces
{
    public interface IMaestraData
    {
    
        Task<List<Centro>> GetCentrosxEmpresa(string centro);
        Task<List<Pai>> GetPaises();
        Task<List<EmpresasV>> GetEmpresas(int IdPais);
        Task<List<CentrosV>> GetCentros(int IdEmpresa);
        Task<List<DivisionesV>> GetDivisiones(int IdCentro);
        Task<List<LineaV>> GetLineas(int IdDivision);
        Task<int> GetMaestraPorLinea(int idLinea);

    }
}
