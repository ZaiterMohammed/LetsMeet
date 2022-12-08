namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PostStore : IPostStore
    {
        public string AddLike(PostAction postAction)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreateLike";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostId", postAction.PostId);
                cmd.Parameters.AddWithValue("@UserId", postAction.UserId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Like save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
        public string DeleteLike(Guid postId, Guid userId)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_DeleteLike";
               using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostId", postId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Like was Successfully Deleted");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
