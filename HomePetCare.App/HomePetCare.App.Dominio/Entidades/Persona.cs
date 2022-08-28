namespace HomePetCare.App.Dominio
{
public class Persona
	{
		public int Id { get; set; }
		public String Nombre{get;set;}
		public String Apellidos{get;set;}
		public String NumeroTelefono{get;set;}
        public Genero Genero { set; get; }
	}
}
	