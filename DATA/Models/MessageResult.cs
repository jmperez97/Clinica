using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace DATA.Models
{
	public class MessageResult
	{
		public HttpStatusCode Status { get; set; }
		public object Objeto { get; set; }
		public string Message { get; set; }
	}
}
