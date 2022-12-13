namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System.Collections.Generic;
    using System;
    using System.Data.SqlClient;
    using System.Data;
    using Microsoft.Extensions.Configuration;

    public class OfferStore : IOfferStore
    {
        private readonly IConfiguration Configuration;

        public OfferStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string AddOffer(CreateOfferRequest createOfferRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_CreateOffer";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OfferTitle", createOfferRequest.OfferTitle);
                cmd.Parameters.AddWithValue("@OfferTypes", createOfferRequest.OfferTypes);
                cmd.Parameters.AddWithValue("@CreatedBy", createOfferRequest.UserId);
                cmd.Parameters.AddWithValue("@ModifiedBy", createOfferRequest.UserId);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Offer save Successfully");
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
        public string UpdateOffer(CreateOfferRequest createOfferRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_UpdateOffer";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OfferTitle", createOfferRequest.OfferTitle);
                cmd.Parameters.AddWithValue("@OfferTypes", createOfferRequest.OfferTypes);
                cmd.Parameters.AddWithValue("@ModifiedBy", createOfferRequest.UserId);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
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
        public string DeleteOffer(Guid offerId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            try
            {
                string sql = "usp_DeleteOffer";
                using SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@offerId", offerId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Offer was Successfully Deleted");
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
        public List<Offer> GetAllOfferByCreatedBy(Guid CreatedBy)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOfferByCreatedBy";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            con.Open();
            cmd.ExecuteNonQuery();

            var offers = new List<Offer>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    offers.Add(new Offer()
                    {
                        OfferId = reader.GetGuid("OfferId"),
                        OfferTitle = reader.GetString("OfferTitle"),
                        OfferTypes = Enum.Parse<OfferTypes>(reader.GetString("OfferTypes")),
                        CreatedDate = reader.GetDateTime("CreatedDate"),
                        ModifiedDate = reader.GetDateTime("ModifiedDate"),
                        CreatedBy = reader.GetGuid("CreatedBy"),
                        ModifiedBy = reader.GetGuid("ModifiedBy"),
                    });
                }
            }
            return offers;
        }
    }
}
