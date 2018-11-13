using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using reCAPTCHAv3.netCore.Models;

namespace reCAPTCHAv3.netCore.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string _googleVerifyAddress = "https://www.google.com/recaptcha/api/siteverify";

        private readonly string _googleRecaptchaSecret = "reCAPTCHA_server_key";

        public HomeController(IHttpClientFactory httpClientFactory){
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<JsonResult> RecaptchaV3Vverify(string token)
        {
            TokenResponse tokenResponse  = new TokenResponse()
            {
                Success = false
            };

            using (var client = _httpClientFactory.CreateClient())
            {
                var response = await client.GetStringAsync($"{_googleVerifyAddress}?secret={_googleRecaptchaSecret}&response={token}");
                tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response);
            }           

            return Json(tokenResponse);
        }
    }
}
