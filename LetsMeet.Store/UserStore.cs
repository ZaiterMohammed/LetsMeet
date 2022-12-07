namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CompanyStore : IUserStore
    {
        public string AddUser(User user)
        {
            try
            {
                string sql = "AddUser";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@IsFetured", user.IsFeatured);
                cmd.Parameters.AddWithValue("@Country", user.Country.CountryName);
                cmd.Parameters.AddWithValue("@City", user.City.CityName);
                cmd.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", user.ModifiedDate);
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

        public string UpdateUser(User user)
        {
            try
            {
                string sql = "UpdateUser";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@IsFetured", user.IsFeatured);
                cmd.Parameters.AddWithValue("@Country", user.Country.CountryName);
                cmd.Parameters.AddWithValue("@City", user.City.CityName);
                cmd.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", user.ModifiedDate);
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
            try
            {
                string sql = "DeleteUser";
                SqlCommand cmd = new SqlCommand(sql, con);
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
