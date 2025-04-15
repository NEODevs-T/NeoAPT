using Microsoft.AspNetCore.Components;
using NeoAPTB.NeoModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using NeoAPTB.Interfaces;
using NeoAPTB.ModelsSPI;
using System.Linq;
using System.Linq.Dynamic.Core;
using Radzen;

namespace NeoAPTB.Data
{
    public class SPIServices: ISPIServices
    {
        private readonly DbSPIContext _SPIcontext;
    
        public SPIServices(DbSPIContext SPIcontext)
        {
            _SPIcontext = SPIcontext;
        }

        public async Task<bool> GetValidarVacaciones(string ficha)
        {
            DateTime fecha = DateTime.Now;
            int filtro = int.Parse(fecha.ToString("yyyyMMdd")); 
            Nmpp070? personal = await _SPIcontext.Nmpp070s.Where(n => 
                                        n.Stahst.Contains("VACA") && 
                                        n.Fichst.Contains(ficha) &&
                                        filtro <= n.Fecfhs && filtro >= n.Fecihs
                                        ).FirstOrDefaultAsync();
            return personal != null ? true : false;
        }
    }
}