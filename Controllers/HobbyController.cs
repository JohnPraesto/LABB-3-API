using LABB_3_API.Services;
using LABB_3_API_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABB_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private IHobbies<Hobby> _context;
        public HobbyController(IHobbies<Hobby> context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Hobby>> AddHobby(Hobby newHobby) // Dessa inparametrar kommer efterfrågas av API swagger
        {
            try
            {
                var newH = await _context.AddHobby(newHobby);
                return Ok(newH);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}")] // Detta är "verbet" (?)
        public async Task<ActionResult<Hobby>> GetHobby(int id)
        {
            try
            {
                var result = await _context.Search(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id:int}/addLink")]
        public async Task<ActionResult<Hobby>> AddLink(int id, string link)
        {
            try
            {
                var hobbyToUpdate = await _context.Search(id);
                if (hobbyToUpdate == null)
                {
                    return NotFound($"Hobby with id {id} not found, ok?");
                }
                return await _context.AddLink(link, hobbyToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating product to Database, hörru!");
            }
        }
    }
}
