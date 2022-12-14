namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Threading.Tasks;

    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyStore companyStore;
        public CompanyManager(ICompanyStore companyStore)
        {
            if(companyStore == null)
            {
                throw new ArgumentNullException(nameof(companyStore));
            }

            this.companyStore = companyStore;
        }

        public async Task<String> AddCompany(CreateCompanyRequest createCompanyRequest)
        {
            if(createCompanyRequest == null)
            {
                throw new ArgumentNullException(nameof(createCompanyRequest));
            }

            return await companyStore.AddCompany(createCompanyRequest);
        }

        public async Task<String> UpdateCompany(CreateCompanyRequest createCompanyRequest)
        {
            if (createCompanyRequest == null)
            {
                throw new ArgumentNullException(nameof(createCompanyRequest));
            }

            return await companyStore.UpdateCompany(createCompanyRequest);
        }
        public async Task<String> DeleteCompany(Guid companyId)
        {
            // get company by id to test 
            return await companyStore.DeleteCompany(companyId);
        }
        public async Task<String> CreateRole(Guid id, Guid userId, string roleName)
        {
            // check if company exists
            var RoleByUserId = GetRoleByUserId(userId);

            if (RoleByUserId == null)
            {
                throw new ArgumentNullException("role Cannot be bull");
            }
            return await companyStore.CreateRole(id, userId, roleName);
        }

        public async Task<String> AcceptRole(Guid id, Guid userId, string roleName)
        {
            return await companyStore.AcceptRole(id, userId, roleName);
        }

        public async Task<String> DeleteRole(Guid roleId)
        {
            return await companyStore.DeleteRole(roleId);
        }

        public async Task<Role> GetRoleByUserId(Guid userId)
        {
            return await companyStore.GetRoleByUserId(userId);
        }


        public async Task<String> AddPost(CreatePostRequest createPostRequest)
        {
            return await companyStore.AddPost(createPostRequest);
        }
        public async Task<String> UpdatePost(CreatePostRequest createPostRequest)
        {
            return await companyStore.UpdatePost(createPostRequest);
        }
        public async Task<String> DeletePost(Guid postId, Guid companyId)
        {
            // null validation

            var post = await this.GetPostById(postId);
            if (post == null)
            {
                throw new NullReferenceException("The specified post cannot be undefined or null.");
            }

            if (companyId != post.CreatedBy)
            {
                return "cannet delete this post";
            }
            return await companyStore.DeletePost(postId, companyId);
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            return await companyStore.GetPostById(postId);
        }

    }
}
