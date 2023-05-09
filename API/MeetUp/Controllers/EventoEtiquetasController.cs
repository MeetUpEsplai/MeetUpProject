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
    public class EventoEtiquetasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventoEtiquetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/EventoEtiquetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoEtiquetas>>> GetEventoEtiquetas()
        {
          if (_context.EventoEtiquetas == null)
          {
              return NotFound();
          }
            return await _context.EventoEtiquetas.ToListAsync();
        }


        // GET: api/EventoEtiquetas/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<EventoEtiquetas>> GetEventoEtiquetas(int id)
        {
          if (_context.EventoEtiquetas == null)
          {
              return NotFound();
          }
            var eventoEtiquetas = await _context.EventoEtiquetas.FindAsync(id);

            if (eventoEtiquetas == null)
            {
                return NotFound();
            }

            return eventoEtiquetas;
        }

        #endregion


        #region Post and Put

        // PUT: api/EventoEtiquetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutEventoEtiquetas(int id, EventoEtiquetas eventoEtiquetas)
        {
            if (id != eventoEtiquetas.EtiquetaId)
            {
                return BadRequest();
            }

            _context.Entry(eventoEtiquetas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoEtiquetasExists(id))
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

        // POST: api/EventoEtiquetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoEtiquetas>> PostEventoEtiquetas(EventoEtiquetas eventoEtiquetas)
        {
          if (_context.EventoEtiquetas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.EventoEtiquetas'  is null.");
          }
            _context.EventoEtiquetas.Add(eventoEtiquetas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventoEtiquetasExists(eventoEtiquetas.EtiquetaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventoEtiquetas", new { id = eventoEtiquetas.EtiquetaId }, eventoEtiquetas);
        }

        #endregion


        #region Delete

        // DELETE: api/EventoEtiquetas/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteEventoEtiquetas(int id)
        {
            if (_context.EventoEtiquetas == null)
            {
                return NotFound();
            }
            var eventoEtiquetas = await _context.EventoEtiquetas.FindAsync(id);
            if (eventoEtiquetas == null)
            {
                return NotFound();
            }

            _context.EventoEtiquetas.Remove(eventoEtiquetas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool EventoEtiquetasExists(int id)
        {
            return (_context.EventoEtiquetas?.Any(e => e.EtiquetaId == id)).GetValueOrDefault();
        }
    }
}
