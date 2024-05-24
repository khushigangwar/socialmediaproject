

using Azure;
using Dapper;
using socialmediaproject.Models;
using socialmediaproject.Models.Data;
using System.Data;

namespace socialmediaproject.Repo.Repositories
{
    public class RegistrationRepo :IRegistrationRepo
    {
        private readonly DataDbContext context;
        public RegistrationRepo(DataDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Registration>> GetAllUsersAsync()
        {
            var query = "Select * from Registration";
            using var connectin = this.context.CreateConnection();
            var userList= await connectin.QueryAsync<Registration>(query);
            return userList.ToList();
        }

        public async Task<Registration> GetUserById(int id)
        {
            string query = "Select * from  Registration where Id=@Id";
            using var connectin = this.context.CreateConnection();
            var user = await connectin.QuerySingleOrDefaultAsync<Registration>(query,new {Id=id});
            return user;
        }
        public async Task<string> AddUser(Registration registration)
        {
            string response = string.Empty;
            var query = "INSERT INTO Registration(Name,Email,Password) VALUES (@Name,@Email,@Password)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", registration.Name, DbType.String);
            parameters.Add("Email", registration.Email, DbType.String);
            parameters.Add("Password", registration.Password, DbType.String);
            using (var connectin = this.context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;

        }

    }
}
