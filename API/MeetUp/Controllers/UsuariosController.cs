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
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/Usuarios
        /// <summary>
        /// Recoge todos los usuarios de la base de datos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios
                .Include(x => x.Mensajes)
                .Include(x => x.Eventos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaComentarios)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.ChatUsuarios)
                .ToListAsync();
        }

        // GET: api/Usuarios/5
        /// <summary>
        /// Recoge un usuario por id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios
                .Include(x => x.Mensajes)
                .Include(x => x.Eventos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaComentarios)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.ChatUsuarios)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        /// <summary>
        /// Recoge un usuario por su nombre
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        [HttpGet("nombre_{nombre}")]
        public async Task<ActionResult<List<Usuario>>> BuscarUsuarioPorNombre(string nombre)
        {
            var usuario = await _context.Usuarios
                .Include(x => x.Mensajes)
                .Include(x => x.Eventos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaComentarios)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.ChatUsuarios)
                .Where(e => e.Nombre.Contains(nombre))
                .ToListAsync();

            return usuario;
        }

        /// <summary>
        /// Recoge un usuario por su correo
        /// </summary>
        /// <param name="email">Correo del usuario</param>
        [HttpGet("email_{email}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorEmail(string email)
        {
            var usuarioEncontrado = await _context.Usuarios
                .Include(x => x.Mensajes)
                .Include(x => x.Eventos)
                .Include(x => x.Comentarios)
                .Include(x => x.UsuarioSuscribeEventos)
                .Include(x => x.UsuarioReaccionaComentarios)
                .Include(x => x.UsuarioReaccionaEventos)
                .Include(x => x.ChatUsuarios)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            return usuarioEncontrado;
        }

        #endregion


        #region Post and Put

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        /// <summary>
        /// Actualiza el usuario por la id 
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="model">Objeto usuario nuevo</param>
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            Usuario usuario = _context.Usuarios.Find(id);
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        /// <summary>
        /// Añade un usuario a la base de datos
        /// </summary>
        /// <param name="model">Usuario nuevo</param>
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioViewModel model)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Usuarios'  is null.");
          }

            Usuario usuario = new Usuario();
            usuario.AddModelInfo(model);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        #endregion


        #region Delete

        // DELETE: api/Usuarios/5

        /// <summary>
        /// Elimina un usuario por la id 
        /// </summary>
        /// <param name="id">Id del usuario</param>
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
