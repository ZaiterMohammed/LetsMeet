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
    }
}
