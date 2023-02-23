using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            var list = new List<Classroom>()
            {
                new Classroom(){ ClassroomID = 1, Name = "Salle Bill Gates", Floor = 2, Corridor = "Rouge"},
                new Classroom(){ ClassroomID = 2, Name = "Salle Satya Nadella", Floor = 1, Corridor = "Bleu"},
                new Classroom(){ ClassroomID = 3, Name = "Salle Steve Ballmer", Floor = 2, Corridor = "Bleu"},
            };

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroom([FromRoute] int id)
        {
            var classroom = new Classroom() { ClassroomID = id, Name = "Salle Bill Gates", Floor = 2, Corridor = "Rouge" };

            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult AddClassroom([FromBody] Classroom? classroom)
        {
            if(classroom == null)
                return BadRequest();

            // ajout
            classroom = new Classroom() { ClassroomID = 1, Name = classroom.Name, Floor = classroom.Floor, Corridor = classroom.Corridor };

            return Created($"classroomtest/{classroom.ClassroomID}", classroom);
        }

        [HttpPut("{id}")]
        public IActionResult EditClassroom([FromRoute] int id, [FromBody] Classroom classroom)
        {
            if(id != classroom.ClassroomID)
                return BadRequest();

            // modif

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClassroom([FromRoute] int id)
        {
            // suppression
            var classroom = new Classroom() { ClassroomID = id, Name = "Salle Bill Gates", Floor = 2, Corridor = "Rouge" };

            return Ok(classroom);
        }
    }
}
