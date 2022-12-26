namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface IPostStore
    {
        public Task<Guid> AddLike(PostAction postAction);
        public Task<Guid> RemoveLike(Guid postId, Guid userId);
    }
}
