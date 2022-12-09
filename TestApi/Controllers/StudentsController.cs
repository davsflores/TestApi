using Microsoft.AspNetCore.Mvc;
using TestApi.Data;

namespace TestApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private SchoolDbContext _dbcontext;

        public StudentsController(SchoolDbContext _context)
        {
            _dbcontext = _context;
        }
       
        //GET All Students: api/Students
        [HttpGet]
        public List<Student> Get()
        {
            return _dbcontext.Students.ToList();
        }

        //GET: api/Students
        [HttpGet("{Id}")]
        public Student GetStudent(int Id)
        {
            var student = _dbcontext.Students.Where(a => a.StudentId == Id).SingleOrDefault();
            return student;
        }

        //Post: api/Students
        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            _dbcontext.Students.Add(student);
            _dbcontext.SaveChanges();

            return Ok();
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var student = await _dbcontext.Students.FindAsync(Id);
            if (student == null)
            {

                return NotFound();
            }

            _dbcontext.Students.Remove(student);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
