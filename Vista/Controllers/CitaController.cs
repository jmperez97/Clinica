using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DATA.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vista.Controllers
{
    public class CitaController : Controller
    {
		// GET: Cita
		public async Task<ActionResult> cita()
        {
			var model = new Vista.Models.cita();
			model.ListTipo = await getTipo();
			model.listPac = await GetListaPaciente();

			return View(model);
        }

		[HttpGet]

		private async Task<List<SelectListItem>> getTipo()
		{
			List<SelectListItem> list = new List<SelectListItem>();
			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.GetAsync("api/cita/GetTipos");

			if (response.IsSuccessStatusCode)
			{
				var resultResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"];
				foreach (var item in resultResponse)
				{
					list.Add(new SelectListItem() { Text = item["ID"].ToString(), Value = item["Nombre"].ToString() });
				}
			}

			return list;
		}
		[HttpGet]

		private async Task<List<SelectListItem>> GetListaPaciente()
		{
			List<SelectListItem> list = new List<SelectListItem>();
			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.GetAsync("api/cita/GetListaPaciente");

			if (response.IsSuccessStatusCode)
			{
				var resultResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"];
				foreach (var item in resultResponse)
				{
					list.Add(new SelectListItem() { Text = item["ID"].ToString(), Value = item["Nombre"].ToString() });
				}
			}

			return list;
		}
		[HttpGet]
		public async Task<JsonResult> GetCitas()
		{

			dynamic ListInfo = new JObject();
			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.GetAsync("api/cita/GetCitas");

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

		public async Task<JsonResult> Agendar(Cita cit)
		{

			dynamic ListInfo = new JObject();
			var cita = await Task.Run(() => JsonConvert.SerializeObject(cit));
			var httpContent = new StringContent(cita, Encoding.UTF8, "application/json");

			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.PostAsync("api/cita/Agendar", httpContent);

			if (response.IsSuccessStatusCode)
			{
				ListInfo = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"];
			}

			return Json(JsonConvert.SerializeObject(ListInfo), JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public async Task<JsonResult> Cancelar(string id)
		{

			dynamic ListInfo = new JObject();
			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			var response = await client.GetAsync("api/cita/Cancelar?id=" + id);

			if (response.IsSuccessStatusCode)
			{
				ListInfo = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Objeto"];
			}

			return Json(JsonConvert.SerializeObject(ListInfo), JsonRequestBehavior.AllowGet);
		}
	}
}