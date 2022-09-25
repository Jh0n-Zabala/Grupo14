using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HomePetCare.App.Persistencia
{

    public class RepositorioMascota : IRepositorioMascota
    {
        private readonly AppContext _appContext;
        
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

        void IRepositorioMascota.DeleteMascota(int? idMascota)
        {
            var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
            if (MascotaEncontrado == null)
                return;
            _appContext.Mascotas.Remove(MascotaEncontrado);
            _appContext.SaveChanges();
        }
        /*void AddSignosMascota(int idMascota)
        {
            var mascota = _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
            if (mascota != null)
            {
                if (mascota.SignosVitales != null)
                {
                    
                    mascota.SignosVitales.Add(new SignoVital { FechaHora = new DateTime(2021, 07, 10, 10, 50, 0), Valor = 86, Signo = TipoSigno.FrecuenciaCardica });
                }
                else
                {
                    mascota.SignosVitales = new List<SignoVital> {
                        new SignoVital{FechaHora= new DateTime(2021,07,10,10,50,0),Valor=86,Signo=TipoSigno.FrecuenciaCardica}
                    };
                }
                _appContext.Mascotas.Update(mascota);
            }


        }*/

       IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.Mascotas;
        }
        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
            var Mascotas = GetAllMascotas_(); // Obtiene todos los saludos
            if (Mascotas != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    Mascotas = Mascotas.Where(s => s.Nombre.Contains(filtro));
                }

            }
            return Mascotas;

        }

        public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int? idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota Mascota)
        {
            var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == Mascota.Id);
            if (MascotaEncontrado != null)
            {
                //MascotaEncontrado.idMascota = Mascota.Id;
                MascotaEncontrado.Nombre = Mascota.Nombre;
                MascotaEncontrado.Apellidos = Mascota.Apellidos;
                MascotaEncontrado.NumeroTelefono = Mascota.NumeroTelefono;
                MascotaEncontrado.Genero = Mascota.Genero;
                MascotaEncontrado.Direccion = Mascota.Direccion;
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

        public Veterinario AsignarVeterinario(int? idMascota, int? idMedico)
         {
             var MascotaEncontrado = _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);
             if (MascotaEncontrado != null)
             {
                 var VeterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(m => m.Id == idMedico);
                 if (VeterinarioEncontrado != null)
                 {
                     MascotaEncontrado.Veterinario = VeterinarioEncontrado;
                     _appContext.SaveChanges();
                 }
                 return VeterinarioEncontrado;
             }
             return null;
         }

        // public IEnumerable<Mascota> GetMascotasMasculinos()
        // {

        //     return _appContext.Mascotas.Where(p => p.Genero == Genero.Masculino).ToList();        }

        // IEnumerable<Mascota> IRepositorioMascota.GetMascotasCorazon()
        // {

        //     return _appContext.Mascotas
        //                            .Where(p => p.SignosVitales.Any(s => TipoSigno.FrecuenciaCardica == s.Signo && s.Valor >= 90))
        //                            .ToList();
        // }

         IEnumerable<SignoVital> IRepositorioMascota.GetSignosMascota(int? idMascota)
         {
            var Mascota = _appContext.Mascotas.Where(s => s.Id==idMascota)
                                                .Include(s=>s.SignosVitales)
                                                .FirstOrDefault();

            return Mascota.SignosVitales;
         }

       /* SignoVital IRepositorioMascota.AddSignoVital(SignoVital SignoVital)
        {
            var SignoVitalAdicionado = _appContext.Mascotas.Add(SignoVital);
            _appContext.SaveChanges();
            return SignoVitalAdicionado.Entity;

        }*/
    }
}