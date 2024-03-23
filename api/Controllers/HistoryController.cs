using api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Chat;
using OpenAI_API;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly project_prn231Context _context;

        public HistoryController(project_prn231Context context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistory(int id)
        {
            var submission = _context
                .Submissions
                .Include(x => x.Contest)
                .Where(x => x.StudentId == id)
                .Select(x => new
                {
                    id = x.Id,
                    contest = x.Contest,
                    subject = x.Contest.Subject.Name,
                    grade = x.Grade,
                    teacherFeedback = x.TeacherFeedback,
                    submissionTime = x.SubmissionTime
                });
            return Ok(submission);
        }
    }
}
