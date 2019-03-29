using DATA.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Vista.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Paciente()
        {
            return View();
        }
		[HttpGet]

		public async Task<JsonResult> GetPacientes()
		{

			dynamic ListInfo = new JObject();
			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.GetAsync("api/cita/GetPaciente" );

			if (response.IsSuccessStatusCode)
			{
				if (JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"].Count() > 0)
				{
					ListInfo = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"];
				}
			}

			return Json(JsonConvert.SerializeObject(ListInfo), JsonRequestBehavior.AllowGet);
		}
		[HttpPost]

		public async Task<JsonResult> GestionarPaciente(Paciente pac)
		{

			dynamic ListInfo = new JObject();
			var paciente = await Task.Run(() => JsonConvert.SerializeObject(pac));
			var httpContent = new StringContent(paciente, Encoding.UTF8, "application/json");

			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.PostAsync("api/cita/GestionarPaciente", httpContent);

			if (response.IsSuccessStatusCode)
			{
				if (JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"].Count() > 0)
				{
					ListInfo = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"];
				}
			}

			return Json(JsonConvert.SerializeObject(ListInfo), JsonRequestBehavior.AllowGet);
		}
	}
}