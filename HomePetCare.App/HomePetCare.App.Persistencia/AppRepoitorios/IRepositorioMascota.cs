using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public interface IRepositorioMascota
    {   
        IEnumerable<Mascota> GetAllMascotas();
        IEnumerable<Mascota> GetMascotas();
        Mascota AddMascota(Mascota mascota);
        Mascota UpdateMascota(Mascota mascota);
        void DeleteMascota(int idMascota);    
        Mascota GetMascota(int idMascota);
        // Veterinario AsignarVeterinario(int idMascota, int idVeterinario); 
        // IEnumerable<Mascota>  GetMascotasMasculinos();
        // IEnumerable<Mascota> GetMascotasCorazon();
         IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
        // IEnumerable<SignoVital> GetSignosMascota(int idMascota);
             
       
    }


}