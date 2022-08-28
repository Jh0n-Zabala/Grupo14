using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HomePetCare.App.Persistencia
{

    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }


        Mascota IRepositorioMascota.AddMascota(Mascota Mascota)
        {
            var MascotaAdicionado = _appContext.Mascotas.Add(Mascota);
            _appContext.SaveChanges();
            return MascotaAdicionado.Entity;

        }

        void IRepositorioMascota.DeleteMascota(int idMascota)
        {
            var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
            if (MascotaEncontrado == null)
                return;
            _appContext.Mascotas.Remove(MascotaEncontrado);
            _appContext.SaveChanges();
        }

       IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.Mascotas;
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

        Mascota IRepositorioMascota.GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota Mascota)
        {
            var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == Mascota.Id);
            if (MascotaEncontrado != null)
            {
                MascotaEncontrado.Nombre = Mascota.Nombre;
                MascotaEncontrado.Apellidos = Mascota.Apellidos;
                MascotaEncontrado.NumeroTelefono = Mascota.NumeroTelefono;
                MascotaEncontrado.Genero = Mascota.Genero;
                MascotaEncontrado.Direccion = Mascota.Direccion;
                // MascotaEncontrado.Latitud = Mascota.Latitud;
                // MascotaEncontrado.Longitud = Mascota.Longitud;
                MascotaEncontrado.Ciudad = Mascota.Ciudad;
                MascotaEncontrado.FechaNacimiento = Mascota.FechaNacimiento;
                MascotaEncontrado.Propietario = Mascota.Propietario;
                MascotaEncontrado.Enfermera = Mascota.Enfermera;
                MascotaEncontrado.Veterinario = Mascota.Veterinario;
                MascotaEncontrado.Historia = Mascota.Historia;

                _appContext.SaveChanges();


            }
            return MascotaEncontrado;
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