namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface IPostManager
    {
        public Task<Guid> AddLike(PostAction postAction);
        public Task<Guid> RemoveLike(Guid postId, Guid userId);
    }
}
