namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface IPostStore
    {
        public Task<String> AddLike(PostAction postAction);
        public Task<String> DeleteLike(Guid postId, Guid userId);
    }
}
