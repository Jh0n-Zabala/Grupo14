namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>   
	public class Propietario : Individuo
	{
		public string? Parentesco { get; set; }
		public string? Direccion{get;set;}
	}
}