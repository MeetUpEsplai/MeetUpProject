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
    public class EtiquetasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtiquetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Post and Put

        // POST: api/Etiquetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etiqueta>> PostEtiqueta(EtiquetaViewModel model)
        {
            if (_context.Etiquetas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Etiquetas'  is null.");
            }
            Etiqueta etiqueta = new Etiqueta();
            etiqueta.AddModelInfo(model);

            _context.Etiquetas.Add(etiqueta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtiqueta", new { id = etiqueta.Id }, etiqueta);
        }


        // PUT: api/Etiquetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtiqueta(int id, Etiqueta etiqueta)
        {
            if (id != etiqueta.Id)
            {
                return BadRequest();
            }

            _context.Entry(etiqueta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtiquetaExists(id))
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

        // GET: api/Etiquetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etiqueta>> GetEtiqueta(int id)
        {
            if (_context.Etiquetas == null)
            {
                return NotFound();
            }
            var etiqueta = await _context.Etiquetas.FindAsync(id);

            if (etiqueta == null)
            {
                return NotFound();
            }

            return etiqueta;
        }


        // GET: api/Etiquetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etiqueta>>> GetEtiquetas()
        {
            if (_context.Etiquetas == null)
            {
                return NotFound();
            }
            return await _context.Etiquetas.ToListAsync();
        }

        #endregion


        #region Delete

        // DELETE: api/Etiquetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtiqueta(int id)
        {
            if (_context.Etiquetas == null)
            {
                return NotFound();
            }
            var etiqueta = await _context.Etiquetas.FindAsync(id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            _context.Etiquetas.Remove(etiqueta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool EtiquetaExists(int id)
        {
            return (_context.Etiquetas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
