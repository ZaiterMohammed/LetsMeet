namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMunicipalityManager
    {
        public Task<Guid> CreateMunicipality(CreateMunicipalityRequest createMunicipalityRequest);
        public Task<Guid> UpdateMunicipality(Municipality municipality);
        public Task<Guid> RemoveMunicipality(Guid municipalityId);
        public Task<IEnumerable<Municipality>> GetAllMunicipality();
        public Task<Guid> AssignAdmin(Guid municipalityId,Guid userId);
        public Task<Guid> RemoveAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId);
        public Task<IEnumerable<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId);
        public Task<Municipality> GetMunicipalityById(Guid MunicipalityId);
    }
}
