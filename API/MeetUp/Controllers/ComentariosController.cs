using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUp.Context;
using MeetUp.Modelos.Entidades;
using MeetUp.Modelos.ViewModels;

namespace MeetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/Comentarios
        /// <summary>
        /// Recoge todos los comentarios de la base de datos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
          if (_context.Comentarios == null)
          {
              return NotFound();
          }
            return await _context.Comentarios
                .Include(x => x.ComentariosHijos)
                .ToListAsync();
        }

        // GET: api/Comentarios/5
        /// <summary>
        /// Recoge un comentario por id
        /// </summary>
        /// <param name="id">Id del comentario</param>
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
          if (_context.Comentarios == null)
          {
              return NotFound();
          }
            var comentario = await _context.Comentarios
                .Include(x => x.ComentariosHijos)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        #endregion


        #region Post and Put

        // PUT: api/Comentarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Actualiza un comentario por id
        /// </summary>
        /// <param name="id">Id del comentario a cambiar</param>
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutComentario(int id, ComentarioViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            Comentario comentario = _context.Comentarios.Where(x => x.Id == id).FirstOrDefault();
            comentario.AddModelInfo(model);

            _context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/Comentarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Añade un comentario
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(ComentarioViewModel model)
        {
          if (_context.Comentarios == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Comentarios'  is null.");
          }
            Comentario comentario = new Comentario();
            comentario.AddModelInfo(model);

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { id = comentario.Id }, comentario);
        }

        #endregion


        #region Delete

        // DELETE: api/Comentarios/5
        /// <summary>
        /// Elimina un comentario por id
        /// </summary>
        /// <param name="id">Id del comentario a eliminar</param>
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            if (_context.Comentarios == null)
            {
                return NotFound();
            }
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private bool ComentarioExists(int id)
        {
            return (_context.Comentarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
