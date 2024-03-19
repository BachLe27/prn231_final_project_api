using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsClassesController : ControllerBase
    {
        private readonly project_prn231Context _context;

        public StudentsClassesController(project_prn231Context context)
        {
            _context = context;
        }

        // GET: api/StudentsClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsClass>>> GetStudentsClasses()
        {
          if (_context.StudentsClasses == null)
          {
              return NotFound();
          }
            return await _context.StudentsClasses.ToListAsync();
        }

        // GET: api/StudentsClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsClass>> GetStudentsClass(int id)
        {
          if (_context.StudentsClasses == null)
          {
              return NotFound();
          }
            var studentsClass = await _context.StudentsClasses.FindAsync(id);

            if (studentsClass == null)
            {
                return NotFound();
            }

            return studentsClass;
        }

        // PUT: api/StudentsClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsClass(int id, StudentsClass studentsClass)
        {
            if (id != studentsClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsClassExists(id))
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

        // POST: api/StudentsClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsClass>> PostStudentsClass(StudentsClass studentsClass)
        {
          if (_context.StudentsClasses == null)
          {
              return Problem("Entity set 'project_prn231Context.StudentsClasses'  is null.");
          }
            _context.StudentsClasses.Add(studentsClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsClass", new { id = studentsClass.Id }, studentsClass);
        }

        // DELETE: api/StudentsClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsClass(int id)
        {
            if (_context.StudentsClasses == null)
            {
                return NotFound();
            }
            var studentsClass = await _context.StudentsClasses.FindAsync(id);
            if (studentsClass == null)
            {
                return NotFound();
            }

            _context.StudentsClasses.Remove(studentsClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsClassExists(int id)
        {
            return (_context.StudentsClasses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
