using System.Data;
using Microsoft.Data.SqlClient;

namespace socialmediaproject.Models.Data
{
    public class DataDbContext
    {
         private readonly IConfiguration _configuration;
          private readonly string _connectionString;
        public DataDbContext(IConfiguration configuration)
         {
             _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
         }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
