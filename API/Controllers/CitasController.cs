using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DATA.Repository;
using DATA.Repository.Imp;
using System.Web.Http;
using DATA.Models;


namespace API.Controllers
{
	[RoutePrefix("api/Cita")]
	public class CitasController : ApiController
    {
		[HttpGet]
		[Route("GetCitas")]
		public async Task<IHttpActionResult> GetCitas()
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				var result = iCitasRepository.GetCitas();

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = result;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}
		[HttpGet]
		[Route("GetTipos")]
		public async Task<IHttpActionResult> GetTipos()
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				var result = iCitasRepository.GetTipo();

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = result;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}
		[HttpGet]
		[Route("GetListaPaciente")]
		public async Task<IHttpActionResult> GetListaPaciente()
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				var result = iCitasRepository.GetListaPaciente();

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = result;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}
		[HttpGet]
		[Route("GetPaciente")]
		public async Task<IHttpActionResult> GetPaciente()
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				var result = iCitasRepository.GetPaciente();

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = result;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}

		[HttpPost]
		[Route("GestionarPaciente")]
		public async Task<IHttpActionResult> GestionarPaciente(Paciente pac)
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				iCitasRepository.GestionarPaciente(pac);

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = true;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}

		[HttpPost]
		[Route("Agendar")]
		public async Task<IHttpActionResult> CrearCita(Cita cit)
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				var res = iCitasRepository.CrearCita(cit);

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = res;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}
		[HttpGet]
		[Route("Cancelar")]
		public async Task<IHttpActionResult> CancelarCita(string id)
		{
			try
			{
				ICitasRepository iCitasRepository;
				iCitasRepository = new CitasRepository();
				var result = iCitasRepository.CancelarCita(Convert.ToInt32(id));

				MessageResult messageResult = new MessageResult();
				messageResult.Objeto = result;
				messageResult.Status = HttpStatusCode.OK;
				return Ok(messageResult);

			}
			catch (Exception exc)
			{

				throw exc;
			}
		}
	}
}
