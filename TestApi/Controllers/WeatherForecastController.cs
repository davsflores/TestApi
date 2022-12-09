using Microsoft.AspNetCore.Mvc;
using TestApi.Data;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class WeatherForecastController : ControllerBase
    {
        private readonly SchoolDbContext _dbcontext;

        public WeatherForecastController(SchoolDbContext _context)
        {
            _dbcontext = _context;
        }
       
        [HttpGet]
        [Route("Students")]

        public async Task<IActionResult> GetStudents()
        {
            List<Student> listStudents = _dbcontext.Students.ToList();
            try
            {
                if (listStudents != null)
                {
                    return Ok(listStudents);
                }
                return Ok("There are no students in the database");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }


        }

    }
}