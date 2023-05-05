using NeoAPTB.NeoModels;

namespace NeoAPTB.Data
{
    public interface EmpresasCentrosInteface
    {
        public List<Centro> centros { get; set; }   
        public List<Division> divisions { get; set; }
        public List<Linea> lineas { get; set; }

        Task GetCentros(string centro);
        Task GetCentrosxEmpresa(string centro);      
        Task GetDivision(string centro, string div);    
        Task GetLineas(int div);
    }
}
