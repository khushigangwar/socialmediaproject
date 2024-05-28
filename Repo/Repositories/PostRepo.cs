using Dapper;
using Microsoft.Data.SqlClient;
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
        public PostRepo(DataDbContext context)
        {
            this.context = context;
        }


        public async Task<string> Create(Post post)
        {
            //using IDbConnection db = new SqlConnection("context");
            string query = "INSERT INTO Post (Id,ImageName, Content) VALUES (@Id,@ImageName, @Content)";
            using var connectin = this.context.CreateConnection();
            // int rowsAffected = await db.ExecuteAsync(query, new { ImageName = post.ImageName, Content = post.Content });
            var posts = await connectin.ExecuteAsync(query, new {Id=post.Id, ImageName = post.ImageName, Content = post.Content });
            if (posts > 0)
            {
                return "Image uploaded successfully!";
            }
            else
            {
                return "Image upload failed.";
            }
        }

        public async Task<IEnumerable<Post>>Getpost(int id)
        {
            var query = "Select * from Post where Id=@Id";
            using var connectin = this.context.CreateConnection();
            var user = await connectin.QueryAsync<Post>(query, new { Id = id });
            return user.ToList();
        }

        public async Task<Post> GetpostById(int id)
        {
            var query = "Select * from Post where Id=@Id";
            using var connectin=this.context.CreateConnection();
            var user=await connectin.QuerySingleOrDefaultAsync<Post>(query, new {Id=id});
            return user;
        }
        
    }
}
