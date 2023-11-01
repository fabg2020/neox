using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neox.Data;
using Neox.Models;

namespace Neox.SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly NeoxContext _context;

        public ClientsController(NeoxContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClients()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClient(long id)
        {
            var cli = await _context.Clientes.FindAsync(id);

            if (cli == null)
            {
                return NotFound();
            }

            return cli;
        }

        // PUT: api/Cliente/Id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(long id, Cliente cli)
        {
            if (id != cli.Id)
            {
                return BadRequest();
            }

            _context.Entry(cli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Existe(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cliente/Id
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostClient(Cliente cli)
        {
            _context.Clientes.Add(cli);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Existe(cli.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClient", new { id = cli.Id }, cli);
        }

        // DELETE: api/Cliente/Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            var cli = await _context.Clientes.FindAsync(id);
            if (cli == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cli);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Existe(long id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

     
    }
}
