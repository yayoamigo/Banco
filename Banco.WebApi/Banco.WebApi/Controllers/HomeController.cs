using Microsoft.AspNetCore.Mvc;
using Banco.WebApi.Entity;
using System.Linq;

namespace Banco.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly BancoContext _context;

        public HomeController(BancoContext context)
        {
            _context = context;
        }

        // GET: api/Home
        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(_context.Clientes.ToList());
        }

        // GET: api/Home/5
        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST: api/Home
        [HttpPost]
        public IActionResult PostCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteId }, cliente);
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.ClienteId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Home/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }
    }
}
