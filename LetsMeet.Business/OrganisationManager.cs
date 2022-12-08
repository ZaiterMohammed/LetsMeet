namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;

    public class OrganisationManager : IOrganisationManager
    {
        private readonly IOrganisationStore organisationStore;

        public OrganisationManager(IOrganisationStore organisationStore)
        {
            this.organisationStore = organisationStore;
        }

        public string AddOrganisation(CreateOrganisationRequest organisationRequest)
        {
            return organisationStore.AddOrganisation(organisationRequest);
        }
        public string UpdateOrganisation(CreateOrganisationRequest organisationRequest)
        {
            return organisationStore.UpdateOrganisation(organisationRequest);
        }
        public string DeleteOrganisation(Guid organisationId)
        {
            return organisationStore.DeleteOrganisation(organisationId);
        }
        public string CreateRole(Guid id, Guid userId, string roleName)
        {
            var RoleByUserId = GetRoleByUserId(userId);

            if (RoleByUserId == null)
            {
                throw new ArgumentNullException("role Cannot be bull");
            }

            return organisationStore.CreateRole(id, userId, roleName);
        }
        public string AcceptRole(Guid id, Guid userId, string roleName)
        {
            return organisationStore.AcceptRole(id, userId, roleName);
        }
        public string DeleteRole(Guid roleId)
        {
            return organisationStore.DeleteRole(roleId);
        }
        public Role GetRoleByUserId(Guid userId)
        {
            return organisationStore.GetRoleByUserId(userId);
        }

        public string AddPost(CreatePostRequest createPostRequest)
        {
            return organisationStore.AddPost(createPostRequest);
        }
        public string UpdatePost(CreatePostRequest createPostRequest)
        {
            return organisationStore.UpdatePost(createPostRequest);
        }
        public string DeletePost(Guid postId, Guid companyId)
        {
            // null validation

            var post = this.GetPostById(postId);
            if (post == null)
            {
                throw new NullReferenceException("The specified post cannot be undefined or null.");
            }

            if (companyId != GetPostById(postId).CreatedBy)
            {
                return "cannet delete this post";
            }
            return organisationStore.DeletePost(postId, companyId);
        }

        public Post GetPostById(Guid postId)
        {
            return organisationStore.GetPostById(postId);
        }

    }
}
