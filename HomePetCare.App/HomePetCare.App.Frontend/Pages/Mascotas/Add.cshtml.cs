using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class AddModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]

        public Mascota Mascota{set;get;}

        public AddModel()
        {
            this.repositorioMascota=new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
            //this.repositorioMascota = repositorioMascota;
        }
        public IActionResult OnGet(int? mascotaId)
        {
           
                return Page();
        }
        
        public IActionResult OnPost()
        {
                
            repositorioMascota.AddMascota(Mascota);
            return Page();

        }
    }
}

    
