namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OrganisationStore : IOrganisationStore
    {

        public string AddOrganisation(Organisation organisation)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreateOrganisation";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", organisation.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", organisation.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", organisation.OrganisationCategory);
                cmd.Parameters.AddWithValue("@CreatedDate", organisation.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", organisation.ModifiedDate);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Organisation save Successfully");
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
        public string UpdateOrganisation(Organisation organisation)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_UpdateOrganisation";
               using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", organisation.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", organisation.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", organisation.OrganisationCategory);
                cmd.Parameters.AddWithValue("@CreatedDate", organisation.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", organisation.ModifiedDate);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Organization was Successfully Updated");
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
        public string DeleteOrganisation(Guid organisationId)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_DeleteOrganisation";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationId", organisationId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("OrganizationId was Successfully Deleted");
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

        public string CreateRole(Role role)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreateRole";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.Parameters.AddWithValue("@IsVerified", role.IsVerified);
                cmd.Parameters.AddWithValue("@UserId", role.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", role.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", role.OrganisationId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Role save Successfully");
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


        public string AcceptRole(Role role)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_UpdateRole";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.Parameters.AddWithValue("@IsVerified", role.IsVerified);
                cmd.Parameters.AddWithValue("@UserId", role.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", role.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", role.OrganisationId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Role was Successfully Accepted");
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

        public string DeleteRole(Guid roleId)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_DeleteRole";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Role was Successfully Deleted");
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

        public Role GetRoleByUserId(Guid userId)
        {
            using SqlConnection con = new SqlConnection();

            string sql = "usp_GetRoleByUserId";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            con.Open();
            var role = new Role();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                role = new Role()
                {
                    RoleId = reader.GetGuid("RoleId"),
                    RoleName = reader.GetString("RoleName"),
                    IsVerified = reader.GetInt32("IsVerified"),
                    UserId = reader.GetGuid("UserId"),
                    CompanyId = reader.GetGuid("CompanyId"),
                    OrganisationId = reader.GetGuid("OrganisationId"),

                };
            }
            return role;
        }



        public string AddPost(Post post)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreatePost";
                using SqlCommand cmd = new SqlCommand(sql, con);
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
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_UpdatePost";
                using SqlCommand cmd = new SqlCommand(sql, con);
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
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_DeletePost";
                using SqlCommand cmd = new SqlCommand(sql, con);
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
            using SqlConnection con = new SqlConnection();

            string sql = "usp_GetPostById";
            using SqlCommand cmd = new SqlCommand(sql, con);
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


    }
}
