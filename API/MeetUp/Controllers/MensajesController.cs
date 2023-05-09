using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUp.Context;
using MeetUp.Modelos.Entidades;

namespace MeetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MensajesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/Mensajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensaje>>> GetMensajes()
        {
          if (_context.Mensajes == null)
          {
              return NotFound();
          }
            return await _context.Mensajes.ToListAsync();
        }

        // GET: api/Mensajes/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Mensaje>> GetMensaje(int id)
        {
          if (_context.Mensajes == null)
          {
              return NotFound();
          }
            var mensaje = await _context.Mensajes.FindAsync(id);

            if (mensaje == null)
            {
                return NotFound();
            }

            return mensaje;
        }

        #endregion

        #region Post and Put

        // PUT: api/Mensajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutMensaje(int id, Mensaje mensaje)
        {
            if (id != mensaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(mensaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensajeExists(id))
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

        // POST: api/Mensajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mensaje>> PostMensaje(Mensaje mensaje)
        {
          if (_context.Mensajes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Mensajes'  is null.");
          }
            _context.Mensajes.Add(mensaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMensaje", new { id = mensaje.Id }, mensaje);
        }

        #endregion


        #region Delete

        // DELETE: api/Mensajes/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteMensaje(int id)
        {
            if (_context.Mensajes == null)
            {
                return NotFound();
            }
            var mensaje = await _context.Mensajes.FindAsync(id);
            if (mensaje == null)
            {
                return NotFound();
            }

            _context.Mensajes.Remove(mensaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private bool MensajeExists(int id)
        {
            return (_context.Mensajes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
