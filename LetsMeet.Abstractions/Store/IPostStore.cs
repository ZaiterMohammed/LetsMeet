namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IPostStore
    {
        public string AddLike(PostAction postAction);
        public string DeleteLike(Guid postId, Guid userId);
    }
}
