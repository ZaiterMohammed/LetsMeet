namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Collections.Generic;

    public class MunicipalityManager : IMunicipalityManager
    {
        private readonly IMunicipalityStore municipalityStore;

        public MunicipalityManager(IMunicipalityStore municipalityStore)
        {
            this.municipalityStore = municipalityStore;
        }

        public string AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            return municipalityStore.AddMunicipality(createMunicipalityRequest);
        }
        public string UpdateMunicipality(Municipality municipality)
        {
            return municipalityStore.UpdateMunicipality(municipality);
        }
        public string DeleteMunicipality(Guid municipalityId)
        {
            return municipalityStore.DeleteMunicipality(municipalityId);
        }
        public List<Municipality> GetAllMunicipality()
        {
            return municipalityStore.GetAllMunicipality();
        }
        public string AddAdmin(CreateAdminRequest createAdminRequest)
        {
            var admins = GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId);

            if (admins.Count == 0)
            {
                return municipalityStore.AddAdmin(createAdminRequest);
            }
            foreach (var admin in admins)
            {
                if (admin.UserId != createAdminRequest.UserId)
                {
                    throw new Exception("you can no add an admin because you are not admin");
                }
            }

            return municipalityStore.AddAdmin(createAdminRequest);
        }
        public string DeleteAdmin(Guid AdminId, Guid UserId ,Guid MunicipalityId)
        {
            var admins = GetAllAdminsByMunicipalityId(MunicipalityId);

            foreach (var admin in admins)
            {
                if (admin.UserId != UserId)
                {
                    throw new Exception("you can no add an admin because you are not admin");
                }
            }

            return municipalityStore.DeleteAdmin(AdminId, UserId, MunicipalityId);
        }
        public List<Admins> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            return municipalityStore.GetAllAdminsByMunicipalityId(MunicipalityId);
        }
    }
}
