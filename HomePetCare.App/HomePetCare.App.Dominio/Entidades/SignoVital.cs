using System;

namespace HomePetCare.App.Dominio
{
    /// <summary>Class <c>FamiliarDesignado</c>
    /// Modela al familiar asignado para cuidar al paciente
    /// </summary>   
    public class SignoVital 
    {
        // Identificador único de cada signo vital
        public int Id { get; set; }
        /// Fecha y hora en que se realizó la toma del signo vital 
        public DateTime FechaHora  { get; set; }
         /// Valor numérico del sifno vital  
        public float? Valor {get;set;}
        /// Tipo de Signo vital medido
        public TipoSigno? Signo { get; set; }
    }
}