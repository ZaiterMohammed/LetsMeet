namespace LetsMeet.Abstractions.Models
{
    using System;

    public class CreateAdminRequest
    {
        public Guid UserId
        {
            get;
            set;
        }

        public Guid MunicipalityId
        {
            get;
            set;
        }
        public CreateAdminRequest()
        {

        }
        public CreateAdminRequest(Guid userId, Guid municipalityId)
        {
            UserId = userId;
            MunicipalityId = municipalityId;
        }
    }
}
