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

        public string AddUser(User user)
        {
            return userStore.AddUser(user);
        }

        public string UpdateUser(User user)
        {
            return userStore.UpdateUser(user);
        }

        public string DeleteUser(Guid Id)
        {
            return userStore.DeleteUser(Id);
        }
    }
}
