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
