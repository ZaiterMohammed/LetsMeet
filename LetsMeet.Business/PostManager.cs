using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using LetsMeet.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.Business
{
    public class PostManager : IPostManager
    {
        private readonly IPostStore postStore;

        public PostManager(IPostStore postStore)
        {
            this.postStore = postStore;
        }

        public string AddPost(Post post)
        {
            return postStore.AddPost(post);
        }
        public string UpdatePost(Post post)
        {
            return postStore.UpdatePost(post);
        }
        public string DeletePost(Guid postId)
        {
            return postStore.DeletePost(postId);
        }
    }
}
