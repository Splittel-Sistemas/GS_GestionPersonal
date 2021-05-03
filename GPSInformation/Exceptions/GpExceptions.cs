using GPSInformation.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Exceptions
{
    public class GpExceptions : Exception
    {
        public GpExceptions()
        {

        }

        public GpExceptions(string mensaje)
            : base(mensaje)
        {
            
        }
    }
    public class GPException : Exception
    {
        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public string NameObject { get; set; }
        public TypeException Category { get; set; }
        public string IdAux { get; set; }

        public override string Message
        {
            get
            {
                return $"{this.ErrorCode} : {this.Description}";
            }
        }
    }

    public enum TypeException
    {
        Error = 1,
        Success = 2,
        Info = 3,
        System = 4
    }
}
