using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Models
{
    public class UsuarioPermisos
    {
        public int IdPersona { get; set; }
        public int IdPersonaUser { get; set; }
        public List<GPSInformation.Models.Modulo> Modulos { get; set; }
        public List<ReporteAccessos> Reportes { get; set; }
    }

    public class ReporteAccessos
    {
        public int IdReporte { get; set; }
        public string Descripcion { get; set; }
        public bool Acceso { get; set; }
    }
}
