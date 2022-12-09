namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class MunicipalityStore : IMunicipalityStore
    {

        private readonly IConfiguration Configuration;

        public MunicipalityStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_CreateMunicipality";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MunicipalityName", createMunicipalityRequest.MunicipalityName);
                cmd.Parameters.AddWithValue("@CountryId", createMunicipalityRequest.CountryId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Municipality save Successfully");
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
        public string UpdateMunicipality(Municipality municipality)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_UpdateMunicipality";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MunicipalityId", municipality.MunicipalityId);
                cmd.Parameters.AddWithValue("@MunicipalityName", municipality.MunicipalityName);
                cmd.Parameters.AddWithValue("@CountryId", municipality.CountryId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Municipality was Successfully Updated");
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
        public string DeleteMunicipality(Guid municipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_DeleteMunicipality";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MunicipalityId", municipalityId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Municipality was Successfully Deleted");
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

        public List<Municipality> GetAllMunicipality()
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllMunicipality";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            var municipalities = new List<Municipality>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    municipalities.Add(new Municipality()
                    {
                        MunicipalityId = reader.GetGuid("MunicipalityId"),
                        MunicipalityName = reader.GetString("MunicipalityName"),
                        CountryId = reader.GetGuid("CountryId"),
                    });
                }
            }
            return municipalities;
        }

        public string AddAdmin(CreateAdminRequest createAdminRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_CreateAdmin";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", createAdminRequest.UserId);
                cmd.Parameters.AddWithValue("@MunicipalityId", createAdminRequest.MunicipalityId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Admin save Successfully");
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
        public string DeleteAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_DeleteAdmin";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminId", AdminId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Admin was Successfully Deleted");
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

        public List<Admins> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllAdminsByMunicipalityId";
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
