using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Models
{
	public class Cita
	{
		public int id { get; set; }
		public string Nombre { get; set; }
		public string Tipo { get; set; }
		public DateTime fecha { get; set; }
		public string estado { get; set; }
	}
}
