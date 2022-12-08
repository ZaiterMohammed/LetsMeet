﻿namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CompanyStore : ICompanyStore
    {
        SqlConnection con = new SqlConnection();

        public string AddCompany(Company company)
        {
            try
            {
                string sql = "AddCompany";
                using var con = new SqlConnection(""); //disposing of objects (to clean them from memory)
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyTypes", company.CompanyTypes);
                cmd.Parameters.AddWithValue("@CountryName", company.Country.CountryName);
                cmd.Parameters.AddWithValue("@CityName", company.City.CityName);
                cmd.Parameters.AddWithValue("@CreatedDate", company.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", company.ModifiedDate);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Company save Successfully");
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

        public string UpdateCompany(Company company)
        {
            try
            {
                string sql = "UpdateCompany";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyTypes", company.CompanyTypes);
                cmd.Parameters.AddWithValue("@CountryName", company.Country.CountryName);
                cmd.Parameters.AddWithValue("@CityName", company.City.CityName);
                cmd.Parameters.AddWithValue("@CreatedDate", company.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", company.ModifiedDate);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Company was Successfully Updated");
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

        public string DeleteCompany(Guid companyId)
        {
            try
            {
                string sql = "DeleteCompany";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Company was Successfully Deleted");
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
                cmd.Parameters.AddWithValue("@RoleName",role.RoleName);
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
        public Role GetRoleByUserId(Guid userId)
        {
            string sql = "GetRoleByUserId";
            SqlCommand cmd = new SqlCommand(sql, con);
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
                    UserId = reader.GetGuid("UserId"),
                    CompanyId = reader.GetGuid("CompanyId"),
                    OrganisationId = reader.GetGuid("OrganisationId"),

                };
            }
            return role;
        }

        public Post GetPostById(Guid postId)
        {
            string sql = "GetPostById";
            SqlCommand cmd = new SqlCommand(sql, con);
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
                    CompanyId = reader.GetGuid("CompanyId"),
                    OrganisationId = reader.GetGuid("OrganisationId"),
                };
            }
            return post;
        }
    }
}

