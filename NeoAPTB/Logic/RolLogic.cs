
using NeoAPTB.Interfaces;

namespace NeoAPTB.Logic
{
    public class RolLogic : IRolLogic
    {
        //Diccionario de roles segun nivel de acceso:
        Dictionary<string, List<string>> roles { get; set; } = new Dictionary<string, List<string>>
               {
                    {"Super", new List<string> { "SuperAdmin" }},
                    {"Pais", new List<string> { "UserPais", "Admin", "Primeverificador" }},
                    {"Empresa", new List<string> { "UserEmpresa" }},
                    {"Centro", new List<string> { "UserCentro","SupIntendente", "SuperUser" }},
                    {"Division", new List<string> { "UserDivision" }}
                };


        public Dictionary<string, bool> ListasRol(string roleClaim)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();

            foreach (var rol in roles)
            {
                if (result.ContainsKey("Super") && result["Super"] == true)
                {
                    result[rol.Key] = true;
                }
                else if (result.ContainsKey("Pais") && result["Pais"] == true)
                {
                    result[rol.Key] = true;
                }
                else if (result.ContainsKey(" Empresa") && result["Empresa"] == true)
                {
                    result[rol.Key] = true;
                }
                else if (result.ContainsKey("Centro") && result["Centro"] == true)
                {
                    result[rol.Key] = true;
                }               
                else
                {
                    result[rol.Key] = rol.Value.Any(role => roleClaim.Contains(role));
                }
            }

            return result;
        }


    }
}




