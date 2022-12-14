namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class CompanyStore : ICompanyStore
    {

        private readonly IConfiguration Configuration;

        public CompanyStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<String> AddCompany(CreateCompanyRequest createCompanyRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateCompany";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyName", createCompanyRequest.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyTypes", createCompanyRequest.CompanyTypes);
            cmd.Parameters.AddWithValue("@CountryName", createCompanyRequest.CountryId);
            cmd.Parameters.AddWithValue("@CityName", createCompanyRequest.CityId);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Company save Successfully");
        }

        public async Task<String> UpdateCompany(CreateCompanyRequest createCompanyRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_UpdateCompany";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyName", createCompanyRequest.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyTypes", createCompanyRequest.CompanyTypes);
            cmd.Parameters.AddWithValue("@CountryName", createCompanyRequest.CountryId);
            cmd.Parameters.AddWithValue("@CityName", createCompanyRequest.CityId);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Company was Successfully Updated");
        }

        public async Task<String> DeleteCompany(Guid companyId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteCompany";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", companyId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Company was Successfully Deleted");
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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
            await con.CloseAsync();
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

