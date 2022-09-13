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
        ///// <param name="appContext"></param>//
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }


        Mascota IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var MascotaAdicionado = _appContext.Mascotas.Add(mascota);
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

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return GetAllMascotas_();
        }
        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
             var mascotas = GetAllMascotas(); // Obtiene todos los saludos
             if (mascotas != null)  //Si se tienen saludos
             {
                 if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                 {
                     mascotas = mascotas.Where(s => s.Nombre.Contains(filtro));
                 }

             }
             return mascotas;

         }

        public IEnumerable<Mascota> GetAllMascotas_()
         {
             return _appContext.Mascotas;
         }

        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota mascota)
        {
            var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == mascota.Id);
            if (MascotaEncontrado != null)
            {
                MascotaEncontrado.Nombre = mascota.Nombre;
                MascotaEncontrado.Apellidos = mascota.Apellidos;
                MascotaEncontrado.NumeroTelefono = mascota.NumeroTelefono;
                MascotaEncontrado.Genero = mascota.Genero;
                MascotaEncontrado.Direccion = mascota.Direccion;
                // MascotaEncontrado.Latitud = Mascota.Latitud;
                // MascotaEncontrado.Longitud = Mascota.Longitud;
                MascotaEncontrado.Ciudad = mascota.Ciudad;
                MascotaEncontrado.FechaNacimiento = mascota.FechaNacimiento;
                MascotaEncontrado.Propietario = mascota.Propietario;
                MascotaEncontrado.Enfermera = mascota.Enfermera;
                MascotaEncontrado.Veterinario = mascota.Veterinario;
                MascotaEncontrado.Historia = mascota.Historia;

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
        List<Mascota> mascota;

        public RepositorioMascota()
        {
            mascota= new List<Mascota>()
            {
                new Mascota{Id=11,Nombre="Susy",Raza="Criollo",Edad=5},
                new Mascota{Id=12,Nombre="Toby",Raza="BassetHound",Edad=10},
                new Mascota{Id=13,Nombre="Lulu",Raza="BassetHound",Edad=11}
            };
        }
        public IEnumerable<Mascota> GetMascotas()
        {
            return mascota;
        }

    } //Constructor de esta clase
}