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
        [HttpPost]
        public IActionResult AddPersonel([FromBody] Personel personel)
        {
            if (personel == null)
            {
                return BadRequest("Personel bilgileri eksik.");
            }
            _context.Personels.Add(personel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetList), new { id = personel.ID }, personel);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePersonel(int id)
        {
            var personel = _context.Personels.Find(id);
            if (personel == null)
            {
                return NotFound("Personel bulunamadı.");
            }
            _context.Personels.Remove(personel);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePersonel(int id, [FromBody] Personel personel)
        {
            if (personel == null || personel.ID != id)
            {
                return BadRequest("Personel bilgileri eksik veya ID uyuşmuyor.");
            }
            var existingPersonel = _context.Personels.Find(id);
            if (existingPersonel == null)
            {
                return NotFound("Personel bulunamadı.");
            }
            existingPersonel.AD = personel.AD;
            existingPersonel.SOYAD = personel.SOYAD;
            existingPersonel.MAIL = personel.MAIL;
            existingPersonel.TELEFON = personel.TELEFON;
            existingPersonel.TC = personel.TC;
            existingPersonel.IL = personel.TC;
            existingPersonel.ILCE = personel.ILCE;
            existingPersonel.ADRES = personel.ADRES;
            existingPersonel.GOREV  = personel.GOREV;
            _context.Personels.Update(existingPersonel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
