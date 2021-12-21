using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Models
{
    public class CF_versionObject_addModel
    {
        public int IdCF_Version { get; set; }
        public int IdRefer { get; set; }
        public string Tipo { get; set; }
        public int Orden { get; set; }
        public int? Parent { get; set; }
    }
}
