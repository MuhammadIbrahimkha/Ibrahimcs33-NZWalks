using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //https://localhost:porotnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: https://localhost:porotnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
           string[] studentsName = new string[]{ "Mr Khan", "M Ibrham", "Jan" };
            return Ok(studentsName);
        }
    }
}
