using System;

namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>      
    public class Mascota : Individuo
    {
        public int? Id{get;set;}
		public string? Raza{get;set;}
		public int? Edad{get;set;}
        public string? Direccion { get; set; }
        /// Coordenada de la dirección del Paciente
        // public float Latitud { get; set; }
        // /// Coordenada de la dirección del Paciente
        // public float Longitud { get; set; }
        // Ciudad de residencia del Paciente
        public string? Ciudad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        /// Relacion entre Paciente y su FamiliarDesignado para cuidarlo
        public Propietario? Propietario { get; set; }
        /// Relacion entre Paciente y la  Enfermera asignada
        public Enfermera? Enfermera { get; set; }
        /// Relacion entre Paciente y el Medico que lo atiende
        public Veterinario? Veterinario { get; set; }
        /// Relacion entre Paciente y su Historia clínica
        public Historia? Historia { get; set; }
        /// <summary>
        ///  Referencia a la lista de signos vitales de un Paciente 
        /// </summary>
        /// <value></value>
        public System.Collections.Generic.List<SignoVital>? SignosVitales { get; set; }
    }
}
