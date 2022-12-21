namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MunicipalityManager : IMunicipalityManager
    {
        private readonly IMunicipalityStore municipalityStore;

        public MunicipalityManager(IMunicipalityStore municipalityStore)
        {
            if (municipalityStore == null)
            {
                throw new ArgumentNullException(nameof(municipalityStore));
            }
            this.municipalityStore = municipalityStore;
        }

        public async Task<String> AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            if (createMunicipalityRequest == null)
            {
                throw new ArgumentNullException(nameof(createMunicipalityRequest));
            }

            return await municipalityStore.AddMunicipality(createMunicipalityRequest);
        }
        public async Task<string> UpdateMunicipality(Municipality municipality)
        {
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }

            return await municipalityStore.UpdateMunicipality(municipality);
        }
        public async Task<string> DeleteMunicipality(Guid municipalityId)
        {
            var municipality = await municipalityStore.GetMunicipalityById(municipalityId);
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }

            return await municipalityStore.DeleteMunicipality(municipalityId);
        }
        public async Task<List<Municipality>> GetAllMunicipality()
        {
            return await municipalityStore.GetAllMunicipality();
        }
        public async Task<string> AddAdmin(CreateAdminRequest createAdminRequest)
        {
            if (createAdminRequest == null)
            {
                throw new ArgumentNullException(nameof(createAdminRequest));
            }

            var admins = await GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId);

            if (admins.Count == 0)
            {
                return await municipalityStore.AddAdmin(createAdminRequest);
            }
            foreach (var admin in admins)
            {
                if (admin.UserId != createAdminRequest.UserId)
                {
                    throw new Exception("you can no add an admin because you are not admin");
                }
            }
            return await municipalityStore.AddAdmin(createAdminRequest);
        }
        public async Task<string> DeleteAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId)
        {
            if (AdminId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(AdminId));
            }
            if (UserId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(UserId));
            }
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }

            var admins = await GetAllAdminsByMunicipalityId(MunicipalityId);

            foreach (var admin in admins)
            {
                if (admin.UserId != UserId)
                {
                    throw new Exception("you can no add an admin because you are not admin");
                }
            }
            return await municipalityStore.DeleteAdmin(AdminId, UserId, MunicipalityId);
        }
        public async Task<List<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }

            return await municipalityStore.GetAllAdminsByMunicipalityId(MunicipalityId);
        }

        public async Task<Municipality> GetMunicipalityById(Guid MunicipalityId)
        {
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }

            return await municipalityStore.GetMunicipalityById(MunicipalityId);
        }
    }
}
