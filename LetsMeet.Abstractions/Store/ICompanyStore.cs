﻿namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface ICompanyStore
    {
        public string AddCompany(CreateCompanyRequest company);
        public string UpdateCompany(CreateCompanyRequest company);
        public string DeleteCompany(Guid companyId);
        public string CreateRole(Guid id, Guid userId, string roleName);
        public string AcceptRole(Guid id, Guid userId, string roleName);
        public string DeleteRole(Guid roleId);
        public Role GetRoleByUserId(Guid userId);
        public string AddPost(Post post);
        public string UpdatePost(Post post);
        public string DeletePost(Guid postId, Guid companyId);
        public Post GetPostById(Guid postId);

    }
}
