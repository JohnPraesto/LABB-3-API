using LABB_3_API.Services;
using LABB_3_API_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABB_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonHobbyConnectionController : ControllerBase
    {

        private IPHConnections<PersonHobbyConnection> _context;
        public PersonHobbyConnectionController(IPHConnections<PersonHobbyConnection> context)
        {
            _context = context;
        }

        [HttpPost("{personId}/hobbies/{hobbyId}")]
        public async Task<ActionResult<PersonHobbyConnection>> AddHobbyToPerson(int personId, int hobbyId) // Dessa inparametrar kommer efterfrågas av API swagger
        {
            try
            {
                var newConnection = await _context.AddHobbyToPerson(personId, hobbyId);
                return Ok(newConnection);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
