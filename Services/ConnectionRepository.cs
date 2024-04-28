using LABB_3_API.Data;
using LABB_3_API_Models;
using System;

namespace LABB_3_API.Services
{
    public class ConnectionRepository : IPHConnections<PersonHobbyConnection>
    {
        private Labb3ApiDbContext _context;
        public ConnectionRepository(Labb3ApiDbContext context)
        {
            _context = context;
        }

        public async Task<PersonHobbyConnection> AddHobbyToPerson(int personId, int hobbyId)
        {
            var newConnection = new PersonHobbyConnection
            {
                PersonId = personId,
                HobbyId = hobbyId
            };

            _context.PersonHobbyConnections.Add(newConnection);
            await _context.SaveChangesAsync();

            return newConnection;
        }
    }
}
