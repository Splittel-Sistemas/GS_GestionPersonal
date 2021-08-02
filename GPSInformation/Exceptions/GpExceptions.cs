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
        /// <summary>
        /// Numero de error
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Descripcion del error
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// tipo de excepcion
        /// </summary>
        public TypeException Category { get; set; }
        /// <summary>
        /// Id a agregar estatus ModelState (formulario)
        /// </summary>
        public string IdAux { get; set; }

        public override string Message
        {
            get
            {
                return Category == TypeException.System ?  $"{this.ErrorCode} : {this.Description}" : Description;
            }
        }
    }

    public enum TypeException
    {
        Error = 1,
        Success = 2,
        Info = 3,
        System = 4,
        Noautorizado = 5,
        NotFound = 6
    }
}
