using System.ComponentModel.DataAnnotations;

namespace NeoAPTB.DTOs
{
    public class PersonalSPIDTO
    {
        public string primerNombre { get; set; } = "";
        public string segundoNombre { get; set;} = "";
        public string primerApellido { get; set;} = "";
        public string segundoApellido { get; set;} = "";
        public string departamento { get; set;} = ""; 
        public string cargo { get; set;} = "";
        public string compania { get; set;} = "";
    }
}