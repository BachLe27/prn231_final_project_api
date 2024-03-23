using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using AutoMapper;
using api.DTOs;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly project_prn231Context _context;
        private readonly IMapper _mapper;

        public SubmissionsController(project_prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Submissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submission>>> GetSubmissions()
        {
          if (_context.Submissions == null)
          {
              return NotFound();
          }
            return await _context.Submissions.ToListAsync();
        }

        // GET: api/Submissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Submission>> GetSubmission(int id)
        {
          if (_context.Submissions == null)
          {
              return NotFound();
          }
            var submission = _context.Submissions
                .Include(x => x.Contest)
                .Include(x => x.Student)
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    Id = x.Id,
                    Contest = x.Contest,
                    SubjectName = x.Contest.Subject.Name,
                    Student = x.Student,
                    Grade = x.Grade,
                    SubmissionTime = x.SubmissionTime,
                    TeacherFeedback = x.TeacherFeedback,
                    Content = x.Content
                }).FirstOrDefault();

            if (submission == null)
            {
                return NotFound();
            }

            return Ok(submission);
        }

        [HttpGet("getSubmissionsByContestId/{contestId}")]
        public async Task<IActionResult> GetSubmissionByContestId(int contestId)
        {
            if (_context.Submissions == null)
            {
                return NotFound();
            }
            var submission = _context.Submissions
                .Include(x => x.Student)
                .Where(x => x.ContestId == contestId)
                .Select(x => new
                {
                    studentId = x.StudentId,
                    contestId = x.ContestId,
                    student = x.Student,
                    contest = x.Contest,
                    id = x.Id,
                    content = x.Content,
                    teacherFeedback = x.TeacherFeedback,
                    grade = x.Grade,
                    submissionTime = x.SubmissionTime
                });
               

            if (submission == null)
            {
                return NotFound();
            }

            return Ok(submission);
        }

        // PUT: api/Submissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubmission(int id, Submission submission)
        {
            if (id != submission.Id)
            {
                return BadRequest();
            }

            _context.Entry(submission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(submission);
        }


        [HttpPut("Grade/{id}")]
        public async Task<IActionResult> Grade(int id, int grade)
        {

            var submissions = _context.Submissions.FirstOrDefault(x => x.Id == id); 

            if (submissions == null)
            {
                return BadRequest("Submissions not found");
            }
            try
            {
                submissions.Grade = grade;
                _context.Update(submissions);
                _context.SaveChanges();
                return Ok("Update grade successfully");
            }
            catch (Exception)
            {
                return BadRequest("Submissions not found");
            }

            
        }


        // POST: api/Submissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Submission>> PostSubmission(Submission submission)
        {
          if (_context.Submissions == null)
          {
              return Problem("Entity set 'project_prn231Context.Submissions'  is null.");
          }
            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubmission", new { id = submission.Id }, submission);
        }

        // DELETE: api/Submissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmission(int id)
        {
            if (_context.Submissions == null)
            {
                return NotFound();
            }
            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }

            _context.Submissions.Remove(submission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubmissionExists(int id)
        {
            return (_context.Submissions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
        [HttpGet("{studentId}/{contestId}")]
        public async Task<ActionResult<SubmissionDTO>> GetByStudentAndContest(int studentId, int contestId)
        {
            if (_context.Submissions == null)
            {
                return NotFound();
            }
            var submission = await _context.Submissions
                .Include(submission => submission.Contest)
                .Include(submission => submission.Student)
                .FirstOrDefaultAsync(s => s.StudentId == studentId && s.ContestId == contestId);

            if (submission == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<SubmissionDTO>(submission);

            return result;
        }
    }
}
