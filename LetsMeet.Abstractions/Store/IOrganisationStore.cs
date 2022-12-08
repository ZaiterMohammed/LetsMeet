namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IOrganisationStore
    {
        public string AddOrganisation(Organisation organisation);
        public string UpdateOrganisation(Organisation organisation);
        public string DeleteOrganisation(Guid organisationId);
        public string CreateRole(Role role);
        public string AcceptRole(Role role);
        public string DeleteRole(Guid roleId);
        public Role GetRoleByUserId(Guid userId);
        public string AddPost(Post post);
        public string UpdatePost(Post post);
        public string DeletePost(Guid postId, Guid companyId);
        public Post GetPostById(Guid postId);

    }
}
