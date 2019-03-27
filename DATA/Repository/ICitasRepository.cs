using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Models;

namespace DATA.Repository
{
	public interface ICitasRepository
	{
		List<Cita> GetCitas();
	}
}
