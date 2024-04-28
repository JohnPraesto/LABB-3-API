using LABB_3_API.Services;
using LABB_3_API_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABB_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILabb3Api<Person> _context;
        public PersonController(ILabb3Api<Person> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _context.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error.");
            }
        }

        [HttpGet("{id}/personhobbies")]
        public async Task<ActionResult<IEnumerable<string>>> GetPersonHobbies(int id)
        {
            var result = await _context.GetPersonHobbies(id);

            if (result == null)
            {
                return NotFound("Provided person id was not found in database");
            }

            // Extract hobby names
            var hobbyNames = result.PersonHobbies
                .Select(ph => ph.Hobby.HobbyName)
                .ToList();

            return Ok(new { PersonName = result.PersonName, Hobbies = hobbyNames });
        }

        [HttpGet("{id}/personlinks")]
        public async Task<ActionResult<IEnumerable<string>>> GetPersonLinks(int id)
        {
            var result = await _context.GetPersonLinks(id);

            if (result == null)
            {
                return NotFound("Provided person id was not found in database");
            }

            // Extract hobby names
            var hobbyLinks = result.PersonHobbies
                .Select(ph => ph.Hobby.Links)
                .ToList();

            return Ok(new { PersonName = result.PersonName, Hobbies = hobbyLinks });
        }
    }
}
