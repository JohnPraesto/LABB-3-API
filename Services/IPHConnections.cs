using LABB_3_API_Models;

namespace LABB_3_API.Services
{
    public interface IPHConnections<T>
    {
        Task<T> AddHobbyToPerson(int personId, int hobbyId);
    }
}
