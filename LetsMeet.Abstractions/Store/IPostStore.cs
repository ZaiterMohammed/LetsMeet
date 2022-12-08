﻿namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IPostStore
    {
        public string AddPost(Post post);
        public string UpdatePost(Post post);
        public string DeletePost(Guid postId, Guid companyId);
        public Post GetPostById(Guid postId);
        public string AddLike(PostAction postAction);
        public string DeleteLike(Guid postActionId);
    }
}
