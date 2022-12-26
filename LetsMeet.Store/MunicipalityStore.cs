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

    public class MunicipalityStore : IMunicipalityStore
    {

        private readonly IConfiguration Configuration;

        public MunicipalityStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<Guid> CreateMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreateMunicipality", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var municipalityId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@id", municipalityId);
            cmd.Parameters.AddWithValue("@name", createMunicipalityRequest.Name);
            cmd.Parameters.AddWithValue("@countryId", createMunicipalityRequest.CountryId);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            return municipalityId;
        }
        public async Task<Guid> UpdateMunicipality(Municipality municipality)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_UpdateMunicipality", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var municipalityId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@id", municipalityId);
            cmd.Parameters.AddWithValue("@name", municipality.MunicipalityName);
            cmd.Parameters.AddWithValue("@countryId", municipality.CountryId);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            return municipalityId;
        }
        public async Task<Guid> RemoveMunicipality(Guid municipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_DeleteMunicipality", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", municipalityId);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            return municipalityId;
        }

        public async Task<IEnumerable<Municipality>> GetAllMunicipality()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetAllMunicipality", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            var municipalities = new List<Municipality>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    municipalities.Add(new Municipality()
                    {
                        MunicipalityId = reader.GetGuid("MunicipalityId"),
                        MunicipalityName = reader.GetString("MunicipalityName"),
                        CountryId = reader.GetGuid("CountryIdF"),
                    });
                }
            }
            return municipalities;
        }

        public async Task<Guid> AssignAdmin(Guid municipalityId,Guid userId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreateAdmin", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            var adminId = Guid.NewGuid();

            cmd.Parameters.AddWithValue("@adminId", adminId);
            cmd.Parameters.AddWithValue("@userId", municipalityId);
            cmd.Parameters.AddWithValue("@municipalityId", userId);
            
            await con.OpenAsync();
            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }
           
            return adminId;
        }
        public async Task<Guid> RemoveAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_DeleteAdmin", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AdminId", AdminId);

            await con.OpenAsync();
            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();

            }
            return AdminId;
        }

        public async Task<IEnumerable<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetAllAdminsByMunicipalityId", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@MunicipalityId", MunicipalityId);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();

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

        public async Task<Municipality> GetMunicipalityById(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_GetMunicipalityById", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@MunicipalityId", MunicipalityId);

            await con.OpenAsync();

            var municipality = new Municipality();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                municipality = new Municipality()
                {
                    MunicipalityId = reader.GetGuid("MunicipalityId"),
                    MunicipalityName = reader.GetString("MunicipalityName"),
                    CountryId = reader.GetGuid("CountryId"),

                };
            }
            return municipality;
        }
    }
}
