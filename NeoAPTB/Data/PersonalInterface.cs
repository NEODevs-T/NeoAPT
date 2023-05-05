using NeoAPTB.NeoModels;

namespace NeoAPTB.Data
{
    public interface PersonalInterface
    {

        public List<Personal> personals { get; set; }


        Task<List<Personal>> GetPersonal(string centro);
    
    }
}
