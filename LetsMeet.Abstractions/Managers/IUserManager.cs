namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IUserManager
    {
        public string AddUser(CreateRequestUser createRequestUser);
        public string UpdateUser(CreateRequestUser createRequestUser);
        public string DeleteUser(Guid userId);
    }
}
