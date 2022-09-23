using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HomePetCare.App.Persistencia
{
    public class RepositorioSignoVital : IRepositorioSignoVital
    {
        private readonly AppContext _appContext;

        public RepositorioSignoVital(AppContext _appContext)
        {
            _appContext = _appContext;
        }
        public SignoVital AddSignoVital(SignoVital signoVital)
        {
            var SignoVitalAdicionado = _appContext.SignosVitales.Add(signoVital);
            _appContext.SaveChanges();
            return SignoVitalAdicionado.Entity;
        }
    }
}