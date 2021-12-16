using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
	public class CF_Evaluacion : BaseEntity
	{
		[Key]
		public int IdCF_Evaluacion { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public bool Activa { get; set; }

		[NotMapped]
		public string Folio
		{
			get
			{
				return string.Format("E-{0:000}", IdCF_Evaluacion);
			}
		}
	}
}
