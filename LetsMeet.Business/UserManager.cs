namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Threading.Tasks;

    public class UserManager : IUserManager
    {
        public IUserStore userStore;

        public UserManager(IUserStore userStore)
        {
            this.userStore = userStore;
        }


        public async Task<String> AddUser(CreateRequestUser createRequestUser)
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
            return await userStore.AddUser(createRequestUser);
        }

        public async Task<String> UpdateUser(CreateRequestUser createRequestUser)
        {
            return await userStore.UpdateUser(createRequestUser);
        }

        public async Task<String> DeleteUser(Guid Id)
        {
            return await userStore.DeleteUser(Id);
        }
    }
}
