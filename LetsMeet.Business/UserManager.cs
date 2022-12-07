using LetsMeet.Abstractions.Managers;
namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;

    public class UserManager : IUserManager
    {
        private readonly IUserStore userStore;

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
        public string DeleteUser(Guid userId)
        {
            return userStore.DeleteUser(userId);
        }
    }
}
