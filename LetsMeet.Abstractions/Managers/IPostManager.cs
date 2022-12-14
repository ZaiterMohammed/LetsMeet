namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Threading.Tasks;

    public interface IPostManager
    {
        public Task<String> AddLike(PostAction postAction);
        public Task<String> DeleteLike(Guid postId, Guid userId);
    }
}
