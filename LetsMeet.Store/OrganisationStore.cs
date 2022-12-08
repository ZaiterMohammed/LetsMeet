namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OrganisationStore : IOrganisationStore
    {

        public string AddOrganisation(CreateOrganisationRequest organisationRequest)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreateOrganisation";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", organisationRequest.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", organisationRequest.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", organisationRequest.OrganisationCategory);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
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
        public string UpdateOrganisation(CreateOrganisationRequest organisationRequest)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_UpdateOrganisation";
               using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", organisationRequest.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", organisationRequest.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", organisationRequest.OrganisationCategory);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
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

        public string CreateRole(Guid id, Guid userId, string roleName)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreateRole";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", roleName);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@OwnerId", id);
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


        public string AcceptRole(Guid id, Guid userId, string roleName)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_UpdateRole";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IsVerified", 1);
                cmd.Parameters.AddWithValue("@RoleName", roleName);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@OwnerId", id);
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
                };
            }
            return role;
        }



        public string AddPost(CreatePostRequest createPostRequest)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_CreatePost";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostTitle", createPostRequest.PostTitle);
                cmd.Parameters.AddWithValue("@PostDescription", createPostRequest.PostDescription);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@CreatedBy", createPostRequest.CreatedBy);
                cmd.Parameters.AddWithValue("@UpdatedBy", createPostRequest.UpdatedBy);
                cmd.Parameters.AddWithValue("@OwnerTypes", createPostRequest.OwnerTypes);
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
        public string UpdatePost(CreatePostRequest createPostRequest)
        {
            using SqlConnection con = new SqlConnection();
            try
            {
                string sql = "usp_UpdatePost";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostTitle", createPostRequest.PostTitle);
                cmd.Parameters.AddWithValue("@PostDescription", createPostRequest.PostDescription);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@CreatedBy", createPostRequest.CreatedBy);
                cmd.Parameters.AddWithValue("@UpdatedBy", createPostRequest.UpdatedBy);
                cmd.Parameters.AddWithValue("@OwnerTypes", createPostRequest.OwnerTypes);
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
                    CreatedBy = reader.GetGuid("CreatedBy"),
                    UpdatedBy = reader.GetGuid("UpdatedBy"),
                    OwnerTypes = Enum.Parse<OwnerTypes>(reader.GetString("OwnerTypes"))
                };
            }
            return post;
        }


    }
}
