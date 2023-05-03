﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUp.Context;
using MeetUp.Modelos;

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

        // GET: api/UsuarioReaccionaMensajes/5
        [HttpGet("{id}")]
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

        // PUT: api/UsuarioReaccionaMensajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioReaccionaMensaje(int id, UsuarioReaccionaMensaje usuarioReaccionaMensaje)
        {
            if (id != usuarioReaccionaMensaje.Id)
            {
                return BadRequest();
            }

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

        // POST: api/UsuarioReaccionaMensajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioReaccionaMensaje>> PostUsuarioReaccionaMensaje(UsuarioReaccionaMensaje usuarioReaccionaMensaje)
        {
          if (_context.UsuariosMensajes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UsuariosMensajes'  is null.");
          }
            _context.UsuariosMensajes.Add(usuarioReaccionaMensaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioReaccionaMensaje", new { id = usuarioReaccionaMensaje.Id }, usuarioReaccionaMensaje);
        }

        // DELETE: api/UsuarioReaccionaMensajes/5
        [HttpDelete("{id}")]
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

        private bool UsuarioReaccionaMensajeExists(int id)
        {
            return (_context.UsuariosMensajes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
