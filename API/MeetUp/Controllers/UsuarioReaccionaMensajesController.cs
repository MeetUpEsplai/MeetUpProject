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
    public class UsuarioReaccionaMensajesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioReaccionaMensajesController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Post and Get

        // POST: api/UsuarioReaccionaMensajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioReaccionaMensaje>> PostUsuarioReaccionaMensaje(UsuarioReaccionaMensajeViewModel model)
        {
            if (_context.UsuariosMensajes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UsuariosMensajes'  is null.");
            }
            UsuarioReaccionaMensaje reaccion = new UsuarioReaccionaMensaje();
            reaccion.AddModelInfo(model);

            _context.UsuariosMensajes.Add(reaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioReaccionaMensaje", new { id = reaccion.Id }, reaccion);
        }


        // PUT: api/UsuarioReaccionaMensajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutUsuarioReaccionaMensaje(int id, UsuarioReaccionaMensajeViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            UsuarioReaccionaMensaje? usuarioReaccionaMensaje = _context.UsuariosMensajes.Find(id);
            usuarioReaccionaMensaje.AddModelInfo(model);

            _context.Entry(usuarioReaccionaMensaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioReaccionaMensajeExists(id))
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

        // GET: api/UsuarioReaccionaMensajes/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<UsuarioReaccionaMensaje>> GetUsuarioReaccionaMensaje(int id)
        {
            if (_context.UsuariosMensajes == null)
            {
                return NotFound();
            }
            var usuarioReaccionaMensaje = await _context.UsuariosMensajes.FindAsync(id);

            if (usuarioReaccionaMensaje == null)
            {
                return NotFound();
            }

            return usuarioReaccionaMensaje;
        }


        // GET: api/UsuarioReaccionaMensajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReaccionaMensaje>>> GetUsuariosMensajes()
        {
            if (_context.UsuariosMensajes == null)
            {
                return NotFound();
            }
            return await _context.UsuariosMensajes.ToListAsync();
        }


        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("usuarioId_{usuarioId},mensajeId_{mensajeId},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<UsuarioReaccionaMensaje>> GetUsuarioReaccionaMensaje(int usuarioId, int mensajeId, int tipoReaccionId)
        {
            var usuarioReaccionaEvento = await _context.UsuariosMensajes
                .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId && u.MensajeId == mensajeId && u.TipoReaccionId == tipoReaccionId);

            if (usuarioReaccionaEvento == null)
            {
                return NotFound();
            }

            return usuarioReaccionaEvento;
        }


        // GET: api/UsuarioReaccionaComentarios/5
        [HttpGet("mensajeId_{mensajeId},tipoReaccionId_{tipoReaccionId}")]
        public async Task<ActionResult<int>> GetReaccionCount(int mensajeId, int tipoReaccionId)
        {
            if (_context.UsuariosMensajes == null)
            {
                return NotFound();
            }

            return _context.UsuariosMensajes.Count(urc => urc.TipoReaccionId == tipoReaccionId && urc.Mensaje.Id == mensajeId); ;
        }

        #endregion



        #region Delete

        // DELETE: api/UsuarioReaccionaMensajes/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteUsuarioReaccionaMensaje(int id)
        {
            if (_context.UsuariosMensajes == null)
            {
                return NotFound();
            }
            var usuarioReaccionaMensaje = await _context.UsuariosMensajes.FindAsync(id);
            if (usuarioReaccionaMensaje == null)
            {
                return NotFound();
            }

            _context.UsuariosMensajes.Remove(usuarioReaccionaMensaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool UsuarioReaccionaMensajeExists(int id)
        {
            return (_context.UsuariosMensajes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
