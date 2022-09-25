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
    public class EditVetModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        //Enlace de datos del formulario al modelo con la pagina razor
        [BindProperty]

        public Veterinario Veterinario{set;get;}

        public EditVetModel()
        {
            this.repositorioVeterinario=new RepositorioVeterinario(new HomePetCare.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int? veterinarioId)
        {
            if(veterinarioId.HasValue)
            {
                Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId.Value);
            }
            else{
                Veterinario= new Veterinario();
            }
            if(Veterinario==null)
            {
                return RedirectToPage("./Notfound");
            }
            else
            {
                return Page();
            }
        }

        //Cuando se envian datos al servidor
        public IActionResult OnPost()
        {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (Veterinario.Id>0)
                {
                    
                    Veterinario= repositorioVeterinario.UpdateVeterinario(Veterinario);

                }

                return Page();
        }
    }
    
}
