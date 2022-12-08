namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IPostManager
    {
        public string AddLike(PostAction postAction);
        public string DeleteLike(Guid postId, Guid userId);
    }
}
