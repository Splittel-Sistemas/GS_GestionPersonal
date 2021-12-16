using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Models
{
    public class CF_PaginaContent_addModel
    {
        public IFormFile PageContent { get; set; }
        public int IdCF_Version { get; set; }
        [Required]
        public string NombrePage { get; set; }
        public int NoPage { get; set; }
    }

    public class CF_PaginaContent_updModel
    {
        public int IdCF_PaginaContent { get; set; }
        public IFormFile PageContent { get; set; }
        public int IdCF_Version { get; set; }
        [Required]
        public string NombrePage { get; set; }
        public int NoPage { get; set; }
    }
}
