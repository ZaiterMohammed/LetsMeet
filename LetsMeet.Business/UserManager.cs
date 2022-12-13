namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;

    public class UserManager : IUserManager
    {
        public IUserStore userStore;

        public UserManager(IUserStore userStore)
        {
            this.userStore = userStore;
        }


        public string AddUser(CreateRequestUser createRequestUser)
        {
            /*
             var users = GetUsersByOwnerId(createRequestUser.OwnerId); //select * from User where OrganisationId = organisationRequest.OrganisationId and IsFeatured = 1

            if(createRequestUser.OwnerId == "Organisation")
            {
                if (users.Count > 10)
                {
                    return organisationStore.UpdateOrganisationIsFeatured(createRequestUser.OwnerId, 1);
                }
            }

            if (createRequestUser.OwnerId == "Company")
            {
                if (users.Count > 10)
                {
                    return CompanyStore.UpdateCompanyIsFeatured(createRequestUser.OwnerId,1);
                }
            }
            */
            return userStore.AddUser(createRequestUser);
        }

        public string UpdateUser(CreateRequestUser createRequestUser)
        {
            return userStore.UpdateUser(createRequestUser);
        }

        public string DeleteUser(Guid Id)
        {
            return userStore.DeleteUser(Id);
        }
    }
}
