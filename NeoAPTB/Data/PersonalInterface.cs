using NeoAPTB.NeoModels;

namespace NeoAPTB.Data
{
    public interface PersonalInterface
    {

        public List<Personal> personals { get; set; }
        public List<Plantilla> plantilla { get; set; }


        Task<List<Personal>> GetPersonal(string centro);
        Task<List<Personal>> GetPersonalPlantilla(int centro, int linea);
        Task<List<Plantilla>> GetPlantillaPersonal(int centro, int linea);

        Task<string> InsertarPlantilla(Plantilla plantilla);
        Task<string> UpdatePlantilla(Plantilla plantilla);
    }
}
