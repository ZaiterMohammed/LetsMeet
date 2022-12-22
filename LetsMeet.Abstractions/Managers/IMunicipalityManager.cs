﻿namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMunicipalityManager
    {
        public Task<String> AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest);
        public Task<String> UpdateMunicipality(Municipality municipality);
        public Task<String> DeleteMunicipality(Guid municipalityId);
        public Task<IEnumerable<Municipality>> GetAllMunicipality();
        public Task<String> AddAdmin(CreateAdminRequest createAdminRequest);
        public Task<String> DeleteAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId);
        public Task<List<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId);
        public Task<Municipality> GetMunicipalityById(Guid MunicipalityId);
    }
}
