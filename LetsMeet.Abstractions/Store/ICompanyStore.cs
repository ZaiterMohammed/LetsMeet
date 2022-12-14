namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface ICompanyStore
    {
        // add companyId
        public Task<String> AddCompany(CreateCompanyRequest createCompanyRequest);
        public Task<String> UpdateCompany(CreateCompanyRequest createCompanyRequest);
        public Task<String> DeleteCompany(Guid companyId);
        public Task<String> CreateRole(Guid id, Guid userId, string roleName);
        public Task<String> AcceptRole(Guid id, Guid userId, string roleName);
        public Task<String> DeleteRole(Guid roleId);
        public Task<Role> GetRoleByUserId(Guid userId);
        public Task<String> AddPost(CreatePostRequest createPostRequest);
        public Task<String> UpdatePost(CreatePostRequest createPostRequest);
        public Task<String> DeletePost(Guid postId, Guid companyId);
        public Task<Post> GetPostById(Guid postId);
    }
}
