using GPSInformation.Models;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Responses
{
    /// <summary>
    /// detalle de empleado
    /// </summary>
    public class ResEmpleadoDetails
    {
        /// <summary>
        /// Numero de nomina
        /// </summary>
        [Display(Name = "Número de nomina")]
        public string NoNomina { get; set; }
        public Persona Persona { get; set; }
        public InformacionMedica InformacionMedica { get; set; }
        public Empleado Empleado { get; set; }
        public List<PersonaContacto> PersonaContacto { get; set; }
    }
}
