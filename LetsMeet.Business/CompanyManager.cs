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
    }
}
