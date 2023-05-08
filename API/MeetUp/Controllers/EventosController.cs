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
    public class EventosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventosController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Post and Put

        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost()]
        public async Task<ActionResult<Evento>> PostEvento(EventoViewModel model)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Events'  is null.");
            }

            Evento evento = new Evento();
            evento.AddModelInfo(model);

            if (model.IdsEtiquetas != null)
            {
                evento.Etiquetas = new List<Etiqueta>();

                foreach (int id in model.IdsEtiquetas)
                {
                    evento.Etiquetas.Add(_context.Etiquetas.Find(id));
                }
            }

            _context.Events.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }


        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

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

        #endregion


        #region Get

        // GET: api/Eventos/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
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

            return evento;
        }


        // GET: api/Eventos
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEvents()
        {
            if (_context.Events == null)
            {
                return NotFound();
            }
            return await _context.Events.ToListAsync();
        }

        // GET: api/Eventos
        [HttpGet("etiquetaId_{id}")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventsByEtiqueta(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }

            if (_context.Etiquetas == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiquetas.FindAsync(id);

            List<Evento> todosLosEventos = await _context.Events.ToListAsync();
            List<Evento> eventosConEtiquetaCorrecta = new List<Evento>();

            foreach (Evento evento in todosLosEventos)
            {
                if (evento.Etiquetas.Contains(etiqueta))
                {
                    eventosConEtiquetaCorrecta.Add(evento);
                }
            }

            return eventosConEtiquetaCorrecta;
        }


        // GET: api/Eventos
        [HttpGet("usuarioId_{id}")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventsByUsuarioSuscrito(int id)
        {
            if (_context.Events == null)
            {
                return NotFound();
            }

            if (_context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);

            List<Evento> eventosSuscritosPorUser = new List<Evento>();

            foreach (UsuarioSuscribeEvento subscripciones in usuario.EventosSuscritos)
            {
                eventosSuscritosPorUser.Add(subscripciones.Evento);
            }

            return eventosSuscritosPorUser;
        }


        [HttpGet("nombre_{nombre}")]
        public async Task<ActionResult<List<Evento>>> BuscarEventosPorNombre(string nombre)
        {
            var eventos = await _context.Events
                .Where(e => e.Nombre.Contains(nombre))
                .ToListAsync();

            return eventos;
        }


        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("idEvento_{idEvento}")]
        public async Task<ActionResult<int>> GetSuscritosCount(int idEvento)
        {
            var evento = _context.Events.FirstOrDefault(e => e.Id == idEvento);

            if (evento == null)
            {
                return NotFound();
            }

            return evento.UsuariosSuscritos.Count;
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
