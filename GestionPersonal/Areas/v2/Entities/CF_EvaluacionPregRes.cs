using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{


	public class CF_EvaluacionPregRes : BaseEntity
	{
		[Key]
		public int IdCF_EvaluacionPregRes { get; set; }
		public int IdCF_EvaluacionPreg { get; set; }
		public string Respuesta { get; set; }
		public string ImagenPath { get; set; }
	}
}
