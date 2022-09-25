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

        void IRepositorioVeterinario.DeleteVeterinario(int? idVeterinario)
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

        Veterinario IRepositorioVeterinario.GetVeterinario(int? idVeterinario)
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

    }
}