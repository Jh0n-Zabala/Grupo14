// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// See https://aka.ms/new-console-template for more information
using System;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;

namespace HomePetCare.App.Consola
{
    class Program
    {

        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World EF!------------");
            //AddMascota();
            BuscarMascota(1);
        }

        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Rodolfo",
                Apellidos = "Francis",
                NumeroTelefono = "31111645",
                Genero = Genero.Masculino,
                Direccion = "Calle 44 No 767-4",
                // Longitud = 5.07062F,
                // Latitud = -75.52290F,
                Ciudad = "Bogota",
                FechaNacimiento = new DateTime(1990, 04, 12)
            };
            _repoMascota.AddMascota(mascota);

        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Apellidos);
        }

    }
}