namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IUserStore
    {
        public string AddUser(User user);
        public string UpdateUser(User user);
        public string DeleteUser(Guid userId);
    }
}
