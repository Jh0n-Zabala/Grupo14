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
    public class EditModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        //Enlace de datos del formulario al modelo con la pagina razor
        [BindProperty]

        public Mascota Mascota{set;get;}

        public EditModel()
        {
            this.repositorioMascota=new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
            //this.repositorioMascota = repositorioMascota;
        }
        public IActionResult OnGet(int? mascotaId)
        {
            if(mascotaId.HasValue)
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
            }
            else{
                Mascota= new Mascota();
            }
            if(Mascota==null)
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
                if (Mascota.Id>0)
                {
                    
                    Mascota= repositorioMascota.UpdateMascota(Mascota);

                }
                else
                {
                    repositorioMascota.AddMascota(Mascota);
                }
                return Page();
        }
    }
}
