using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

/*namespace HomePetCare.App.Frontend.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]
        public Mascota Mascotas{get;set;}
        public DeleteModel()
        {
            this.repositorioMascota=new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int mascotaId)
        {
            if (mascotaId.HasValue)
            {
                Mascotas = repositorioMascota.GetMascota(mascotaId.Value);
            }
            
            if (Mascotas == null)
            {
                return RedirectToPage("./Notfound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (Mascotas.Id>0)
                {
                    
                    repositorioMascota.DeleteMascota(Mascotas.Id);
                }
                else
                {
                    repositorioMascota.AddMascota(Mascotas);
                }
                return Page();
        }
    }
}*/
