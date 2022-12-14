namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrganisationStore
    {
        public Task<String> AddOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured);
        public Task<String> UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest);
        public Task<String> DeleteOrganisation(Guid organisationId);
        public Task<String> CreateRole(Guid id, Guid userId, string roleName);
        public Task<String> AcceptRole(Guid id, Guid userId, string roleName);
        public Task<String> DeleteRole(Guid roleId);
        public Task<Role> GetRoleByUserId(Guid userId);
        public Task<String> AddPost(CreatePostRequest createPostRequest);
        public Task<String> UpdatePost(CreatePostRequest createPostRequest);
        public Task<String> DeletePost(Guid postId, Guid companyId);
        public Task<Post> GetPostById(Guid postId);
        public Task<List<Organisation>> GetAllOrganisation();
        public Task<List<Organisation>> GetAllOrganisationNotVerified();
        public Task<List<Organisation>> GetAllOrganisationVerified();
        public Task<Organisation> GetOrganisattionById(Guid organisationId);
    }
}
