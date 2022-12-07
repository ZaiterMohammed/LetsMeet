using LetsMeet.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LetsMeet.Store
{
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

        public string DeletePost(Guid postId)
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
    }
}
