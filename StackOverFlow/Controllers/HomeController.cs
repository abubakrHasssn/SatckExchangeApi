using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using StackOverFlow.Models;
using Newtonsoft.Json;

namespace StackOverFlow.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var httpClient = new HttpClient(handler))
            {
                var apiUrl = ("https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=activity&site=stackoverflow");

                //setup HttpClient
                httpClient.BaseAddress = new Uri(apiUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //make request
                var response = await httpClient.GetStringAsync(apiUrl);

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);

                ViewBag.items = myDeserializedClass.items;
                
            }
            return View();
        }

    
        public async Task<ActionResult> ViewQuestion(int id)
        {

            int quesid = id;
                HttpClientHandler handler = new HttpClientHandler();
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (var httpClient = new HttpClient(handler))
                {
                    var apiUrl = ("https://api.stackexchange.com/2.2/questions/"+id+"?site=stackoverflow&filter=!9_bDDxJY5");
                    //setup HttpClient
                    httpClient.BaseAddress = new Uri(apiUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //make request
                    var response = await httpClient.GetStringAsync(apiUrl);
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
                    ViewBag.items = myDeserializedClass.items;
                }
            return View();
        }  
    }
}