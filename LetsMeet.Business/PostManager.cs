namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Notifications;
    using LetsMeet.Redis;
    using LetsMeet.WebApi;
    using LetsMeet.WebApi.RabbitMQ;
    using System;
    using System.Threading.Tasks;

    public class PostManager : IPostManager
    {
        private readonly IPostStore postStore;
        private readonly IOrganisationStore organisationStore;
        private readonly ICacheService cachingService;
        private readonly IRabitMQProducer messageBroker;

        public PostManager(IPostStore postStore, IOrganisationStore organisationStore, ICacheService cacheService, IRabitMQProducer messageBroker)
        {
            if (postStore == null)
            {
                throw new ArgumentNullException(nameof(postStore));
            }
            if (organisationStore == null)
            {
                throw new ArgumentNullException(nameof(organisationStore));
            }
            if (cacheService == null)
            {
                throw new ArgumentNullException(nameof(cacheService));
            }
            this.postStore = postStore;
            this.organisationStore = organisationStore;
            cachingService = cacheService;

            this.messageBroker = messageBroker ?? throw new ArgumentNullException(nameof(messageBroker));

        }

        public async Task<Guid> AddLike(PostAction postAction)
        {
            if (postAction == null)
            {
                throw new ArgumentNullException(nameof(postAction));
            }
            var post = organisationStore.GetPostById(postAction.PostId);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            var obj = await postStore.AddLike(postAction);

            messageBroker.SendProductMessage(postAction.PostId);
            return obj;
        }
        public async Task<Guid> RemoveLike(Guid postId, Guid userId)
        {
            var post = organisationStore.GetPostById(postId);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
             await postStore.RemoveLike(postId, userId);

            cachingService.RemoveData($"like:{postId}");

            return postId;
        }

    }
}
