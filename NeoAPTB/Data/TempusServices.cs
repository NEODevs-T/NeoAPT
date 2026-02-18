using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NeoAPTB.Interfaces;
using NeoAPTB.NeoModels;
using NeoAPTB.TempusModels;
using NeoAPTB.ModelsMyIntelli;

namespace NeoAPTB.Data
{
    public class TempusServices : ITempus
    {
        private readonly TempusIiContext _tempuscontext;

        private readonly MyIntelliContext _myIntelliContext;

        private (string CONVERSION, string MOLINOS) CodDepartamentosTempus = ("33","32");
        private (int CONVERSION, int MOLINOS, int PPPD) idCentros = (1,2,8);

        public TempusServices(TempusIiContext _TempusContext, MyIntelliContext myIntelliContext )
        {

            _tempuscontext = _TempusContext;
            _myIntelliContext = myIntelliContext;
        }
        public List<TrabajadorEnPuestoV> tempusenpuesto { get; set; }

        public List<TrabajadorEnPuestoVMi> tempusenpuestoMyinteli { get; set; }

        public async Task<List<TrabajadorEnPuestoV>> GetListaTempus(int idCentro)
        {
            if(idCentro == idCentros.CONVERSION){
                tempusenpuesto = await _tempuscontext.TrabajadorEnPuestoVs              
                .Where(t => t.CodigoDpto.StartsWith(CodDepartamentosTempus.CONVERSION) && (t.IdTransaccion == 201))
                .AsNoTracking()
                .ToListAsync();
            }else if(idCentro == idCentros.MOLINOS){
                tempusenpuesto = await _tempuscontext.TrabajadorEnPuestoVs              
                .Where(t => t.CodigoDpto.StartsWith(CodDepartamentosTempus.MOLINOS) && (t.IdTransaccion == 201))
                .AsNoTracking()
                .ToListAsync();
            }else{
                tempusenpuesto = new List<TrabajadorEnPuestoV>();
            }
            return tempusenpuesto;

        }

        public async Task<List<TrabajadorEnPuestoVMi>> GetListaMyIntelli(int idCentro)
        {
            if(idCentro == idCentros.CONVERSION){
                tempusenpuestoMyinteli = await _myIntelliContext.TrabajadorEnPuestoVMis              
                .Where(t => t.CodigoDpto.StartsWith(CodDepartamentosTempus.CONVERSION) && (t.IdTransaccion == 201))
                .AsNoTracking()
                .ToListAsync();
            }else if(idCentro == idCentros.MOLINOS){
                tempusenpuestoMyinteli = await _myIntelliContext.TrabajadorEnPuestoVMis              
                .Where(t => t.CodigoDpto.StartsWith(CodDepartamentosTempus.MOLINOS) && (t.IdTransaccion == 201))
                .AsNoTracking()
                .ToListAsync();
            }else{
                tempusenpuestoMyinteli = new List<TrabajadorEnPuestoVMi>();
            }
            return tempusenpuestoMyinteli;

        }
        public async Task<Dictionary<string, string>> GetDiccionarioTempusConversion()
        {

            var diccionario = _tempuscontext.TrabajadorEnPuestoVs
                .Where(t => t.CodigoDpto.StartsWith("33") & (t.EnPuesto == true) & (t.Descripcion== "Entrada a puesto"))
                .ToDictionary(p => p.CodigoTrabajador, p => p.NombreTrab);
            
            return diccionario;
        }
    }
}
