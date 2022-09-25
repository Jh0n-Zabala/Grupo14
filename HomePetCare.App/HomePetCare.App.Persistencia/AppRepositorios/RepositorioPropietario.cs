using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HomePetCare.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;
        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }


        Propietario IRepositorioPropietario.AddPropietario(Propietario Propietario)
        {
            var PropietarioAdicionado = _appContext.Propietarios.Add(Propietario);
            _appContext.SaveChanges();
            return PropietarioAdicionado.Entity;

        }

        void IRepositorioPropietario.DeletePropietario(int idPropietario)
        {
            var PropietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);
            if (PropietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(PropietarioEncontrado);
            _appContext.SaveChanges();
        }

       IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietario()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietario.GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);
        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario Propietario)
        {
            var PropietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == Propietario.Id);
            if (PropietarioEncontrado != null)
            {
                PropietarioEncontrado.Nombre = Propietario.Nombre;
                PropietarioEncontrado.Apellidos = Propietario.Apellidos;
                PropietarioEncontrado.NumeroTelefono = Propietario.NumeroTelefono;
                PropietarioEncontrado.Direccion = Propietario.Direccion;

                _appContext.SaveChanges();


            }
            return PropietarioEncontrado;
        }

    }
}