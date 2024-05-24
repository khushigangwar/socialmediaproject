using Dapper;
using socialmediaproject.Models;
using socialmediaproject.Models.Data;
using socialmediaproject.Repo.Interfaces;
using System.Data;

namespace socialmediaproject.Repo.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly DataDbContext context;
        private PostRepo(DataDbContext context)
        {
            this.context = context;
        }
        async Task<string> IPostRepo.Create(Post post)
        {
            string response =string.Empty;
            var query = "INSERT INTO Posts (PostId, Content, CreatedAt) VALUES (@UserId, @Content, @CreatedAt)";
            var parameters = new DynamicParameters();
            parameters.Add("Content", post.Content, DbType.String);
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            response = "Post created successfully"; // Added response message
            return response;
        }

        async Task<IEnumerable<Post>> IPostRepo.Getpost(int id)
        {
            var query = "Select * from Post where UserId=@UserId";
            using var connectin = this.context.CreateConnection();
            var user = await connectin.QueryAsync<Post>(query, new { userId = id });
            return user.ToList();
        }

        async Task<Post> IPostRepo.GetpostById(int id)
        {
            var query = "Select * from Post where UserId=@UserId";
            using var connectin=this.context.CreateConnection();
            var user=await connectin.QuerySingleOrDefaultAsync<Post>(query, new {UserId=id});
            return user;
        }
        
    }
}
