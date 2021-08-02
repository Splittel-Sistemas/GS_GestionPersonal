using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Responses
{
    public class ResReporteRun
    {
        public string NombreReporte { get; set; }
        public List<string> Columnas { get; set; }
        public List<object[]> Filas { get; set; }
    }
}
