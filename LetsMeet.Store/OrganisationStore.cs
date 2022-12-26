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

        public async Task<Guid> CreateOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreateOrganisation", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var organisationId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@organisationId", organisationId);
            cmd.Parameters.AddWithValue("@organisationName", organisationRequest.OrganisationName);
            cmd.Parameters.AddWithValue("@organisationTypes", organisationRequest.OrganisationTypes);
            cmd.Parameters.AddWithValue("@organisationCategory", organisationRequest.OrganisationCategory);
            cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@modifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@isFeatured", IsFeatured);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }


            return organisationId;
        }
        public async Task<Guid> UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_UpdateOrganisation", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var organisationId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@organisationId", organisationId);
            cmd.Parameters.AddWithValue("@organisationName", updateOrganisationRequest.OrganisationName);
            cmd.Parameters.AddWithValue("@organisationTypes", updateOrganisationRequest.OrganisationTypes);
            cmd.Parameters.AddWithValue("@organisationCategory", updateOrganisationRequest.OrganisationCategory);
            cmd.Parameters.AddWithValue("@modifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@isFeatured", updateOrganisationRequest.IsFeatured);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }


            return organisationId;
        }
        public async Task<Guid> RemoveOrganisation(Guid organisationId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_DeleteOrganisation", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@organisationId", organisationId);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }


            return organisationId;
        }

        public async Task<Guid> CreateRole(Guid id, Guid userId, string roleName)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreateRole", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var roleId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@roleId", roleId);
            cmd.Parameters.AddWithValue("@roleName", roleName);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@ownerId", id);


            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            return roleId;
        }


        public async Task<Guid> AcceptRole(Guid id, Guid userId, string roleName)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_UpdateRole", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var roleId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@roleId", roleId);
            cmd.Parameters.AddWithValue("@isVerified", 1);
            cmd.Parameters.AddWithValue("@roleName", roleName);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@ownerId", id);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            return roleId;
        }

        public async Task<Guid> RemoveRole(Guid roleId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_DeleteRole", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@roleId", roleId);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            return roleId;
        }

        public async Task<Role> GetRoleByUserId(Guid userId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetRoleByUserId", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@userId", userId);

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



        public async Task<Guid> CreatePost(CreatePostRequest createPostRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreatePost", con) { CommandType = CommandType.StoredProcedure };

            var postId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@postId", postId);
            cmd.Parameters.AddWithValue("@postTitle", createPostRequest.PostTitle);
            cmd.Parameters.AddWithValue("@postDescription", createPostRequest.PostDescription);
            cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@modifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@createdBy", createPostRequest.CreatedBy);
            cmd.Parameters.AddWithValue("@updatedBy", createPostRequest.UpdatedBy);
            cmd.Parameters.AddWithValue("@ownerTypes", createPostRequest.OwnerTypes);

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
        public async Task<Guid> UpdatePost(CreatePostRequest createPostRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_UpdatePost", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var postId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@postId", postId);
            cmd.Parameters.AddWithValue("@postTitle", createPostRequest.PostTitle);
            cmd.Parameters.AddWithValue("@postDescription", createPostRequest.PostDescription);
            cmd.Parameters.AddWithValue("@modifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@createdBy", createPostRequest.CreatedBy);
            cmd.Parameters.AddWithValue("@updatedBy", createPostRequest.UpdatedBy);
            cmd.Parameters.AddWithValue("@ownerTypes", createPostRequest.OwnerTypes);

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

        public async Task<Guid> RemovePost(Guid postId, Guid companyId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_DeletePost", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@postId", postId);

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

        public async Task<Post> GetPostById(Guid postId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetPostById", con)
            {
                CommandType = CommandType.StoredProcedure,
            };

            cmd.Parameters.AddWithValue("@postId", postId);

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


        public async Task<IEnumerable<Organisation>> GetAllOrganisation()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetAllOrganisation", con)
            {
                CommandType = CommandType.StoredProcedure
            };

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


        public async Task<IEnumerable<Organisation>> GetAllOrganisationNotVerified()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetAllOrganisationNotVerified", con)
            {
                CommandType = CommandType.StoredProcedure
            };

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

        public async Task<IEnumerable<Organisation>> GetAllOrganisationVerified()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetAllOrganisationVerified", con)
            {
                CommandType = CommandType.StoredProcedure
            };

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
        public async Task<IEnumerable<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("GetAllAdminsByMunicipalityId", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@municipalityId", MunicipalityId);

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

            using SqlCommand cmd = new SqlCommand("usp_GetOrganisattionById", con)
            {
                CommandType = CommandType.StoredProcedure
            };

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
