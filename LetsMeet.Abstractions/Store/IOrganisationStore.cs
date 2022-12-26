namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrganisationStore
    {
        public Task<Guid> CreateOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured);
        public Task<Guid> UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest);
        public Task<Guid> RemoveOrganisation(Guid organisationId);
        public Task<Guid> CreateRole(Guid id, Guid userId, string roleName);
        public Task<Guid> AcceptRole(Guid id, Guid userId, string roleName);
        public Task<Guid> RemoveRole(Guid roleId);
        public Task<Role> GetRoleByUserId(Guid userId);
        public Task<Guid> CreatePost(CreatePostRequest createPostRequest);
        public Task<Guid> UpdatePost(CreatePostRequest createPostRequest);
        public Task<Guid> RemovePost(Guid postId, Guid companyId);
        public Task<Post> GetPostById(Guid postId);
        public Task<IEnumerable<Organisation>> GetAllOrganisation();
        public Task<IEnumerable<Organisation>> GetAllOrganisationNotVerified();
        public Task<IEnumerable<Organisation>> GetAllOrganisationVerified();
        public Task<Organisation> GetOrganisattionById(Guid organisationId);
    }
}
