using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.Interfaces;
using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;

namespace NeoAPTB.Data
{
    public class TempusServices : ITempus
    {
        private readonly TempusIiContext _tempuscontext;



        public TempusServices(TempusIiContext _TempusContext)
        {

            _tempuscontext = _TempusContext;
        }
        public List<TrabajadorEnPuestoV> tempusenpuesto { get; set; }

        public async Task<List<TrabajadorEnPuestoV>> GetListaConversion()
        {
            tempusenpuesto = await _tempuscontext.TrabajadorEnPuestoVs              
               .Where(t => t.CodigoDpto.StartsWith("33") & (t.EnPuesto==true) )
                .AsNoTracking()
                .ToListAsync();
            return tempusenpuesto;


        }
        public async Task<Dictionary<string, string>> GetDiccionarioTempusConversion()
        {

            var diccionario = _tempuscontext.TrabajadorEnPuestoVs
                .Where(t => t.CodigoDpto.StartsWith("33") & (t.EnPuesto == true) & (t.Descripcion== "Entrada a puesto"))
                .ToDictionary(p => p.CodigoTrabajador, p => p.NombreTrab);
            
            return diccionario;
        }

            public async Task<List<TrabajadorEnPuestoV>> GetResumenxCentro()
    {
        throw new NotImplementedException();
    }
}
}
