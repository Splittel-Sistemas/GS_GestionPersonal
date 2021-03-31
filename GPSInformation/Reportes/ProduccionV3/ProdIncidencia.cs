using GPSInformation.Models.Produccion;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Reportes.ProduccionV3
{
    public class ProdIncidencia
    {
        public int IdPersona { get; set; }
        public string TipoIncidencia { get; set; }
        public int TipoPermiso { get; set; }
        public string Comentarios { get; set; }
        public IFormFile AdjuntoFile { get; set; }
        public DateTime Fecha { get; set; }
        public List<DiasProp> Semana { get; set; }
    }

    public class DiasProp
    {
        public int Dia { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool Apply { get; set; }
        public DateTime FechaPago { get; set; }
        public float Horas { get; set; }
    }

}
