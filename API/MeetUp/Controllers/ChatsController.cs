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
    public class ChatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/Chats
        /// <summary>
        /// Recoge todos los chats de la base de datos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
          if (_context.Chats == null)
          {
              return NotFound();
          }
            return await _context.Chats
                .Include(x => x.ChatUsuarios)
                .Include(x => x.Mensajes)
                .ToListAsync();
        }


        // GET: api/Chats/5
        /// <summary>
        /// Recoge un chat por id
        /// </summary>
        /// <param name="id">Id del chat</param>
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
          if (_context.Chats == null)
          {
              return NotFound();
          }
            var chat = _context.Chats
                .Include(x => x.ChatUsuarios)
                .Include(x => x.Mensajes)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        #endregion


        #region Post and Put

        // PUT: api/Chats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Actualiza un chat por id
        /// </summary>
        /// <param name="id">Id del chat a cambiar</param>
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutChat(int id, ChatViewModel modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }

            Chat chat = _context.Chats.Find(id);
            chat.AddModelInfo(modelo);

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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


        // POST: api/Chats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Añade un chat
        /// </summary>
        /// <param name="id">Id del chat a añadir</param>
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(ChatViewModel model)
        {
          if (_context.Chats == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Chats'  is null.");
          }
            Chat chat = new Chat();
            chat.AddModelInfo(model);

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.Id }, chat);
        }

        #endregion


        #region Delete

        // DELETE: api/Chats/5
        /// <summary>
        /// Elimina un chat por id
        /// </summary>
        /// <param name="id">Id del chat a eliminar</param>
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            if (_context.Chats == null)
            {
                return NotFound();
            }
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private bool ChatExists(int id)
        {
            return (_context.Chats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
