using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.DTOs;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly project_prn231Context _context;

        public ClassesController(project_prn231Context context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            if (_context.Classes == null)
            {
                return NotFound();
            }
            var res = _context.Classes.Include(x => x.Teacher);
            var classes =  res.Select(x => new ClassDTO
            {
                Id = x.Id,
                Name = x.Name,
                TeacherId = x.TeacherId,
                TeacherName = x.Teacher.Fullname
            });
            return Ok(classes);
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
          if (_context.Classes == null)
          {
              return NotFound();
          }
            var @class = await _context.Classes.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Class @class)
        {
            if (id != @class.Id)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Class>> PostClass(Class @class)
        {
          if (_context.Classes == null)
          {
              return Problem("Entity set 'project_prn231Context.Classes'  is null.");
          }
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.Id }, @class);
        }

       

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            if (_context.Classes == null)
            {
                return NotFound();
            }
            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }

            try
            {
                var contests = _context.Contests.Include(x => x.Class).Where(x => x.Class == @class);

                foreach (var contest in contests)
                {
                    var submissions = contest.Submissions.Where(x => x.ContestId == contest.Id).ToList();
                    _context.RemoveRange(submissions);
                    _context.SaveChanges();
                }

                _context.RemoveRange(contests);

                var studentClass = _context.StudentsClasses.Where(x => x.Class == @class).ToList();

                _context.RemoveRange(studentClass);
                _context.Classes.Remove(@class);
                await _context.SaveChangesAsync();

                return Ok("Delete Class Successfully");
            }
            catch (Exception)
            {

                return BadRequest("Delete Class Failed");
            }
            
        }

        private bool ClassExists(int id)
        {
            return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
