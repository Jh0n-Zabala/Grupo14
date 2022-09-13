using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
        private static IRepositorioMascota irepositorioMascota = new RepositorioMascota(new Persistencia.AppContext());
        // private readonly IRepositorioMascota irepositorioMascota;
        
        [BindProperty(SupportsGet  =true)]
        public string FiltroBusqueda { get; set; }
        public IEnumerable<Mascota> Mascotas { get; set; }
        public Mascota Mascota { get; set; }

        // public ListModel(IRepositorioMascota irepositorioMascota)
        // {
        //     this.irepositorioMascota = irepositorioMascota;
        //     this.irepositorioMascota = new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
        // }
        public void OnGet()
        {
            Mascotas = irepositorioMascota.GetAllMascotas();
            // Filtro de mascotas
            // FiltroBusqueda = filtroBusqueda;
            // Mascotas = _repoMascota.GetMascotaPorFiltro(filtroBusqueda); 

            // // Eliminacion de mascotas
            // Mascota = _repoMascota.GetMascota(idMascota);
            // if (Mascota == null)
            // {
            //     RedirectToPage("./NotFound");
            // }
            // else
            // {
            //     _repoMascota.DeleteMascota(Mascota.Id);
            //     Page();
            // }       
        }
    }
}
