using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet("class/{classroomid}")]
        public async Task<IActionResult> GetStudentsByClassroom(int classroomid)
        {
            return Ok(await this.context.Students
                                        .Where(s => s.ClassroomID == classroomid)
                                        .ToListAsync());
        }
    }
}
