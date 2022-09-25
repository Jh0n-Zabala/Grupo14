namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>   
    public class Enfermera : Individuo
    {
        /// Numero único de la tarjeta profesional   
        public string? TarjetaProfesional { get; set; }
        /// Cantidad de horas laborales a la semana 
        public int? HorasLaborales { get; set; }
    }
}