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
        public string DeletePost(Guid postId ,Guid companyId)
        {
            // null validation

            var post = this.GetPostById(postId);
            if(post == null)
            {
                throw new NullReferenceException("The specified post cannot be undefined or null.");
            }

            if(companyId != GetPostById(postId).CompanyId)
            {
                return "cannet delete this post";
            }
            return postStore.DeletePost(postId, companyId);
        }

        public Post GetPostById(Guid postId)
        {
            return postStore.GetPostById(postId);
        }

        public string AddLike(PostAction postAction)
        {
            return postStore.AddLike(postAction);
        }
        public string DeleteLike(Guid postActionId)
        {
            return postStore.DeleteLike(postActionId);
        }
    }
}
