using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
    public class CF_versionObject: BaseEntity
    {
        [Key]
        public int IdCF_versionObject { get; set; }
        public int IdCF_Version { get; set; }
        public string Nombre { get; set; }
        public int IdRefer { get; set; }
        public string Tipo { get; set; }
        public int Orden { get; set; }
        public int? Parent { get; set; }
    }
}
