using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUp.Modelos.Entidades;
using MeetUp.Context;

namespace MeetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatUsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/ChatUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatUsuarios>>> GetChatUsuarios()
        {
            if (_context.ChatUsuarios == null)
            {
                return NotFound();
            }
            return await _context.ChatUsuarios.ToListAsync();
        }

        // GET: api/ChatUsuarios/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<ChatUsuarios>> GetChatUsuarios(int id)
        {
            if (_context.ChatUsuarios == null)
            {
                return NotFound();
            }
            var chatUsuarios = await _context.ChatUsuarios.FindAsync(id);

            if (chatUsuarios == null)
            {
                return NotFound();
            }

            return chatUsuarios;
        }

        #endregion


        #region Post and Get

        // PUT: api/ChatUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutChatUsuarios(int id, ChatUsuarios chatUsuarios)
        {
            if (id != chatUsuarios.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(chatUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatUsuariosExists(id))
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

        // POST: api/ChatUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatUsuarios>> PostChatUsuarios(ChatUsuarios chatUsuarios)
        {
            if (_context.ChatUsuarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChatUsuarios'  is null.");
            }
            _context.ChatUsuarios.Add(chatUsuarios);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChatUsuariosExists(chatUsuarios.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChatUsuarios", new { id = chatUsuarios.UsuarioId }, chatUsuarios);
        }

        #endregion


        #region Delete

        // DELETE: api/ChatUsuarios/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteChatUsuarios(int id)
        {
            if (_context.ChatUsuarios == null)
            {
                return NotFound();
            }
            var chatUsuarios = await _context.ChatUsuarios.FindAsync(id);
            if (chatUsuarios == null)
            {
                return NotFound();
            }

            _context.ChatUsuarios.Remove(chatUsuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool ChatUsuariosExists(int id)
        {
            return (_context.ChatUsuarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }
    }
}
