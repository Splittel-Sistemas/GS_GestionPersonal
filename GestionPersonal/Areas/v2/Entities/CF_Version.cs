using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
    public class CF_Version : BaseEntity
    {
        [Key]
        public int IdCF_Version { get; set; }
        public string Comentarios { get; set; }
        public bool Activa { get; set; }
        public int IdCF_Formacion { get; set; }
        public int NoVersion { get; set; }
        public bool Publicada { get; set; }
        public DateTime? FechaPubli { get; set; }
        [NotMapped]
        public string Folio
        {
            get
            {
                return $"V{string.Format("{0:000}", IdCF_Formacion)}-{string.Format("{0:00}", IdCF_Version)}";
            }
        }
    }
}
