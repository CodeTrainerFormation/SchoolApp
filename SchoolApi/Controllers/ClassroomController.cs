using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassrooms()
        {
            return Ok(await this.context.Classrooms.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassroom([FromRoute] int id)
        {
            Classroom? classroom = await this.context.Classrooms.FindAsync(id);

            if(classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        [HttpPost]
        public async Task<IActionResult> AddClassroom([FromBody] Classroom? classroom)
        {
            if (classroom == null)
                return BadRequest();

            //ajout
            this.context.Classrooms.Add(classroom);
            await this.context.SaveChangesAsync();

            return Created($"classroom/{classroom.ClassroomID}", classroom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClassroom([FromRoute] int id, [FromBody] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
                return BadRequest();

            // modif
            //this.context.Entry(classroom).State = EntityState.Modified;

            this.context.Classrooms.Update(classroom);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveClassroom([FromRoute] int id)
        {
            Classroom? classroom = this.context.Classrooms.Find(id);

            if(classroom == null)
                return NotFound();

            // suppression
            this.context.Classrooms.Remove(classroom);
            await this.context.SaveChangesAsync();

            return Ok(classroom);
        }
    }
}
