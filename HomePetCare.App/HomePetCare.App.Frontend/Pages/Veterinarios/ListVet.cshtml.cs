using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Persistencia;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Frontend.Pages
{
    public class ListVetModel : PageModel
    {
        private readonly IRepositorioVeterinario irepositorioVeterinario;

        public IEnumerable<Veterinario> Veterinarios { get; set; }

        public ListVetModel()
        {
       
             this.irepositorioVeterinario = new RepositorioVeterinario(new HomePetCare.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            Veterinarios = irepositorioVeterinario.GetAllVeterinario();
        }
    }
}
