namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IUserStore
    {
        public string AddUser(CreateRequestUser createRequestUser);
        public string UpdateUser(CreateRequestUser createRequestUser);
        public string DeleteUser(Guid userId);
    }
}
