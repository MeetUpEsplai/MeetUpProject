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
    public class UsuarioReaccionaComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioReaccionaComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/UsuarioReaccionaComentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReaccionaComentario>>> GetUsuariosComentarios()
        {
          if (_context.UsuariosComentarios == null)
          {
              return NotFound();
          }
            return await _context.UsuariosComentarios.ToListAsync();
        }

        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("usuarioId_{usuarioId},comentarioId_{comentarioId},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<UsuarioReaccionaComentario>> GetUsuarioReaccionaComentario(int usuarioId, int comentarioId, int tipoReaccionId)
        {
            var usuarioReaccionaComentario = await _context.UsuariosComentarios
                .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId && u.ComentarioId == comentarioId && u.TipoReaccionId == tipoReaccionId);

            if (usuarioReaccionaComentario == null)
            {
                return NotFound();
            }

            return usuarioReaccionaComentario;
        }

        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("comentarioId_{idComentario},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<int>> GetReaccionCount(int idComentario, int tipoReaccionId)
        {
            if (_context.UsuariosComentarios == null)
            {
                return NotFound();
            }


            return _context.UsuariosComentarios.Count(urc => urc.TipoReaccionId == tipoReaccionId && urc.ComentarioId == idComentario); ;
        }

        #endregion

        #region Post and Put

        // PUT: api/UsuarioReaccionaComentarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutUsuarioReaccionaComentario(int id, UsuarioReaccionaComentario usuarioReaccionaComentario)
        {
            if (id != usuarioReaccionaComentario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioReaccionaComentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioReaccionaComentarioExists(id))
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

        // POST: api/UsuarioReaccionaComentarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioReaccionaComentario>> PostUsuarioReaccionaComentario(UsuarioReaccionaComentario usuarioReaccionaComentario)
        {
          if (_context.UsuariosComentarios == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UsuariosComentarios'  is null.");
          }
            _context.UsuariosComentarios.Add(usuarioReaccionaComentario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioReaccionaComentarioExists(usuarioReaccionaComentario.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioReaccionaComentario", new { id = usuarioReaccionaComentario.UsuarioId }, usuarioReaccionaComentario);
        }

        #endregion

        #region Delete

        // DELETE: api/UsuarioReaccionaComentarios/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteUsuarioReaccionaComentario(int id)
        {
            if (_context.UsuariosComentarios == null)
            {
                return NotFound();
            }
            var usuarioReaccionaComentario = await _context.UsuariosComentarios.FindAsync(id);
            if (usuarioReaccionaComentario == null)
            {
                return NotFound();
            }

            _context.UsuariosComentarios.Remove(usuarioReaccionaComentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private bool UsuarioReaccionaComentarioExists(int id)
        {
            return (_context.UsuariosComentarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }
    }
}
