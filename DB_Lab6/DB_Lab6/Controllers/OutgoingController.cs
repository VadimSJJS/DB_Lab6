using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Models;

namespace DB_Lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutgoingController : Controller
    {
        PharmacyContext db;
        public OutgoingController(PharmacyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Outgoing> Get()
        {
            var result = db.Outgoings
                .Include(e => e.Medicine)
                .Include(e => e.Medicine.Producer)
                .ToList();
            return result;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Outgoing outgoing = db.Outgoings
                .Include(e => e.Medicine)
                .Include(e => e.Medicine.Producer)
                .FirstOrDefault(x => x.Id == id);

            if (outgoing == null)
                return NotFound();
            return new ObjectResult(outgoing);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] Outgoing outgoing)
        {
            if (outgoing == null)
            {
                return BadRequest();
            }

            db.Outgoings.Add(outgoing);
            db.SaveChanges();
            return Ok(outgoing);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody] Outgoing outgoing)
        {
            if (outgoing == null)
            {
                return BadRequest();
            }
            if (!db.Outgoings.Any(x => x.Id == outgoing.Id))
            {
                return NotFound();
            }

            db.Update(outgoing);
            db.SaveChanges();
            return Ok(outgoing);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Outgoing outgoing = db.Outgoings.FirstOrDefault(x => x.Id == id);
            if (outgoing == null)
            {
                return NotFound();
            }
            db.Outgoings.Remove(outgoing);
            db.SaveChanges();
            return Ok(outgoing);
        }

        [HttpGet("medicine")]
        [Produces("application/json")]
        public IEnumerable<Medicine> GetMedicines()
        {
            return db.Medicines.ToList();
        }

        [HttpGet("producer")]
        [Produces("application/json")]
        public IEnumerable<Producer> GetProducers()
        {
            return db.Producers.ToList();
        }
    }

}