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

        public async Task<String> AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateMunicipality";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MunicipalityName", createMunicipalityRequest.MunicipalityName);
            cmd.Parameters.AddWithValue("@CountryId", createMunicipalityRequest.CountryId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Municipality save Successfully");
        }
        public async Task<String> UpdateMunicipality(Municipality municipality)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_UpdateMunicipality";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MunicipalityId", municipality.MunicipalityId);
            cmd.Parameters.AddWithValue("@MunicipalityName", municipality.MunicipalityName);
            cmd.Parameters.AddWithValue("@CountryId", municipality.CountryId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Municipality was Successfully Updated");
        }
        public async Task<String> DeleteMunicipality(Guid municipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteMunicipality";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MunicipalityId", municipalityId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Municipality was Successfully Deleted");
        }

        public async Task<IEnumerable<Municipality>> GetAllMunicipality()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllMunicipality";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

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

        public async Task<String> AddAdmin(CreateAdminRequest createAdminRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateAdmin";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", createAdminRequest.UserId);
            cmd.Parameters.AddWithValue("@MunicipalityId", createAdminRequest.MunicipalityId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Admin save Successfully");
        }
        public async Task<String> DeleteAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteAdmin";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AdminId", AdminId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Admin was Successfully Deleted");
        }

        public async Task<List<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllAdminsByMunicipalityId";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
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

            string sql = "usp_GetMunicipalityById";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
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
