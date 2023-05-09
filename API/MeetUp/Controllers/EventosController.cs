using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUp.Modelos.Entidades;
using MeetUp.Modelos.ViewModels;
using MeetUp.Context;

namespace MeetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventosController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEvents()
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            return await _context.Events
                .Include(x => x.Fotos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.EventoEtiquetas)
                .ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var evento = await _context.Events
                .Include(x => x.Fotos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.EventoEtiquetas)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }


        // GET: api/Eventos
        [HttpGet("usuarioId_{id}")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventsByUser(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }

            if (_context.Usuarios == null)
            {
                return NotFound();
            }

            List<Evento> eventosConUsuarioCorrecto = null;

            if (_context.Usuarios.Where(x => x.Id == id).Any())
            {
                eventosConUsuarioCorrecto = _context.Events
                    .Include(x => x.Fotos)
                    .Include(x => x.Comentarios)
                    .Include(x => x.UsuarioReaccionaEventos)
                    .Include(x => x.EventoEtiquetas)
                    .Include(e => e.UsuarioSuscribeEventos)
                    .Where(e => e.UsuarioSuscribeEventos.Any(ee => ee.UsuarioId == id))
                    .ToList();
            }

            return eventosConUsuarioCorrecto;
        }

        [HttpGet("nombre_{nombre}")]
        public async Task<ActionResult<List<Evento>>> BuscarEventosPorNombre(string nombre)
        {
            var eventos = await _context.Events
                .Include(x => x.Fotos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.EventoEtiquetas)
                .Where(e => e.Nombre.Contains(nombre))
                .ToListAsync();

            return eventos;
        }

        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("eventoId_{idEvento}")]
        public async Task<ActionResult<int>>? GetSuscritosCount(int idEvento)
        {
            var evento = _context.Events.FirstOrDefault(e => e.Id == idEvento);

            if (evento == null)
            {
                return NotFound();
            }

            if (evento.UsuarioSuscribeEventos != null)
                return evento.UsuarioSuscribeEventos.Count;
            else
                return 0;
        }

        #endregion


        #region Post and Put

        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutEvento(int id, EventoViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            Evento evento = _context.Events.Find(id);
            evento.AddModelInfo(model);

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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


        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(EventoViewModel model)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Events'  is null.");
            }
            Evento evento = new Evento();
            evento.AddModelInfo(model);

            _context.Events.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        #endregion


        #region Delete

        // DELETE: api/Eventos/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            var evento = await _context.Events.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private bool EventoExists(int id)
        {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
