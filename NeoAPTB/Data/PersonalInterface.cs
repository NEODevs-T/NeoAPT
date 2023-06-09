using NeoAPTB.NeoModels;

namespace NeoAPTB.Data
{
    public interface PersonalInterface
    {

        public List<Personal> personals { get; set; }
        public List<Plantilla> plantilla { get; set; }


        Task<List<Personal>> GetPersonal(int centro, int linea, string grupo);
        Task<List<Personal>> GetPersonalPlantilla(int centro, int linea);
        Task<List<Plantilla>> GetPlantillaPersonal(int centro, int linea);

        Task<string> InsertarPlantilla(Plantilla plantilla);
        Task<string> UpdatePlantilla(Plantilla plantilla);
        Task<string> InsertarPersonal(Personal personal);
        Task<string> UpdatePersonal(Personal personal);
    }
}
