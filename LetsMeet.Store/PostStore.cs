namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PostStore : IPostStore
    {
        SqlConnection con = new SqlConnection();

        public string AddPost(Post post)
        {
            try
            {
                string sql = "AddPost";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostDescription", post.PostDescription);
                cmd.Parameters.AddWithValue("@CreatedDate", post.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", post.ModifiedDate);
                cmd.Parameters.AddWithValue("@CompanyId", post.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", post.OrganisationId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Post save Successfully");
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
        public string UpdatePost(Post post)
        {
            try
            {
                string sql = "UpdatePost";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostTitle", post.PostTitle);
                cmd.Parameters.AddWithValue("@PostDescription", post.PostDescription);
                cmd.Parameters.AddWithValue("@CreatedDate", post.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", post.ModifiedDate);
                cmd.Parameters.AddWithValue("@CompanyId", post.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", post.OrganisationId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Post was Successfully Updated");
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

        public string DeletePost(Guid postId, Guid companyId)
        {
            try
            {
                string sql = "DeletePost";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostId", postId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Post was Successfully Deleted");
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

        public Post GetPostById(Guid postId)
        {
            string sql = "GetPostById";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PostId", postId);
            con.Open();
            var post = new Post();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                post = new Post()
                {
                    PostId = reader.GetGuid("PostId"),
                    PostTitle = reader.GetString("PostTitle"),
                    PostDescription = reader.GetString("PostDescription"),
                    CreatedDate = reader.GetDateTime("CreatedDate"),
                    ModifiedDate = reader.GetDateTime("ModifiedDate"),
                    CompanyId = reader.GetGuid("CompanyId"),
                    OrganisationId = reader.GetGuid("OrganisationId"),
                };
            }
            return post;
        }

        public string AddLike(PostAction postAction)
        {
            try
            {
                string sql = "AddLike";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostId", postAction.PostId);
                cmd.Parameters.AddWithValue("@UserId", postAction.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", postAction.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", postAction.OrganisationId);
                cmd.Parameters.AddWithValue("@Like", postAction.Like);
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
        public string DeleteLike(Guid postActionId)
        {
            try
            {
                string sql = "DeleteLike";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostActionId", postActionId);
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
