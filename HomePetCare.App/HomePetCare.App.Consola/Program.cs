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
            Console.WriteLine("Hello World EF");//branch Yineth
            //AddMascota();
            //BuscarMascota(2);
            //AddSignosMascota(5);
            AsignarVeterinario();
        }

        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Toby",
                Apellidos = "Torres",
                NumeroTelefono = "31111645",
                Raza = "BassetHound",
                Edad = 10,
                Direccion = "Calle 44 No 767-4",
                // Longitud = 5.07062F,
                // Latitud = -75.52290F,
                Ciudad = "Bogota",
                FechaNacimiento = new DateTime(2012, 04, 12)
                
            };
            _repoMascota.AddMascota(mascota);

        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Apellidos);
        }

        /*private static void ListarSignosMascota(int idMascota)
        {
            var signos = _repoMascota.GetSignosMascota(idMascota);
            if (signos != null)
            {
                foreach (SignoVital s in signos)
                {
                    Console.WriteLine(s.Valor);
                }
            }
            else
            {
                Console.WriteLine("No registra signos");
            }


        }*/
        /* private static void AddPacienteConSignos()
        {
            var paciente = new Paciente
            {
                Nombre = "Carmenza",
                Apellidos = "Zuluaga",
                NumeroTelefono = "5001646",
                Genero = Genero.Femenino,
                Direccion = "Calle 908 No Xy-40",
                Longitud = 5.07062F,
                Latitud = -75.52290F,
                Ciudad = "Pereira",
                FechaNacimiento = new DateTime(1984, 04, 12),
                SignosVitales = new List<SignoVital> {
                    new SignoVital{FechaHora= new DateTime(2021,09,12,18,50,0),Valor=36,Signo=TipoSigno.TemperaturaCorporal},
                    new SignoVital{FechaHora= new DateTime(2021,09,12,18,50,0),Valor=95,Signo=TipoSigno.SaturacionOxigeno},
                    new SignoVital{FechaHora= new DateTime(2021,09,12,18,50,0),Valor=90,Signo=TipoSigno.FrecuenciaCardica}

                }
            };
            _repoPaciente.AddPaciente(paciente);

        }*/

        private static void AddSignosMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
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
                _repoMascota.UpdateMascota(mascota);
            }


        }

        private static void AsignarVeterinario()
        {
            var veterinario = _repoMascota.AsignarVeterinario(8, 10);
            Console.WriteLine(veterinario.Nombre + " " + veterinario.Apellidos);
        }

    }

}
