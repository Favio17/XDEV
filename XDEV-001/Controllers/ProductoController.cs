using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XDEV_001.Models;

namespace XDEV_001.Controllers
{
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        XdevContext _context = new XdevContext();


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(_context.TbProductos.ToList());
        }

        [HttpGet]
        [Route("GetProductByCode")]
        public async Task<IActionResult> GetProductByCode(int codProducto)
        {
            return Ok(_context.TbProductos.Where(e => e.CodProducto == codProducto).FirstOrDefault());
        }
    }
}
