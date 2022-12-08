namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Runtime.ConstrainedExecution;

    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyStore companyStore;

        public CompanyManager(ICompanyStore companyStore)
        {
            this.companyStore = companyStore;
        }


        public string AddCompany(Company company)
        {
            return companyStore.AddCompany(company);
        }

        public string UpdateCompany(Company company)
        {
            return companyStore.UpdateCompany(company);
        }
        public string DeleteCompany(Guid companyId)
        {
            return companyStore.DeleteCompany(companyId);
        }
        public string CreateRole(Role role)
        {
            if (role == null)
            {
              throw new ArgumentNullException("role Cannot be bull");
            }

            var RoleByUserId = GetRoleByUserId(role.UserId);

            if (RoleByUserId == null)
            {
                throw new ArgumentNullException("role Cannot be bull");
            }
            return companyStore.CreateRole(role);
        }

        public string AcceptRole(Role role)
        {
            return companyStore.AcceptRole(role);
        }

        public string DeleteRole(Guid roleId)
        {
            return companyStore.DeleteRole(roleId);
        }

        public Role GetRoleByUserId(Guid userId)
        {
            return companyStore.GetRoleByUserId(userId);
        }


        public string AddPost(Post post)
        {
            return companyStore.AddPost(post);
        }
        public string UpdatePost(Post post)
        {
            return companyStore.UpdatePost(post);
        }
        public string DeletePost(Guid postId, Guid companyId)
        {
            // null validation

            var post = this.GetPostById(postId);
            if (post == null)
            {
                throw new NullReferenceException("The specified post cannot be undefined or null.");
            }

            if (companyId != GetPostById(postId).CompanyId)
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
