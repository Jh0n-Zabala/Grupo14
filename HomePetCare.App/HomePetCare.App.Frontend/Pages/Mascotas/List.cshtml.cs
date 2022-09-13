using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
        //private readonly IRepositorioMascota repositorioMascota1;
        private readonly IRepositorioMascota repositorioMascota;

        public IEnumerable<Mascota> Mascotas{get;set;}

        public ListModel(IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = repositorioMascota;
        
        }
        public void OnGet()
        {
            Mascotas= repositorioMascota.GetMascotas();
        }
    }
}