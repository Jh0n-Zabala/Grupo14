using System;

namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>   
    public class Recomendaciones 
    {
        // Identificador único de cada SugerenciaCuidado
        public int? Id { get; set; }
        /// Fecha y hora en que se escribe la sugerencia
        public DateTime? FechaHora  { get; set; }
         /// Texto con la sugerencia
        public string? Descripcion {get;set;}
    }
}