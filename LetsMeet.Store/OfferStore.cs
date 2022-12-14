namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System.Collections.Generic;
    using System;
    using System.Data.SqlClient;
    using System.Data;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;

    public class OfferStore : IOfferStore
    {
        private readonly IConfiguration Configuration;

        public OfferStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<String> AddOffer(CreateOfferRequest createOfferRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_CreateOffer";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OfferTitle", createOfferRequest.OfferTitle);
            cmd.Parameters.AddWithValue("@OfferTypes", createOfferRequest.OfferTypes);
            cmd.Parameters.AddWithValue("@CreatedBy", createOfferRequest.UserId);
            cmd.Parameters.AddWithValue("@ModifiedBy", createOfferRequest.UserId);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Offer save Successfully");
        }
        public async Task<String> UpdateOffer(CreateOfferRequest createOfferRequest)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_UpdateOffer";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OfferTitle", createOfferRequest.OfferTitle);
            cmd.Parameters.AddWithValue("@OfferTypes", createOfferRequest.OfferTypes);
            cmd.Parameters.AddWithValue("@ModifiedBy", createOfferRequest.UserId);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Municipality was Successfully Updated");
        }
        public async Task<String> DeleteOffer(Guid offerId)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_DeleteOffer";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@offerId", offerId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
            return ("Offer was Successfully Deleted");
        }
        public async Task<List<Offer>> GetAllOfferByCreatedBy(Guid CreatedBy)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);
            string sql = "usp_GetAllOfferByCreatedBy";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            var offers = new List<Offer>();
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
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
