namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class UserStore : IUserStore
    {
        private readonly IConfiguration Configuration;

        public UserStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string AddUser(CreateRequestUser createRequestUser)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_CreateUser";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", createRequestUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", createRequestUser.LastName);
                cmd.Parameters.AddWithValue("@Age", createRequestUser.Age);
                cmd.Parameters.AddWithValue("@IsFetured", createRequestUser.IsFeatured);
                 cmd.Parameters.AddWithValue("@Country", createRequestUser.CountryId);
                 cmd.Parameters.AddWithValue("@City", createRequestUser.CityId);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@OwnerId", createRequestUser.OwnerId);
                cmd.Parameters.AddWithValue("@MunicipalityId", createRequestUser.MunicipalityId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("User saved Successfully");
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

        public string UpdateUser(CreateRequestUser createRequestUser)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_UpdateUser";
                using SqlCommand cmd = new SqlCommand(sql, con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", createRequestUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", createRequestUser.LastName);
                cmd.Parameters.AddWithValue("@Age", createRequestUser.Age);
                cmd.Parameters.AddWithValue("@IsFetured", createRequestUser.IsFeatured);
                cmd.Parameters.AddWithValue("@Country", createRequestUser.CountryId);
                cmd.Parameters.AddWithValue("@City", createRequestUser.CityId);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@OwnerId", createRequestUser.OwnerId);
                cmd.Parameters.AddWithValue("@MunicipalityId", createRequestUser.MunicipalityId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("User was Successfully Updated");
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

        public string DeleteUser(Guid userId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_DeleteUser";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("User was Successfully Deleted");
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
