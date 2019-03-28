using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Models
{
	public class Paciente:IPersona
	{
		public int id { get; set; }
		public string Nombre { get;  set; }
		public string cedula { get; set; }
		public string telefono { get; set; }
		public string estado { get; set;}
		public string Accion { get; set; }

	}
}
