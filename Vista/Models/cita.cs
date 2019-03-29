using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Vista.Models
{
	public class cita
	{
		[Display(Name = "Tipo:")]
		public string Tipo { get; set; }
		public IEnumerable<SelectListItem> ListTipo { get; set; }
		public IEnumerable<SelectListItem> listPac { get; set; }
	}
}