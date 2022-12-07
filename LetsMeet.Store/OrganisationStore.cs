namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OrganisationStore : IOrganisationStore
    {
        SqlConnection con = new SqlConnection();

        public string AddOrganisation(Organisation organisation)
        {
            try
            {
                string sql = "AddOrganisation";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", organisation.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", organisation.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", organisation.OrganisationCategory);
                cmd.Parameters.AddWithValue("@CreatedDate", organisation.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", organisation.ModifiedDate);
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
        public string UpdateOrganisation(Organisation organisation)
        {
            try
            {
                string sql = "UpdateOrganisation";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganisationName", organisation.OrganisationName);
                cmd.Parameters.AddWithValue("@OrganisationTypes", organisation.OrganisationTypes);
                cmd.Parameters.AddWithValue("@OrganisationCategory", organisation.OrganisationCategory);
                cmd.Parameters.AddWithValue("@CreatedDate", organisation.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", organisation.ModifiedDate);
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
            try
            {
                string sql = "DeleteOrganisation";
                SqlCommand cmd = new SqlCommand(sql, con);
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

        public string CreateRole(Role role)
        {
            try
            {
                string sql = "AddRole";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.Parameters.AddWithValue("@IsVerified", role.IsVerified);
                cmd.Parameters.AddWithValue("@UserId", role.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", role.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", role.OrganisationId);
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


        public string AcceptRole(Role role)
        {
            try
            {
                string sql = "UpdateRole";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.Parameters.AddWithValue("@IsVerified", role.IsVerified);
                cmd.Parameters.AddWithValue("@UserId", role.UserId);
                cmd.Parameters.AddWithValue("@CompanyId", role.CompanyId);
                cmd.Parameters.AddWithValue("@OrganisationId", role.OrganisationId);
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
            try
            {
                string sql = "DeleteRole";
                SqlCommand cmd = new SqlCommand(sql, con);
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
    }
}
