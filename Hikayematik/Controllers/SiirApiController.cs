using Hikayematik.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hikayematik.Controllers
{
    public class SiirApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7113/api/");
        private readonly HttpClient _client;

        public SiirApiController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]

        //Index View'a gidecek kısmın kodu
        public IActionResult Index()
        {
            List<Siir> siir = new List<Siir>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Siirs/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                siir = JsonConvert.DeserializeObject<List<Siir>>(data);
            }
            return View(siir);
        }
        [HttpGet]
        //Bpş yeni kayıt sayfası oluşturacak.
        public IActionResult Create()
        {
            return View();

        }
        //Create ile gönderilen kayıtları api üzerinden kayıt ekleme işlemi yapıldı.
        [HttpPost]
        public IActionResult Create(Siir siir)
        {
            try
            {
                string data = JsonConvert.SerializeObject(siir);
                StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Siirs/Post", content).Result;
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex;
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Siir siir = new Siir();
                HttpResponseMessage reponse = _client.GetAsync(_client.BaseAddress + "/Siirs/Get" + id).Result;
                if (reponse.IsSuccessStatusCode)
                {
                    string data = reponse.Content.ReadAsStringAsync().Result;
                    siir = JsonConvert.DeserializeObject<Siir>(data);
                    View(siir);

                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Siir siir, int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Siirs/Delete" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "İşlem Başarılı";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Siir siir = new Siir();
                HttpResponseMessage reponse = _client.GetAsync(_client.BaseAddress + "/Siirs/Get" + id).Result;
                if (reponse.IsSuccessStatusCode)
                {
                    string data = reponse.Content.ReadAsStringAsync().Result;
                    siir = JsonConvert.DeserializeObject<Siir>(data);
                    View(siir);

                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Siir siir, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(siir);
                StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Siirs/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "İşlem Başarılı";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex;
                return View();
            }
            return View();
        }


    }
}
