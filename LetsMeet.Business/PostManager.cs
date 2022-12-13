namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    public class PostManager : IPostManager
    {
        private readonly IPostStore postStore;
        public PostManager(IPostStore postStore)
        {
            this.postStore = postStore;
        }

        public string AddLike(PostAction postAction)
        {
            //null check
            //posts exists or not
            return postStore.AddLike(postAction);
        }
        public string DeleteLike(Guid postId, Guid userId)
        {
            return postStore.DeleteLike(postId, userId);
        }
    }
}
