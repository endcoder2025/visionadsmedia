using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using visionadsmedia.Data;
using visionadsmedia.DTOs;
using visionadsmedia.Models;

namespace visionadsmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ContactsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            var contacts = await _db.Contacts
                .OrderByDescending(c => c.Id)
                .ToListAsync();

            return Ok(contacts);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contact>> GetById(int id)
        {
            var contact = await _db.Contacts.FindAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> Create([FromBody] ContactCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contact = new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Message = dto.Message
            };

            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }
    }
}
