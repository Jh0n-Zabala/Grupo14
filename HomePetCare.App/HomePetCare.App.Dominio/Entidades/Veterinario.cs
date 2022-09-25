namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>    
    public class Veterinario : Individuo
    {
        /// Nombre de la especialidad medica del Médico  
        public string? Especialidad { get; set; }
        /// Código único del médico
        public string? Codigo { get; set; }
         /// Registro Unico Nacional del Talento Humano 
        public string? RegistroRethus { get; set; }
    }
}