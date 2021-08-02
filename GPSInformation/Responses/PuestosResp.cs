using GPSInformation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Responses
{
    public class PuestosResp
    {
        public Puesto Puesto { get; set; }
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name="Area de trabajo en")]
        public string Ubicacion { get; set; }
    }

    public class DireccionResp
    {
        public Direccion Direccion { get; set; }
        [Display(Name = "Sociedad")]
        public string Sociedad { get; set; }
    }

    public class DepartamentoResp
    {
        public Departamento Departamento { get; set; }
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
    }
}
