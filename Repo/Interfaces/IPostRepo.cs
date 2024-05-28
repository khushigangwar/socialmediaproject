using socialmediaproject.Models;

namespace socialmediaproject.Repo.Interfaces
{
    public interface IPostRepo
    {
        //get image by postid
       Task<Post> GetpostById(int id);
        //get image by userId
        Task<IEnumerable<Post>> Getpost(int UserId);
        Task<string> Create(Post post);

    }
}
