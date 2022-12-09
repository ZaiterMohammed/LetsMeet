namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;

    public interface IMunicipalityManager
    {
        public string AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest);
        public string UpdateMunicipality(Municipality municipality);
        public string DeleteMunicipality(Guid municipalityId);
        public List<Municipality> GetAllMunicipality();
        public string AddAdmin(CreateAdminRequest createAdminRequest);
        public string DeleteAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId);
        public List<Admins> GetAllAdminsByMunicipalityId(Guid MunicipalityId);
    }
}
