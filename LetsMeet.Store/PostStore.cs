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
        public async Task<Guid> AddLike(PostAction postAction)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreateLike", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var likeId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@likeId", likeId);
            cmd.Parameters.AddWithValue("@postId", postAction.PostId);
            cmd.Parameters.AddWithValue("@userId", postAction.UserId);

            await con.OpenAsync();
            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.OpenAsync();
            }
           
          
            return likeId;
        }
        public async Task<Guid> RemoveLike(Guid postId, Guid userId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_DeleteLike", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@PostId", postId);
            cmd.Parameters.AddWithValue("@UserId", userId);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }
            return postId;

        }
    }
}
