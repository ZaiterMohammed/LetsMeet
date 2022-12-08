namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IOrganisationStore
    {
        public string AddOrganisation(CreateOrganisationRequest organisationRequest);
        public string UpdateOrganisation(CreateOrganisationRequest organisationRequest);
        public string DeleteOrganisation(Guid organisationId);
        public string CreateRole(Guid id, Guid userId, string roleName);
        public string AcceptRole(Guid id, Guid userId, string roleName);
        public string DeleteRole(Guid roleId);
        public Role GetRoleByUserId(Guid userId);
        public string AddPost(CreatePostRequest createPostRequest);
        public string UpdatePost(CreatePostRequest createPostRequest);
        public string DeletePost(Guid postId, Guid companyId);
        public Post GetPostById(Guid postId);

    }
}
