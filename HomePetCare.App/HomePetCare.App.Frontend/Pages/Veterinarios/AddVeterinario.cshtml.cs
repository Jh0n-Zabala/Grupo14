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
    public class AddVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]

        public Veterinario Veterinario{set;get;}

        public AddVeterinarioModel()
        {
            this.repositorioVeterinario=new RepositorioVeterinario(new HomePetCare.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int? veterinarioId)
        {
           
                return Page();
        }
        
        public IActionResult OnPost()
        {
                
            repositorioVeterinario.AddVeterinario(Veterinario);
            return Page();

        }
    }
}
