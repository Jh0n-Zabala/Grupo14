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
        Mascota AddMascota(Mascota paciente);
        Mascota UpdateMascota(Mascota paciente);
        void DeleteMascota(int idMascota);    
        Mascota GetMascota(int idMascota);
        // Veterinario AsignarVeterinario(int idMascota, int idVeterinario); 
        // IEnumerable<Mascota>  GetMascotasMasculinos();
        // IEnumerable<Mascota> GetMascotasCorazon();
        // IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
        // IEnumerable<SignoVital> GetSignosMascota(int idMascota);
             
       
    }


}