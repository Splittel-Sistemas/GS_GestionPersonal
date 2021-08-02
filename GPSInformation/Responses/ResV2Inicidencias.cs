using GPSInformation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Responses
{
    public class ResV2Inicidencias
    {
        public List<IncidenciaPermiso> Permisos { get; set; }
        public List<IncidenciaVacacion> Vacaciones { get; set; }
    }
}
