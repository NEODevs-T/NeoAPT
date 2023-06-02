using NeoAPTB.NeoModels;

namespace NeoAPTB.Data
{
    public interface PersonalInterface
    {

        public List<Personal> personals { get; set; }
        public List<Plantilla> plantilla { get; set; }


        Task<List<Personal>> GetPersonal(string centro);
        Task<List<Plantilla>> GetPersonalPuestos(int centro, int linea);

        Task<string> InsertarPlantilla(Plantilla plantilla);
        Task<string> UpdatePlantilla(Plantilla plantilla);
    }
}
