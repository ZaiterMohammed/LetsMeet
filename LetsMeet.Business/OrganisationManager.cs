namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OrganisationManager : IOrganisationManager
    {
        private readonly IOrganisationStore organisationStore;
        public OrganisationManager(IOrganisationStore organisationStore)
        {
            if (organisationStore == null)
            {
                throw new ArgumentNullException(nameof(organisationStore));
            }
            this.organisationStore = organisationStore;
        }
        public async Task<String> AddOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured)
        {
            if (organisationRequest == null)
            {
                throw new ArgumentNullException(nameof(organisationRequest));
            }
            if (IsFeatured == 0)
            {
                throw new ArgumentNullException(nameof(IsFeatured));
            }
            //and i can put it in the UserStore when i create a user to each organisation
            // var users = GetUsersByMunicipalityId(organisationRequest.OrganisationId); //select * from User where OrganisationId = organisationRequest.OrganisationId and IsFeatured = 1

            // if (users.Count > 10)
            // {
            //    return organisationStore.AddOrganisation(organisationRequest, IsFeatured);
            // }
            return await organisationStore.AddOrganisation(organisationRequest, 0);
        }
        public async Task<string> UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest)
        {
            if (updateOrganisationRequest == null)
            {
                throw new ArgumentNullException(nameof(updateOrganisationRequest));
            }
            return await organisationStore.UpdateOrganisation(updateOrganisationRequest);
        }
        public async Task<string> DeleteOrganisation(Guid organisationId)
        {
            var organization = await organisationStore.GetOrganisattionById(organisationId);

            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }
            return await organisationStore.DeleteOrganisation(organisationId);
        }
        public async Task<string> CreateRole(Guid id, Guid userId, string roleName)
        {

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            if (roleName == null)
            {
                throw new ArgumentNullException(nameof(roleName));
            }

            var RoleByUserId =await GetRoleByUserId(userId);

            if (RoleByUserId == null)
            {
                throw new ArgumentNullException("role Cannot be bull");
            }

            return await organisationStore.CreateRole(id, userId, roleName);
        }
        public async Task<string> AcceptRole(Guid id, Guid userId, string roleName)
        {

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            if (roleName == null)
            {
                throw new ArgumentNullException(nameof(roleName));
            }

            return await organisationStore.AcceptRole(id, userId, roleName);
        }
        public async Task<string> DeleteRole(Guid roleId)
        {

            if (roleId == null)
            {
                throw new ArgumentNullException(nameof(roleId));
            }
            return await organisationStore.DeleteRole(roleId);
        }
        public async Task<Role> GetRoleByUserId(Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            return await organisationStore.GetRoleByUserId(userId);
        }

        public async Task<string> AddPost(CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null)
            {
                throw new ArgumentNullException(nameof(createPostRequest));
            }
            return await organisationStore.AddPost(createPostRequest);
        }
        public async Task<string> UpdatePost(CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null)
            {
                throw new ArgumentNullException(nameof(createPostRequest));
            }
            return await organisationStore.UpdatePost(createPostRequest);
        }
        public async Task<string> DeletePost(Guid postId, Guid companyId)
        {
            if (postId == null)
            {
                throw new ArgumentNullException(nameof(postId));
            }
            if (companyId == null)
            {
                throw new ArgumentNullException(nameof(companyId));
            }


            var post = await this.GetPostById(postId);
            if (post == null)
            {
                throw new NullReferenceException("The specified post cannot be undefined or null.");
            }

            if (companyId != post.CreatedBy)
            {
                return "cannet delete this post";
            }
            return await organisationStore.DeletePost(postId, companyId);
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            if (postId == null)
            {
                throw new ArgumentNullException(nameof(postId));
            }
            return await organisationStore.GetPostById(postId);
        }

        public async Task<List<Organisation>> GetAllOrganisation()
        {
            return await organisationStore.GetAllOrganisation();
        }

        public async Task<List<Organisation>> GetAllOrganisationNotVerified()
        {
            return await organisationStore.GetAllOrganisationNotVerified();
        }
        public async Task<List<Organisation>> GetAllOrganisationVerified()
        {
            return await organisationStore.GetAllOrganisationVerified();
        }

        public async Task<Organisation> GetOrganisattionById(Guid organisationId)
        {
            if (organisationId == null)
            {
                throw new ArgumentNullException(nameof(organisationId));
            }
            return await organisationStore.GetOrganisattionById(organisationId);
        }
    }
}
