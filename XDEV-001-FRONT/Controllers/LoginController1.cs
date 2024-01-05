using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XDEV_001_FRONT.Models;
using Newtonsoft.Json;
using XDEV_001_FRONT.Utils;

namespace XDEV_001_FRONT.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly apiInterface _interfaz;


        public LoginController(IHttpClientFactory httpClientFactory, apiInterface interfaz)
        {
            _httpClientFactory = httpClientFactory;
            _interfaz = interfaz;   
        }

        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

           return View("Index", model);
        }
    }
}
