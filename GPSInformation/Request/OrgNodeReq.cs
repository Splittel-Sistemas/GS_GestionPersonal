using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Request
{
    /// <summary>
    /// informacion para nodos en veriones de organigrama
    /// </summary>
    public class OrgNodeReq
    {
        [Display(Name = "Versión del organigrama")]
        [DisplayFormat(DataFormatString = "OR-{0:0000}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Por favor selecciona una version del organigrama")]
        public int IdOrganigramaVersion { get; set; }
        [Display(Name = "Puesto")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor selecciona un puesto")]
        public int IdPuesto { get; set; }
        [Display(Name = "Puesto jefe")]
        //[Required(ErrorMessage = "Por favor selecciona un puesto jefe")]
        public int IdPuestoParent { get; set; }
        [Display(Name = "Subniveles del puesto jefe")]
        public int Nivel { get; set; }
    }
}
