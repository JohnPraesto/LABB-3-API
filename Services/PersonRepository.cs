using LABB_3_API.Data;
using LABB_3_API_Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LABB_3_API.Services
{
    public class PersonRepository : ILabb3Api<Person>
    {
        private Labb3ApiDbContext _context;
        public PersonRepository(Labb3ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonHobbies(int id)
        {
            // Query the person and their hobbies
            var personWithHobbies = await _context.Persons
                .Where(p => p.PersonId == id)
                .Include(p => p.PersonHobbies)
                .ThenInclude(ph => ph.Hobby)
                .FirstOrDefaultAsync();

            return personWithHobbies;
        }

        public async Task<Person> GetPersonLinks(int id)
        {
            // Query the person and their Links
            var personWithLinks = await _context.Persons
                .Where(p => p.PersonId == id)
                .Include(p => p.PersonHobbies)
                .ThenInclude(ph => ph.Hobby)
                .FirstOrDefaultAsync();

            return personWithLinks;
        }
    }
}
