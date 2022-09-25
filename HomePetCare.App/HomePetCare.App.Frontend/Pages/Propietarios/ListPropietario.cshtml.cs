using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;

namespace HomePetCare.App.Frontend.Pages
{
    public class ListPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;

        public IEnumerable<Propietario> Propietarios { get; set; }

        public ListPropietarioModel()
        {
       
             this.repositorioPropietario = new RepositorioPropietario(new HomePetCare.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
            Propietarios = repositorioPropietario.GetAllPropietario();
        }
    }
}
