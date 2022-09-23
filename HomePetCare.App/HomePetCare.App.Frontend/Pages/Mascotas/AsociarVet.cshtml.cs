using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class AsociarVetModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]

        public Mascota Mascota{set;get;}
        public Veterinario Veterinario{set;get;}

        public AsociarVetModel()
        {
            this.repositorioMascota=new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
            this.repositorioVeterinario=new RepositorioVeterinario(new HomePetCare.App.Persistencia.AppContext());
            //this.repositorioMascota = repositorioMascota;
        }
        public IActionResult OnGet(int? mascotaId, int? veterinarioId)
        {
           
            if (mascotaId.HasValue)
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
                Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId.Value);
            }
            
            if (Mascota == null)
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
                
            repositorioMascota.AsignarVeterinario(Mascota.Id, Veterinario.Id);
            return Page();

        }
    }
}
