namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface IUserManager
    {
        public Task<String> AddUser(CreateRequestUser createRequestUser);
        public Task<String> UpdateUser(CreateRequestUser createRequestUser);
        public Task<String> DeleteUser(Guid userId);
    }
}
