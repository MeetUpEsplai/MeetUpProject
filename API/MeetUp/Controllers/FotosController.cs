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
    public class FotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Get

        // GET: api/Fotos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotos()
        {
          if (_context.Fotos == null)
          {
              return NotFound();
          }
            return await _context.Fotos.ToListAsync();
        }

       

        // GET: api/Fotos/5
        [HttpGet("id_{id}")]
        public async Task<ActionResult<Foto>> GetFoto(int id)
        {
          if (_context.Fotos == null)
          {
              return NotFound();
          }
            var foto = await _context.Fotos.FindAsync(id);

            if (foto == null)
            {
                return NotFound();
            }

            return foto;
        }

        #endregion


        #region Post and Put

        // PUT: api/Fotos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id_{id}")]
        public async Task<IActionResult> PutFoto(int id, Foto foto)
        {
            if (id != foto.Id)
            {
                return BadRequest();
            }

            _context.Entry(foto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoExists(id))
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
        

        // POST: api/Fotos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Foto>> PostFoto(Foto foto)
        {
          if (_context.Fotos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Fotos'  is null.");
          }
            _context.Fotos.Add(foto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoto", new { id = foto.Id }, foto);
        }

        #endregion


        #region Delete

        // DELETE: api/Fotos/5
        [HttpDelete("id_{id}")]
        public async Task<IActionResult> DeleteFoto(int id)
        {
            if (_context.Fotos == null)
            {
                return NotFound();
            }
            var foto = await _context.Fotos.FindAsync(id);
            if (foto == null)
            {
                return NotFound();
            }

            _context.Fotos.Remove(foto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private bool FotoExists(int id)
        {
            return (_context.Fotos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
