using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Responses
{
    public class Res_Salas
    {
        public int Id { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public List<Res_Salarerservacion> Events { get; set; }
    }
    public class Res_Salarerservacion
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdSala { get; set; }
        public int IdPersona { get; set; }
    }
}
