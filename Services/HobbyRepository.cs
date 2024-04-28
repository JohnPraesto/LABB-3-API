using LABB_3_API.Data;
using LABB_3_API_Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LABB_3_API.Services
{
    public class HobbyRepository : IHobbies<Hobby>
    {
        private Labb3ApiDbContext _context;
        public HobbyRepository(Labb3ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Hobby> AddHobby(Hobby newHobby)
        {
            _context.Hobbies.Add(newHobby);
            await _context.SaveChangesAsync();

            return newHobby;
        }

        public async Task<Hobby> AddLink(string link, Hobby hobby)
        {
            hobby.Links.Add(link);
            await _context.SaveChangesAsync();
            return hobby;
        }

        public async Task<Hobby> Search(int id)
        {
            return await _context.Hobbies.FirstOrDefaultAsync(h => h.HobbyId == id);
        }
    }
}
