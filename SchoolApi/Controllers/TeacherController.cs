using Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly SchoolContext context;

        public TeacherController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet("class/{classroomid}")]
        public async Task<IActionResult> GetTeacherByClassroom(int classroomid)
        {
            return Ok(await this.context.Teachers.FindAsync(classroomid));
        }
    }
}
