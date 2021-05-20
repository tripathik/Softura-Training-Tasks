using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SBAccountClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SBAccountClient.Controllers
{
    public class SBAccounts : Controller
    {
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:46667/";
            var ProdInfo = new List<SBAccount>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/SBTransactions/GetAccounts");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   

                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProdInfo = JsonConvert.DeserializeObject<List<SBAccount>>(ProdResponse);

                }
                //returning the employee list to view  
                return View(ProdInfo);
            }
        }



        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SBAccount b)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:28109/api/SBAccounts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TempData["Id"] = id;
            int bid = Convert.ToInt32(TempData["Id"]);
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28109/api/SBAccounts/" + bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TempData["Id"] = id;
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28109/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(SBAccount b)
        {
            int bid = Convert.ToInt32(TempData["Id"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:28109/api/SBAccounts/" + bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            TempData["Id"] = id;
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:28109/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]

        public async Task<ActionResult> Edit(SBAccount b)
        {

            int bid = Convert.ToInt32(TempData["Id"]);
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:28109/api/SBAccounts/" + bid, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);

                }
            }
            return RedirectToAction("Index");
        }
    }
}
