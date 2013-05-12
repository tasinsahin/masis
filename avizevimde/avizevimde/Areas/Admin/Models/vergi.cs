using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace avizevimde.Areas.Admin.Models
{
    public class vergi
    {
        [Key]
        [Display(Name = "Kodu")]
        public int Id { get; set; }

        [Display(Name="Adı")]
        public string name { get; set; }
         
    }
}