namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;

    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyStore companyStore;
        public CompanyManager(ICompanyStore companyStore)
        {
            this.companyStore = companyStore;
        }

        public string AddCompany(CreateCompanyRequest createCompanyRequest)
        {
            return companyStore.AddCompany(createCompanyRequest);
        }

        public string UpdateCompany(CreateCompanyRequest createCompanyRequest)
        {
            return companyStore.UpdateCompany(createCompanyRequest);
        }
        public string DeleteCompany(Guid companyId)
        {
            return companyStore.DeleteCompany(companyId);
        }
        public string CreateRole(Guid id, Guid userId, string roleName)
        {
            var RoleByUserId = GetRoleByUserId(userId);

            if (RoleByUserId == null)
            {
                throw new ArgumentNullException("role Cannot be bull");
            }
            return companyStore.CreateRole(id, userId, roleName);
        }

        public string AcceptRole(Guid id, Guid userId, string roleName)
        {
            return companyStore.AcceptRole(id, userId, roleName);
        }

        public string DeleteRole(Guid roleId)
        {
            return companyStore.DeleteRole(roleId);
        }

        public Role GetRoleByUserId(Guid userId)
        {
            return companyStore.GetRoleByUserId(userId);
        }


        public string AddPost(CreatePostRequest createPostRequest)
        {
            return companyStore.AddPost(createPostRequest);
        }
        public string UpdatePost(CreatePostRequest createPostRequest)
        {
            return companyStore.UpdatePost(createPostRequest);
        }
        public string DeletePost(Guid postId, Guid companyId)
        {
            // null validation

            var post = this.GetPostById(postId);
            if (post == null)
            {
                throw new NullReferenceException("The specified post cannot be undefined or null.");
            }

            if (companyId != GetPostById(postId).CreatedBy)
            {
                return "cannet delete this post";
            }
            return companyStore.DeletePost(postId, companyId);
        }

        public Post GetPostById(Guid postId)
        {
            return companyStore.GetPostById(postId);
        }

    }
}
