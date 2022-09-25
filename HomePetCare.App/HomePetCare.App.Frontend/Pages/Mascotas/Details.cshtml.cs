using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascotas;
        public Mascota Mascota { get; set; }

        public DetailsModel()
        {
            this.repositorioMascotas=new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? mascotaId)
        {
            Mascota = repositorioMascotas.GetMascota(mascotaId);
            if(Mascota==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
