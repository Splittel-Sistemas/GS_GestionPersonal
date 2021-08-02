using GPSInformation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Request
{
    public class ReqReporteRun
    {
        public int IdReporte { get; set; }
        public List<string> OmitCols { get; set; }
        public List<Rpt_Aux_parame> Parametros { get; set; }
    }

}
