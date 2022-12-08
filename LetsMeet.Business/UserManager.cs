using LetsMeet.Abstractions;
using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.Business
{
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
