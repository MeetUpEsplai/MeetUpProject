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

namespace MeetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioReaccionaEventosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioReaccionaEventosController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Post and Put

        // POST: api/UsuarioReaccionaEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioReaccionaEvento>> PostUsuarioReaccionaEvento(UsuarioReaccionaEventoViewModel model)
        {
            if (_context.UsuariosaEventos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UsuariosaEventos'  is null.");
            }

            UsuarioReaccionaEvento reaccion = new UsuarioReaccionaEvento();
            reaccion.AddModelInfo(model);

            _context.UsuariosaEventos.Add(reaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioReaccionaEvento", new { id = reaccion.Id }, reaccion);
        }


        // PUT: api/UsuarioReaccionaEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutUsuarioReaccionaEvento(int id, UsuarioReaccionaEventoViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            UsuarioReaccionaEvento? usuarioReaccionaEvento = _context.UsuariosaEventos.Find(id);
            usuarioReaccionaEvento.AddModelInfo(model);

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

        #endregion


        #region Get

        // GET: api/UsuarioReaccionaEventos/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<UsuarioReaccionaEvento>> GetUsuarioReaccionaEvento(int id)
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

            return usuarioReaccionaEvento;
        }


        // GET: api/UsuarioReaccionaEventos
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


        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("eventoId_{eventoId},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<int>> GetReaccionCount(int eventoId, int tipoReaccionId)
        {
            if (_context.UsuariosaEventos == null)
            {
                return NotFound();
            }

            return _context.UsuariosaEventos.Count(urc => urc.TipoReaccionId == tipoReaccionId && urc.Evento.Id == eventoId); ;
        }

        #endregion


        #region Delete 

        // DELETE: api/UsuarioReaccionaEventos/5
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
            return (_context.UsuariosaEventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
