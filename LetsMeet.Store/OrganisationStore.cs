namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class OrganisationStore : IOrganisationStore
    {

        private readonly IConfiguration Configuration;

        public OrganisationStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<String> AddOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateOrganisation";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrganisationName", organisationRequest.OrganisationName);
            cmd.Parameters.AddWithValue("@OrganisationTypes", organisationRequest.OrganisationTypes);
            cmd.Parameters.AddWithValue("@OrganisationCategory", organisationRequest.OrganisationCategory);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@IsFeatured", IsFeatured);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Organisation save Successfully");
        }
        public async Task<String> UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_UpdateOrganisation";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrganisationName", updateOrganisationRequest.OrganisationName);
            cmd.Parameters.AddWithValue("@OrganisationTypes", updateOrganisationRequest.OrganisationTypes);
            cmd.Parameters.AddWithValue("@OrganisationCategory", updateOrganisationRequest.OrganisationCategory);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@IsFeatured", updateOrganisationRequest.IsFeatured);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Organization was Successfully Updated");
        }
        public async Task<String> DeleteOrganisation(Guid organisationId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteOrganisation";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrganisationId", organisationId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("OrganizationId was Successfully Deleted");
        }

        public async Task<String> CreateRole(Guid id, Guid userId, string roleName)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateRole";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleName", roleName);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@OwnerId", id);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Role save Successfully");
        }


        public async Task<String> AcceptRole(Guid id, Guid userId, string roleName)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_UpdateRole";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IsVerified", 1);
            cmd.Parameters.AddWithValue("@RoleName", roleName);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@OwnerId", id);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Role was Successfully Accepted");
        }

        public async Task<String> DeleteRole(Guid roleId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteRole";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleId", roleId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Role was Successfully Deleted");
        }

        public async Task<Role> GetRoleByUserId(Guid userId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            string sql = "usp_GetRoleByUserId";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            await con.OpenAsync();
            var role = new Role();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
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



        public async Task<String> AddPost(CreatePostRequest createPostRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
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
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Post save Successfully");
        }
        public async Task<String> UpdatePost(CreatePostRequest createPostRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_UpdatePost";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PostTitle", createPostRequest.PostTitle);
            cmd.Parameters.AddWithValue("@PostDescription", createPostRequest.PostDescription);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", createPostRequest.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", createPostRequest.UpdatedBy);
            cmd.Parameters.AddWithValue("@OwnerTypes", createPostRequest.OwnerTypes);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Post was Successfully Updated");
        }

        public async Task<String> DeletePost(Guid postId, Guid companyId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeletePost";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PostId", postId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Post was Successfully Deleted");
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            string sql = "usp_GetPostById";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PostId", postId);
            await con.OpenAsync();
            var post = new Post();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
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


        public async Task<List<Organisation>> GetAllOrganisation()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOrganisation";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            var organisations = new List<Organisation>();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
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


        public async Task<List<Organisation>> GetAllOrganisationNotVerified()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOrganisationNotVerified";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            var organisations = new List<Organisation>();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
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

        public async Task<List<Organisation>> GetAllOrganisationVerified()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOrganisationVerified";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

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
        public async Task<List<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "GetAllAdminsByMunicipalityId";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MunicipalityId", MunicipalityId);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            var Admins = new List<Admins>();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
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

        public async Task<Organisation> GetOrganisattionById(Guid organisationId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            string sql = "usp_GetOrganisattionById";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@organisationId", organisationId);
            await con.OpenAsync();
            var organisation = new Organisation();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                organisation = new Organisation()
                {
                    OrganisationId = reader.GetGuid("OrganisationId"),
                    OrganisationName = reader.GetString("OrganisationName"),
                    OrganisationTypes = Enum.Parse<OrganisationTypes>(reader.GetString("OrganisationTypes")),
                    OrganisationCategory = Enum.Parse<OrganisationCategory>(reader.GetString("OrganisationCategory")),
                    CreatedDate = reader.GetDateTime("CreatedDate"),
                    ModifiedDate = reader.GetDateTime("ModifiedDate"),
                    IsFeatured = reader.GetInt32("IsFeatured"),
                };
            }
            return organisation;
           
        }
    }
}
