namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface ICompanyStore
    {
        public string AddCompany(Company company);
        public string UpdateCompany(Company company);
        public string DeleteCompany(Guid companyId);
        public string CreateRole(Role role);
        public string AcceptRole(Role role);
        public string DeleteRole(Guid roleId);
    }
}
