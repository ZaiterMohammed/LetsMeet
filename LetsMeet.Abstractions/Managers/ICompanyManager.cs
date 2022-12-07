namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface ICompanyManager
    {
        public string AddCompany(Company company);
        public string UpdateCompany(Company company);
        public string DeleteCompany(Guid companyId);
        public string CreateRole(Role role);
        public string AcceptRole(Role role);
        public string DeleteRole(Guid roleId);
        public Role GetRoleByUserId(Guid userId);
    }
}
