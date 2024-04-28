namespace LABB_3_API.Services
{
    public interface IHobbies<T>
    {
        Task<T> AddHobby(T newHobby);
        Task<T> AddLink(string link, T hobby);
        Task<T> Search(int id);
    }
}
