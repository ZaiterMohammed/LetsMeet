namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class PostStore : IPostStore
    {

        private readonly IConfiguration Configuration;

        public PostStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<String> AddLike(PostAction postAction)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateLike";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PostId", postAction.PostId);
            cmd.Parameters.AddWithValue("@UserId", postAction.UserId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.OpenAsync();
            return ("Like save Successfully");
        }
        public async Task<String> DeleteLike(Guid postId, Guid userId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteLike";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PostId", postId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.OpenAsync();
            return ("Like was Successfully Deleted");
        }
    }
}
