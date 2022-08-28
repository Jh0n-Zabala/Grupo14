
using System.Collections.Generic;

namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>   
    public class Historia 
    {
        // Identificador único de la Historia
        public int? Id { get; set; }
        /// Descripcion detallada del diagnostico del Paciente 
        public string? Diagnostico  { get; set; }
         /// Descripción de la casa y habitación del Paciente  
        public string? Entorno { get; set; }
        /// Referencia la lista de sugerencias registradas en la Historia del Paciente
        public List<Recomendaciones>? Recomendaciones { get; set; }
    }
}