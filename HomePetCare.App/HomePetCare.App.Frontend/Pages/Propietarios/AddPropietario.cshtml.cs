using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;

namespace HomePetCare.App.Frontend.Pages
{
    public class AddPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]

        public Propietario Propietario{set;get;}

        public AddPropietarioModel()
        {
            this.repositorioPropietario=new RepositorioPropietario(new HomePetCare.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int? propetiarioId)
        {
           
                return Page();
        }
        
        public IActionResult OnPost()
        {
                
            repositorioPropietario.AddPropietario(Propietario);
            return Page();

        }

    }
}
