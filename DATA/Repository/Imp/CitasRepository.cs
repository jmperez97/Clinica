using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Models;
using DATA.Context;
namespace DATA.Repository.Imp
{
	class CitasRepository:ICitasRepository
	{
		public List<Cita> GetCitas()
		{
			List<Cita> listCitas = new List<Cita>();
			try
			{
				using (var dbContext = new ContextClinica())
				{	
					listCitas = dbContext.Database.SqlQuery<Cita>("dbo.USP_ValidarUsuarioAgencia ").ToList();
				}
			}
			catch (SqlException exc)
			{
				throw exc;
			}
			return listCitas;

		}
	}
}
