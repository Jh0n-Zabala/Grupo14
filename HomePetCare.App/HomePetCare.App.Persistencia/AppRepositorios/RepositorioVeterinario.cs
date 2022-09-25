using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HomePetCare.App.Persistencia
{

    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }


        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario Veterinario)
        {
            var VeterinarioAdicionado = _appContext.Veterinarios.Add(Veterinario);
            _appContext.SaveChanges();
            return VeterinarioAdicionado.Entity;

        }

        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var VeterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.Id == idVeterinario);
            if (VeterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(VeterinarioEncontrado);
            _appContext.SaveChanges();
        }

       IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.Veterinarios;
        }
        // public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        // {
        //     var Mascotas = GetAllMascotas(); // Obtiene todos los saludos
        //     if (Mascotas != null)  //Si se tienen saludos
        //     {
        //         if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
        //         {
        //             Mascotas = Mascotas.Where(s => s.Nombre.Contains(filtro));
        //         }

        //     }
        //     return Mascotas;

        // }

        // public IEnumerable<Mascota> GetAllMascotas_()
        // {
        //     return _appContext.Mascotas;
        // }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(p => p.Id == idVeterinario);
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario Veterinario)
        {
            var VeterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.Id == Veterinario.Id);
            if (VeterinarioEncontrado != null)
            {
                //MascotaEncontrado.idMascota = Mascota.Id;
                VeterinarioEncontrado.Nombre = Veterinario.Nombre;
                VeterinarioEncontrado.Apellidos = Veterinario.Apellidos;
                VeterinarioEncontrado.NumeroTelefono = Veterinario.NumeroTelefono;
                VeterinarioEncontrado.Codigo = Veterinario.Codigo;
                VeterinarioEncontrado.Genero = Veterinario.Genero;
                VeterinarioEncontrado.RegistroRethus = Veterinario.RegistroRethus;

                _appContext.SaveChanges();


            }
            return VeterinarioEncontrado;
        }

        // public Medico AsignarMedico(int idMascota, int idMedico)
        // {
        //     var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
        //     if (MascotaEncontrado != null)
        //     {
        //         var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
        //         if (medicoEncontrado != null)
        //         {
        //             MascotaEncontrado.Medico = medicoEncontrado;
        //             _appContext.SaveChanges();
        //         }
        //         return medicoEncontrado;
        //     }
        //     return null;
        // }

        // public IEnumerable<Mascota> GetMascotasMasculinos()
        // {

        //     return _appContext.Mascotas.Where(p => p.Genero == Genero.Masculino).ToList();        }

        // IEnumerable<Mascota> IRepositorioMascota.GetMascotasCorazon()
        // {

        //     return _appContext.Mascotas
        //                            .Where(p => p.SignosVitales.Any(s => TipoSigno.FrecuenciaCardica == s.Signo && s.Valor >= 90))
        //                            .ToList();
        // }

        // IEnumerable<SignoVital> IRepositorioMascota.GetSignosMascota(int idMascota)
        // {
        //     var Mascota = _appContext.Mascotas.Where(s => s.Id==idMascota)
        //                                        .Include(s=>s.SignosVitales)
        //                                        .FirstOrDefault();

        //     return Mascota.SignosVitales;
        // }
    }
}