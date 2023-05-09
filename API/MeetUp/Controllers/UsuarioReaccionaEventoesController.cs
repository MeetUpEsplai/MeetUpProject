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
    public class UsuarioReaccionaEventoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioReaccionaEventoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/UsuarioReaccionaEventoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReaccionaEvento>>> GetUsuariosaEventos()
        {
          if (_context.UsuariosaEventos == null)
          {
              return NotFound();
          }
            return await _context.UsuariosaEventos.ToListAsync();
        }

        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("usuarioId_{usuarioId},eventoId_{eventoId},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<UsuarioReaccionaEvento>> GetUsuarioReaccionaEvento(int usuarioId, int eventoId, int tipoReaccionId)
        {
            var usuarioReaccionaEvento = await _context.UsuariosaEventos
                .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId && u.EventoId == eventoId && u.TipoReaccionId == tipoReaccionId);

            if (usuarioReaccionaEvento == null)
            {
                return NotFound();
            }

            return usuarioReaccionaEvento;
        }

        [HttpGet("eventoId_{eventoId},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<int>> GetReaccionCount(int eventoId, int tipoReaccionId)
        {
            if (_context.UsuariosaEventos == null)
            {
                return NotFound();
            }

            return _context.UsuariosaEventos.Count(urc => urc.TipoReaccionId == tipoReaccionId && urc.EventoId == eventoId); ;
        }


        #endregion

        #region Post and Put

        // PUT: api/UsuarioReaccionaEventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutUsuarioReaccionaEvento(int id, UsuarioReaccionaEvento usuarioReaccionaEvento)
        {
            if (id != usuarioReaccionaEvento.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioReaccionaEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioReaccionaEventoExists(id))
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

        // POST: api/UsuarioReaccionaEventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioReaccionaEvento>> PostUsuarioReaccionaEvento(UsuarioReaccionaEvento usuarioReaccionaEvento)
        {
          if (_context.UsuariosaEventos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UsuariosaEventos'  is null.");
          }
            _context.UsuariosaEventos.Add(usuarioReaccionaEvento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioReaccionaEventoExists(usuarioReaccionaEvento.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioReaccionaEvento", new { id = usuarioReaccionaEvento.UsuarioId }, usuarioReaccionaEvento);
        }

        #endregion

        #region Delete

        // DELETE: api/UsuarioReaccionaEventoes/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteUsuarioReaccionaEvento(int id)
        {
            if (_context.UsuariosaEventos == null)
            {
                return NotFound();
            }
            var usuarioReaccionaEvento = await _context.UsuariosaEventos.FindAsync(id);
            if (usuarioReaccionaEvento == null)
            {
                return NotFound();
            }

            _context.UsuariosaEventos.Remove(usuarioReaccionaEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
        private bool UsuarioReaccionaEventoExists(int id)
        {
            return (_context.UsuariosaEventos?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }
    }
}
