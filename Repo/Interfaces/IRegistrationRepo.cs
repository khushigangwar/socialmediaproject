using socialmediaproject.Models;

namespace socialmediaproject.Repo.Repositories
{
    public interface IRegistrationRepo
    {

        Task<Registration> GetUserById(int Id);
        Task<IEnumerable<Registration>> GetAllUsersAsync();
        Task<string> AddUser(Registration registration);
    }
}