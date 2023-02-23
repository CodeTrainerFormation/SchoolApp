using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomSyncController : ControllerBase
    {
        private readonly SchoolContext context;

        public ClassroomSyncController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetClassrooms()
        {
            return Ok(this.context.Classrooms.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroom([FromRoute] int id)
        {
            Classroom? classroom = this.context.Classrooms.Find(id);

            if(classroom == null)
                return NotFound();

            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult AddClassroom([FromBody] Classroom? classroom)
        {
            if (classroom == null)
                return BadRequest();

            //ajout
            this.context.Classrooms.Add(classroom);
            this.context.SaveChanges();

            return Created($"classroomsync/{classroom.ClassroomID}", classroom);
        }

        [HttpPut("{id}")]
        public IActionResult EditClassroom([FromRoute] int id, [FromBody] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
                return BadRequest();

            // modif
            //this.context.Entry(classroom).State = EntityState.Modified;

            this.context.Classrooms.Update(classroom);
            this.context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClassroom([FromRoute] int id)
        {
            Classroom? classroom = this.context.Classrooms.Find(id);

            if(classroom == null)
                return NotFound();

            // suppression
            this.context.Classrooms.Remove(classroom);
            this.context.SaveChanges();

            return Ok(classroom);
        }
    }
}
