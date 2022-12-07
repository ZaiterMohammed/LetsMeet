namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;

    internal class OrganisationManager : IOrganisationManager
    {
        private readonly IOrganisationStore organisationStore;

        public OrganisationManager(IOrganisationStore organisationStore)
        {
            this.organisationStore = organisationStore;
        }

        public string AddOrganisation(Organisation organisation)
        {
            return organisationStore.AddOrganisation(organisation);
        }
        public string UpdateOrganisation(Organisation organisation)
        {
            return organisationStore.UpdateOrganisation(organisation);
        }
        public string DeleteOrganisation(Guid organisationId)
        {
            return organisationStore.DeleteOrganisation(organisationId);
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

            return organisationStore.CreateRole(role);
        }
        public string AcceptRole(Role role)
        {
            return organisationStore.AcceptRole(role);
        }
        public string DeleteRole(Guid roleId)
        {
            return organisationStore.DeleteRole(roleId);
        }
        public Role GetRoleByUserId(Guid userId)
        {
            return organisationStore.GetRoleByUserId(userId);
        }
    }
}
