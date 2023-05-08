﻿using System;
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
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Post and Put

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioViewModel modelUsuario)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Usuarios'  is null.");
            }
            Usuario usuario = new Usuario();
            usuario.AddModelInfo(modelUsuario);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }


        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            Usuario? usuario = _context.Usuarios.Find(id);
            usuario.AddModelInfo(model);

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // GET: api/Usuarios/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }


        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            return await _context.Usuarios.ToListAsync();
        }


        [HttpGet("nombre_{nombre}")]
        public async Task<ActionResult<List<Usuario>>> BuscarUsuarioPorNombre(string nombre)
        {
            var usuario = await _context.Usuarios
                .Where(e => e.Nombre.Contains(nombre))
                .ToListAsync();

            return usuario;
        }


        [HttpGet("email_{email}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorEmail(string email)
        {
            var usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            return usuarioEncontrado;
        }

        #endregion


        #region Delete

        // DELETE: api/Usuarios/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
