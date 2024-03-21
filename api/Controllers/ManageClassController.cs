using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageClassController : ControllerBase
    {
        private readonly project_prn231Context _context;

        public ManageClassController(project_prn231Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentToClass(StudentClassDTO record)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'project_prn231Context.Classes'  is null.");
            }

            try
            {
                var newStudentClass = new StudentsClass
                {
                    ClassId = record.ClassId,
                    StudentId = record.StudentId
                };

                var checkExisted = _context.StudentsClasses
                    .Where(x => x.ClassId == record.ClassId)
                    .Where(x => x.StudentId == record.StudentId).FirstOrDefault();

                if (checkExisted != null)
                {
                    return BadRequest("Học sinh đã ở trong lớp học này!");
                }

                _context.Add(newStudentClass);
                await _context.SaveChangesAsync();

                var response = new
                {
                    message = "Add student to class successful",
                    studentClass = newStudentClass
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Add student to class fail!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentFromClass(int classId)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'project_prn231Context.Classes'  is null.");
            }

            try
            {
                //var @class = _context.Classes.Include(x => x.StudentsClasses).FirstOrDefault(x => x.Id == classId);

                var response = _context.StudentsClasses
                    .Include(x => x.Student)
                    .Where(x => x.ClassId == classId)
                    .Select(x => x.Student)
                    .ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Get student in class fail!");
            }
        }

        [HttpGet("GetStudentClass")]
        public async Task<IActionResult> GetClassOfStudent(int studentId)
        {
            if (_context.StudentsClasses == null)
            {
                return Problem("Entity set 'project_prn231Context.Classes'  is null.");
            }

            try
            {
                //var @class = _context.Classes.Include(x => x.StudentsClasses).FirstOrDefault(x => x.Id == classId);

                var response = _context.StudentsClasses
                    .Include(x => x.Class)
                    .Where(x => x.StudentId == studentId)
                    .Select(x => x.Class)
                    .ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Get class of student fail!");
            }
        }
    }
}
