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
    public class TipoReaccionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoReaccionesController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Post and Put

        // POST: api/TipoReacciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost()]
        public async Task<ActionResult<TipoReaccion>> PostTipoReaccion(TipoReaccionViewModel model)
        {
            if (_context.TipoReacciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoReacciones'  is null.");
            }
            TipoReaccion tipoReaccion = new TipoReaccion();
            tipoReaccion.AddModelInfo(model);

            _context.TipoReacciones.Add(tipoReaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoReaccion", new { id = tipoReaccion.Id }, tipoReaccion);
        }


        // PUT: api/TipoReacciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutTipoReaccion(int id, TipoReaccionViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            TipoReaccion? tipoReaccion = _context.TipoReacciones.Find(id);
            tipoReaccion.AddModelInfo(model);

            _context.Entry(tipoReaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoReaccionExists(id))
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

        // GET: api/TipoReacciones/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<TipoReaccion>> GetTipoReaccion(int id)
        {
            if (_context.TipoReacciones == null)
            {
                return NotFound();
            }
            var tipoReaccion = await _context.TipoReacciones.FindAsync(id);

            if (tipoReaccion == null)
            {
                return NotFound();
            }

            return tipoReaccion;
        }


        // GET: api/TipoReacciones
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TipoReaccion>>> GetTipoReacciones()
        {
            if (_context.TipoReacciones == null)
            {
                return NotFound();
            }
            return await _context.TipoReacciones.ToListAsync();
        }

        #endregion


        #region Delete

        // DELETE: api/TipoReacciones/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteTipoReaccion(int id)
        {
            if (_context.TipoReacciones == null)
            {
                return NotFound();
            }
            var tipoReaccion = await _context.TipoReacciones.FindAsync(id);
            if (tipoReaccion == null)
            {
                return NotFound();
            }

            _context.TipoReacciones.Remove(tipoReaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool TipoReaccionExists(int id)
        {
            return (_context.TipoReacciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
