using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
	/*
		Tipo
			OPEN = Pregunta de text
			MLOPT = Multiopcion mas de una opcion valida,
			OPTIO = Opcional solo una respuest valida
	*/
	public class CF_EvaluacionPreg : BaseEntity
	{
		[Key]
		public int IdCF_EvaluacionPreg { get; set; }
		public int IdCF_EvaluacionVersion { get; set; }
		public int? IdCF_EvaluacionSeccion { get; set; }
		public string Pregunta { get; set; }
		public string DescipcionPath { get; set; }
		public string Tipo { get; set; }
		public int Orden { get; set; }
	}
}
