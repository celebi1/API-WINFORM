using System.Linq;
using CODESWEBAPI;  // ApiContext'i içe aktarın
using CODESWEBAPI.Models;  // Personel modelini içe aktarın
using Microsoft.AspNetCore.Mvc;

namespace CODESWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly ApiContext _context;

        public PersonelController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            // Personel listesini döndürün
            return Ok(_context.Personels.ToList());
        }
    }
}
