using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly SchoolContext context;

        public TeacherController(SchoolContext context)
        {
            this.context = context;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("class/{classroomid}")]
        public async Task<IActionResult> GetTeacherByClassroom(int classroomid)
        {
            var teacher = await this.context.Teachers.SingleOrDefaultAsync(c => c.ClassroomID == classroomid);

            if(teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            return Ok(await this.context.Teachers.ToListAsync());
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await this.context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher? teacher)
        {
            if (teacher == null)
                return BadRequest();

            this.context.Teachers.Add(teacher);
            await this.context.SaveChangesAsync();

            return Created($"/teacher/{teacher.PersonID}", teacher);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeacher([FromRoute] int id, [FromBody] Teacher teacher)
        {
            if(id != teacher.PersonID) 
                return BadRequest();

            this.context.Teachers.Update(teacher);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTeacher(int id)
        {
            var teacher = await this.context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            this.context.Teachers.Remove(teacher);
            await this.context.SaveChangesAsync();

            return Ok(teacher);
        }
    }
}
