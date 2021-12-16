using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
	public class CF_EvaluacionSeccion : BaseEntity
	{
		[Key]
		public int IdCF_EvaluacionSeccion { get; set; }
		public string Nombre { get; set; }
		public int IdCF_EvaluacionVersion { get; set; }
	}
}
