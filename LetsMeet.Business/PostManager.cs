namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Threading.Tasks;

    public class PostManager : IPostManager
    {
        private readonly IPostStore postStore;
        private readonly IOrganisationStore organisationStore;
        public PostManager(IPostStore postStore , IOrganisationStore organisationStore)
        {
            if (postStore == null)
            {
                throw new ArgumentNullException(nameof(postStore));
            }
            if (organisationStore == null)
            {
                throw new ArgumentNullException(nameof(organisationStore));
            }

            this.postStore = postStore;
            this.organisationStore = organisationStore;
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

            return await postStore.AddLike(postAction);
        }
        public async Task<String> DeleteLike(Guid postId, Guid userId)
        {
            var post = organisationStore.GetPostById(postId);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            
            return await postStore.DeleteLike(postId, userId);
        }
    }
}
