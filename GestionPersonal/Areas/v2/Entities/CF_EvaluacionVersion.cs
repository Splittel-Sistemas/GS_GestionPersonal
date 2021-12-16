using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Entities
{
	public class CF_EvaluacionVersion : BaseEntity
	{
		[Key]
		public int IdCF_EvaluacionVersion { get; set; }
		public int IdCF_Evaluacion { get; set; }
		public string Comentarios { get; set; }
		public string Instrucciones { get; set; }
		public decimal MinCalificacion { get; set; }
		public int NoVersion { get; set; }
		public bool Aleatory { get; set; }
		public bool Publicada { get; set; }
		public bool BySecciones { get; set; }
		public DateTime? FechaPubli { get; set; }

		[NotMapped]
		public string Folio
		{
			get
			{
				return $"V{string.Format("{0:000}", IdCF_Evaluacion)}-{string.Format("{0:00}", IdCF_EvaluacionVersion)}";
			}
		}
	}
}
