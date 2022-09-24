using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Veterinario> listVeterinarios{get;set;}

        public AsociarVetModel()
        {
            this.repositorioMascota=new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
            this.repositorioVeterinario=new RepositorioVeterinario(new HomePetCare.App.Persistencia.AppContext());
            //this.repositorioMascota = repositorioMascota;
        }
        public void OnGet(int? mascotaId)
        {
            listVeterinarios = repositorioVeterinario.GetAllVeterinario();
           
            if (mascotaId.HasValue)
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
            }
            
            else
            {
                Mascota = new Mascota();
               
            }
            if (Mascota == null)
            {
                RedirectToPage("./Notfound");
                
            }
                Page();
        }
        
        public IActionResult OnPost(Mascota mascota, int veterinarioId)
        {
            
            if(ModelState.IsValid)
            {
                Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId);
                if(mascota.Id > 0)
                {
                    mascota.Veterinario = Veterinario;
                    repositorioMascota.AsignarVeterinario(mascota.Id,Veterinario.Id);
                   
                }

                return RedirectToPage("/Mascotas/List");
            }
            else
            {
                return Page();
            }

        }
    }
}
