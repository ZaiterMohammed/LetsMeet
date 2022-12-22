namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Redis;
    using LetsMeet.WebApi;
    using System;
    using System.Threading.Tasks;

    public class PostManager : IPostManager
    {
        private readonly IPostStore postStore;
        private readonly IOrganisationStore organisationStore;
        private readonly ICacheService _cacheService;

        public PostManager(IPostStore postStore, IOrganisationStore organisationStore, ICacheService cacheService)
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
            _cacheService = cacheService;
        }


        public async Task<String> AddLike(PostAction postAction)
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
            _cacheService.RemoveData("postaction");

            return obj;
        }
        public async Task<String> DeleteLike(Guid postId, Guid userId)
        {
            var post = organisationStore.GetPostById(postId);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            var filteredData = await postStore.DeleteLike(postId, userId);
            _cacheService.RemoveData("postaction");
            return await postStore.DeleteLike(postId, userId);
        }
    }
}
