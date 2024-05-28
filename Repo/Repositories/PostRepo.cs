using Dapper;
using socialmediaproject.Models;
using socialmediaproject.Models.Data;
using socialmediaproject.Repo.Interfaces;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace socialmediaproject.Repo.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly DataDbContext context;
        private PostRepo(DataDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Create(Post post)
        {
            var query = @"
            INSERT INTO Images (UserId, ImageName, ContentType, Content, CreatedDate)
            VALUES (@UserId, @ImageName, @ContentType, @Content, @CreatedDate);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = context.CreateConnection())
            {
                var imageId = await connection.QuerySingleAsync(query, post);
                return imageId;
            }
        }

        public async Task<IEnumerable<Post>>Getpost(int id)
        {
            var query = "Select * from Post where UserId=@UserId";
            using var connectin = this.context.CreateConnection();
            var user = await connectin.QueryAsync<Post>(query, new { userId = id });
            return user.ToList();
        }

        public async Task<Post> GetpostById(int id)
        {
            var query = "Select * from Post where UserId=@UserId";
            using var connectin=this.context.CreateConnection();
            var user=await connectin.QuerySingleOrDefaultAsync<Post>(query, new {UserId=id});
            return user;
        }
        
    }
}
