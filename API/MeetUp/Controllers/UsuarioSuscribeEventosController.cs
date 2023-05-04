using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUp.Context;
using MeetUp.Modelos;
using MeetUp.Modelos.ViewModels;
using System.Reflection.PortableExecutable;

namespace MeetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioSuscribeEventosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioSuscribeEventosController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Post and Put

        // POST: api/UsuarioSuscribeEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioSuscribeEvento>> PostUsuarioSuscribeEvento(UsuarioSuscribeEventoViewModel model)
        {
            if (_context.UsuarioSuscribeEvento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UsuarioSuscribeEvento'  is null.");
            }

            UsuarioSuscribeEvento suscripcion = new UsuarioSuscribeEvento();
            suscripcion.AddModelInfo(model);

            _context.UsuarioSuscribeEvento.Add(suscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioSuscribeEvento", new { id = suscripcion.Id }, suscripcion);
        }


        // PUT: api/UsuarioSuscribeEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioSuscribeEvento(int id, UsuarioSuscribeEvento usuarioSuscribeEvento)
        {
            if (id != usuarioSuscribeEvento.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioSuscribeEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioSuscribeEventoExists(id))
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

        #endregion


        #region Get

        // GET: api/UsuarioSuscribeEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioSuscribeEvento>> GetUsuarioSuscribeEvento(int id)
        {
            if (_context.UsuarioSuscribeEvento == null)
            {
                return NotFound();
            }
            var usuarioSuscribeEvento = await _context.UsuarioSuscribeEvento.FindAsync(id);

            if (usuarioSuscribeEvento == null)
            {
                return NotFound();
            }

            return usuarioSuscribeEvento;
        }


        // GET: api/UsuarioSuscribeEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioSuscribeEvento>>> GetUsuarioSuscribeEvento()
        {
            if (_context.UsuarioSuscribeEvento == null)
            {
                return NotFound();
            }
            return await _context.UsuarioSuscribeEvento.ToListAsync();
        }

        #endregion


        #region Delete

        // DELETE: api/UsuarioSuscribeEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioSuscribeEvento(int id)
        {
            if (_context.UsuarioSuscribeEvento == null)
            {
                return NotFound();
            }
            var usuarioSuscribeEvento = await _context.UsuarioSuscribeEvento.FindAsync(id);
            if (usuarioSuscribeEvento == null)
            {
                return NotFound();
            }

            _context.UsuarioSuscribeEvento.Remove(usuarioSuscribeEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool UsuarioSuscribeEventoExists(int id)
        {
            return (_context.UsuarioSuscribeEvento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
