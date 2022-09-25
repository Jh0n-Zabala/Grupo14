using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
        
         private readonly IRepositorioMascota irepositorioMascota;
        
        //[BindProperty(SupportsGet  =true)]
        //public string FiltroBusqueda { get; set; }
        public IEnumerable<Mascota> Mascotas { get; set; }
    


         public ListModel() //(IRepositorioMascota irepositorioMascota)
         {

             this.irepositorioMascota = new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
         }
        public void OnGet()
        {
            Mascotas = irepositorioMascota.GetAllMascotas();
     
        }
    }
}
