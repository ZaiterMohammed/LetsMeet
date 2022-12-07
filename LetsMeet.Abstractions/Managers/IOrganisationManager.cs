namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;

    public interface IOrganisationManager
    {
        public string AddOrganisation(Organisation organisation);
        public string UpdateOrganisation(Organisation organisation);
        public string DeleteOrganisation(Guid organisationId);
        public string CreateRole(Role role);
        public string AcceptRole(Role role);
        public string DeleteRole(Guid roleId);
    }
}
