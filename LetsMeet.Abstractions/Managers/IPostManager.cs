namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IPostManager
    {
        public string AddPost(Post post);
        public string UpdatePost(Post post);
        public string DeletePost(Guid postId);
    }
}
