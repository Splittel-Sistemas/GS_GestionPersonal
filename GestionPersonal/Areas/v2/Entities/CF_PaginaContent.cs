using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
    public class CF_PaginaContent: BaseEntity
    {
        [Key]
        public int IdCF_PaginaContent { get; set; }
        public string FilePath { get; set; }
        public string NombrePage { get; set; }
        public int IdCF_Version { get; set; }
        public int NoPage { get; set; }
    }
}
