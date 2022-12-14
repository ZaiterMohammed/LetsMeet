namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface IUserStore
    {
        public Task<String> AddUser(CreateRequestUser createRequestUser);
        public Task<String> UpdateUser(CreateRequestUser createRequestUser);
        public Task<String> DeleteUser(Guid userId);
    }
}
