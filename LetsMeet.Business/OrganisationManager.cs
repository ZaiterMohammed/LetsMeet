namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Redis;
    using LetsMeet.WebApi.RabbitMQ;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OrganisationManager : IOrganisationManager
    {
        private readonly IOrganisationStore organisationStore;
        private readonly IRabitMQProducer messageBroker;
        private readonly ICacheService cachingService;

        public OrganisationManager(IOrganisationStore organisationStore, ICacheService cacheService, IRabitMQProducer rabitMQProducer)
        {
            if (organisationStore == null)
            {
                throw new ArgumentNullException(nameof(organisationStore));
            }
            this.organisationStore = organisationStore;
            this.cachingService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.messageBroker = rabitMQProducer ?? throw new ArgumentNullException(nameof(rabitMQProducer));

        }
        public async Task<Guid> CreateOrganisation(CreateOrganisationRequest organisationRequest, int IsFeatured)
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
            var organisationId = await organisationStore.CreateOrganisation(organisationRequest, 0);

            messageBroker.SendProductMessage(organisationId);

            return organisationId;
        }
        public async Task<Guid> UpdateOrganisation(UpdateOrganisationRequest updateOrganisationRequest)
        {
            if (updateOrganisationRequest == null)
            {
                throw new ArgumentNullException(nameof(updateOrganisationRequest));
            }

            var organisationId = await organisationStore.UpdateOrganisation(updateOrganisationRequest);

            cachingService.RemoveData($"organisation:{organisationId}");

            return organisationId;
        }
        public async Task<Guid> RemoveOrganisation(Guid organisationId)
        {
            var organization = await organisationStore.GetOrganisattionById(organisationId);

            if (organization == null)
            {
                throw new ArgumentNullException(nameof(organization));
            }

            await organisationStore.RemoveOrganisation(organisationId);

            cachingService.RemoveData($"organisation:{organisationId}");


            return organisationId;
        }
        public async Task<Guid> CreateRole(Guid id, Guid userId, string roleName)
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

            var roleId = await organisationStore.CreateRole(id, userId, roleName);

            messageBroker.SendProductMessage(roleId);

            return roleId;
        }
        public async Task<Guid> AcceptRole(Guid id, Guid userId, string roleName)
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
            var roleId = await organisationStore.AcceptRole(id, userId, roleName);

            cachingService.RemoveData($"role:{roleId}");

            return roleId;
        }
        public async Task<Guid> RemoveRole(Guid roleId)
        {

            if (roleId == null)
            {
                throw new ArgumentNullException(nameof(roleId));
            }
            await organisationStore.RemoveRole(roleId);

            cachingService.RemoveData($"role:{roleId}");

            return roleId;
        }
        public async Task<Role> GetRoleByUserId(Guid userId)
        {

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var cacheData = cachingService.GetData<Role>($"role{userId}");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

            cacheData = await organisationStore.GetRoleByUserId(userId);

            cachingService.SetData<Role>($"role:{userId}", cacheData, expirationTime);
           
            return cacheData;
        }

        public async Task<Guid> CreatePost(CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null)
            {
                throw new ArgumentNullException(nameof(createPostRequest));
            }


            var postId = await organisationStore.CreatePost(createPostRequest);

            messageBroker.SendProductMessage(postId);

            return postId;
        }
        public async Task<Guid> UpdatePost(CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null)
            {
                throw new ArgumentNullException(nameof(createPostRequest));
            }

            var postId = await organisationStore.UpdatePost(createPostRequest);

            cachingService.RemoveData($"post:{postId}");

            return postId;
        }
        public async Task<Guid> RemovePost(Guid postId, Guid companyId)
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

            await organisationStore.RemovePost(postId, companyId);

            cachingService.RemoveData($"post:{postId}");

            return postId;
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            if (postId == null)
            {
                throw new ArgumentNullException(nameof(postId));
            }

            var cacheData = cachingService.GetData<Post>($"post{postId}");
            if (cacheData != null)
            {
                return cacheData;
            }

            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

            cacheData = await organisationStore.GetPostById(postId);

            cachingService.SetData<Post>($"post:{postId}", cacheData, expirationTime);

            return cacheData;
        }

        public async Task<IEnumerable<Organisation>> GetAllOrganisation()
        {
            var cacheData = cachingService.GetData<IEnumerable<Organisation>>("organisation");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

            cacheData = await organisationStore.GetAllOrganisation();

            cachingService.SetData<IEnumerable<Organisation>>($"organisation", cacheData, expirationTime);
            foreach (var organisation in cacheData)
            {
                cachingService.SetData<IEnumerable<Organisation>>($"organisation:{organisation.OrganisationId}", cacheData, expirationTime);
            }
            return cacheData;
        }

        public async Task<IEnumerable<Organisation>> GetAllOrganisationNotVerified()
        {
            var cacheData = cachingService.GetData<IEnumerable<Organisation>>("organisationNotVerified");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

            cacheData = await organisationStore.GetAllOrganisationNotVerified();

            cachingService.SetData<IEnumerable<Organisation>>($"organisationNotVerified", cacheData, expirationTime);
            foreach (var organisation in cacheData)
            {
                cachingService.SetData<IEnumerable<Organisation>>($"organisation:{organisation.OrganisationId}", cacheData, expirationTime);
            }
            return cacheData;
        }

        public async Task<IEnumerable<Organisation>> GetAllOrganisationVerified()
        {
            var cacheData = cachingService.GetData<IEnumerable<Organisation>>("organisationVerified");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

            cacheData = await organisationStore.GetAllOrganisationVerified();

            cachingService.SetData<IEnumerable<Organisation>>($"organisationVerified", cacheData, expirationTime);
            foreach (var organisation in cacheData)
            {
                cachingService.SetData<IEnumerable<Organisation>>($"organisation:{organisation.OrganisationId}", cacheData, expirationTime);
            }
            return cacheData;
        }

        public async Task<Organisation> GetOrganisattionById(Guid organisationId)
        {
            if (organisationId == null)
            {
                throw new ArgumentNullException(nameof(organisationId));
            }

            var cacheData = cachingService.GetData<Organisation>($"post{organisationId}");
            if (cacheData != null)
            {
                return cacheData;
            }

            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

            cacheData = await organisationStore.GetOrganisattionById(organisationId);

            cachingService.SetData<Organisation>($"organisation:{organisationId}", cacheData, expirationTime);

            return cacheData;
        }

    }
}
