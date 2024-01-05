using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using XDEV_001_FRONT.Models;
using XDEV_001_FRONT.Utils;

namespace XDEV_001_FRONT.Controllers
{
    public class ProductoController : Controller
    {

        private readonly apiInterface _interfaz;


        public ProductoController(apiInterface interfaz)
        {
         
            _interfaz = interfaz;
        }

        public async Task<IActionResult> Index()
        {

            List<ProductoViewModel> lstProductos = new List<ProductoViewModel>();

            lstProductos = await _interfaz.GetProductos();
            return View(lstProductos);
        }

        private List<ProductoViewModel> ObtenerProductosDesdeAPI(string token)
        {
            return null;
        }
    }
}
