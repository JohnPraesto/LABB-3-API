namespace LABB_3_API.Services
{
    public interface ILabb3Api<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetPersonHobbies(int id);
        Task<T> GetPersonLinks(int id);

        /*

        - [ ]  Hämta alla personer i systemet
        - [ ]  Hämta alla intressen som är kopplade till en specifik person
        - [ ]  Hämta alla länkar som är kopplade till en specifik person
        - [ ]  Koppla en person till ett nytt intresse
        - [ ]  Lägga in nya länkar för en specifik person och ett specifikt intresse

        */
    }
}
