using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;

namespace HomePetCare.App.Frontend.Pages
{
    public class EditPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;

        [BindProperty]

        public Propietario Propietario{set;get;}

        public EditPropietarioModel()
        {
            this.repositorioPropietario=new RepositorioPropietario(new HomePetCare.App.Persistencia.AppContext());

        }
        public IActionResult OnGet(int? propietarioId)
        {
            if(propietarioId.HasValue)
            {
                Propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
            }
            else{
                Propietario= new Propietario();
            }
            if(Propietario==null)
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
                if (Propietario.Id>0)
                {
                    
                    Propietario= repositorioPropietario.UpdatePropietario(Propietario);

                }

                return Page();
        }
    }
}
