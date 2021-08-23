using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Request
{
    public class ReqExpediente
    {
        public int IdPersona { get; set; } 
        public int IdExpedienteArchivo { get; set; }
        public IFormFile Archivo { get; set; }
    }
}
