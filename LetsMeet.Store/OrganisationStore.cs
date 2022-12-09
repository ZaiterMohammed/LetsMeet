namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class OrganisationStore : IOrganisationStore
    {

        private readonly IConfiguration Configuration;

        public OrganisationStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string AddOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
                cmd.Parameters.AddWithValue("@IsFeatured", IsFeatured);

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
        public string UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_UpdateOrganisation";
               using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", updateOrganisationRequest.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", updateOrganisationRequest.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", updateOrganisationRequest.OrganisationCategory);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsFeatured", updateOrganisationRequest.IsFeatured);

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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

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


        public List<Organisation> GetAllOrganisation()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOrganisation";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            var organisations = new List<Organisation>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    organisations.Add(new Organisation()
                    {
                        OrganisationId = reader.GetGuid("OrganisationId"),
                        OrganisationName = reader.GetString("OrganisationName"),
                        OrganisationTypes = Enum.Parse<OrganisationTypes>(reader.GetString("OrganisationTypes")),
                        OrganisationCategory = Enum.Parse<OrganisationCategory>(reader.GetString("OrganisationCategory")),
                        CreatedDate = reader.GetDateTime("CreatedDate"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate"),
                        IsFeatured = reader.GetInt32("IsFeatured"),
                        
                    });
                }
            }
            return organisations;
        }


        public List<Organisation> GetAllOrganisationNotVerified()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOrganisationNotVerified";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            var organisations = new List<Organisation>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    organisations.Add(new Organisation()
                    {
                        OrganisationId = reader.GetGuid("OrganisationId"),
                        OrganisationName = reader.GetString("OrganisationName"),
                        OrganisationTypes = Enum.Parse<OrganisationTypes>(reader.GetString("OrganisationTypes")),
                        OrganisationCategory = Enum.Parse<OrganisationCategory>(reader.GetString("OrganisationCategory")),
                        CreatedDate = reader.GetDateTime("CreatedDate"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate"),
                        IsFeatured = reader.GetInt32("IsFeatured"),

                    });
                }
            }
            return organisations;
        }

        public List<Organisation> GetAllOrganisationVerified()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOrganisationVerified";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            var organisations = new List<Organisation>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    organisations.Add(new Organisation()
                    {
                        OrganisationId = reader.GetGuid("OrganisationId"),
                        OrganisationName = reader.GetString("OrganisationName"),
                        OrganisationTypes = Enum.Parse<OrganisationTypes>(reader.GetString("OrganisationTypes")),
                        OrganisationCategory = Enum.Parse<OrganisationCategory>(reader.GetString("OrganisationCategory")),
                        CreatedDate = reader.GetDateTime("CreatedDate"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate"),
                        IsFeatured = reader.GetInt32("IsFeatured"),

                    });
                }
            }
            return organisations;

        }
        public List<Admins> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "GetAllAdminsByMunicipalityId";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MunicipalityId", MunicipalityId);

            con.Open();
            cmd.ExecuteNonQuery();

            var Admins = new List<Admins>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Admins.Add(new Admins()
                    {
                        AdminId = reader.GetGuid("AdminId"),
                        UserId = reader.GetGuid("UserId"),
                        MunicipalityId = reader.GetGuid("MunicipalityId"),
                    });
                }
            }
            return Admins;
        }

    }
}
