using socialmediaproject.Models;

namespace socialmediaproject.Repo.Interfaces
{
    public interface IPostRepo
    {
       Task<Post> GetpostById(int id);
        Task<IEnumerable<Post>> Getpost(int UserId);
        Task<string> Create(Post post);

    }
}
