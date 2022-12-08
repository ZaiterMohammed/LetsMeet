namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IUserManager
    {
        public string AddUser(User user);
        public string UpdateUser(User user);
        public string DeleteUser(Guid userId);
    }
}
