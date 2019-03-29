using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Models;
using DATA.Context;
using System.Data;

namespace DATA.Repository.Imp
{
	public class CitasRepository:ICitasRepository
	{
		public List<Cita> GetCitas()
		{
			List<Cita> listCitas = new List<Cita>();
			try
			{
				using (var dbContext = new ContextClinica())
				{	
					listCitas = dbContext.Database.SqlQuery<Cita>("USP_ListarCita ").ToList();
				}
			}
			catch (SqlException exc)
			{
				throw exc;
			}
			return listCitas;

		}
		public List<Tipo> GetTipo()
		{
			List<Tipo> listTipos = new List<Tipo>();
			try
			{
				using (var dbContext = new ContextClinica())
				{
					listTipos = dbContext.Database.SqlQuery<Tipo>("USP_ListarTipo ").ToList();
				}
			}
			catch (SqlException exc)
			{
				throw exc;
			}
			return listTipos;

		}
		public List<Tipo> GetListaPaciente()
		{
			List<Tipo> listTipos = new List<Tipo>();
			try
			{
				using (var dbContext = new ContextClinica())
				{
					listTipos = dbContext.Database.SqlQuery<Tipo>("USP_ListarPacientes").ToList();
				}
			}
			catch (SqlException exc)
			{
				throw exc;
			}
			return listTipos;

		}
		public List<Paciente> GetPaciente()
		{
			List<Paciente> list = new List<Paciente>();
			try
			{
				using (var dbContext = new ContextClinica())
				{
					list = dbContext.Database.SqlQuery<Paciente>("USP_ListarPaciente ").ToList();
				}
			}
			catch (SqlException exc)
			{
				throw exc;
			}
			return list;

		}
		public void GestionarPaciente(Paciente pac)
		{
			try
			{
				using (var dbContext = new ContextClinica())
				{
					SqlParameter @Nombre = new SqlParameter()
					{
						ParameterName = "@Nombre",
						DbType = DbType.String,
						Value = pac.Nombre
					};
					SqlParameter @cedula = new SqlParameter()
					{
						ParameterName = "@cedula",
						DbType = DbType.String,
						Value = pac.cedula
					};
					SqlParameter @telefono = new SqlParameter()
					{
						ParameterName = "@telefono",
						DbType = DbType.String,
						Value = pac.telefono
					};
					SqlParameter @oper = new SqlParameter()
					{
						ParameterName = "@oper",
						DbType = DbType.String,
						Value = pac.Accion
					};

					object[] parameters = new object[] { @Nombre,@cedula, @telefono, @oper };

					 dbContext.Database.ExecuteSqlCommand("dbo.USP_GestionarPaciente @Nombre,@cedula, @telefono, @oper", parameters);
				}
			}
			catch (SqlException exc)
			{
				throw exc;
			}	

		}
		public string CrearCita(Cita cita)
		{
			string resultado = null;
			try
			{
				using (var dbContext = new ContextClinica())
				{
					SqlParameter @Paciente = new SqlParameter()
					{
						ParameterName = "@Paciente",
						DbType = DbType.Int32,
						Value = cita.idPaciente
					};

					SqlParameter @tipo = new SqlParameter()
					{
						ParameterName = "@tipo",
						DbType = DbType.Int32,
						Value = cita.IdTipo
					};
					SqlParameter @fecha = new SqlParameter()
					{
						ParameterName = "@fecha",
						DbType = DbType.String,
						Value = cita.FechaCita
					};

					object[] parameters = new object[] { @Paciente, @tipo, @fecha };

					resultado = dbContext.Database.SqlQuery<string>("dbo.USP_CrearCita @Paciente, @tipo, @fecha", parameters).FirstOrDefault();
				}
			}
			catch (Exception exc)
			{
				throw exc;
			}
			return resultado;
		}
		public string CancelarCita(int id)
		{
			string resultado = null;
			try
			{
				using (var dbContext = new ContextClinica())
				{
					SqlParameter @idCita = new SqlParameter()
					{
						ParameterName = "@idCita",
						DbType = DbType.Int32,
						Value = id
					};


					object[] parameters = new object[] { @idCita };

					resultado = dbContext.Database.SqlQuery<string>("dbo.USP_CancelarCita @idCita", parameters).FirstOrDefault();
				}
			}
			catch (Exception exc)
			{
				throw exc;
			}
			return resultado;
		}
	}
}
