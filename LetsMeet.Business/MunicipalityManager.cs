namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Redis;
    using LetsMeet.WebApi;
    using LetsMeet.WebApi.RabbitMQ;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MunicipalityManager : IMunicipalityManager
    {
        private readonly IMunicipalityStore municipalityStore;
        private readonly ICacheService _cacheService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public MunicipalityManager(IMunicipalityStore municipalityStore, ICacheService cacheService, IRabitMQProducer rabitMQProducer)
        {
            if (municipalityStore == null)
            {
                throw new ArgumentNullException(nameof(municipalityStore));
            }
            if (cacheService == null)
            {
                throw new ArgumentNullException(nameof(cacheService));
            }
            if (rabitMQProducer == null)
            {
                throw new ArgumentNullException(nameof(rabitMQProducer));
            }
            this.municipalityStore = municipalityStore;
            _cacheService = cacheService;
            _rabitMQProducer = rabitMQProducer;
        }

        public async Task<String> AddMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            if (createMunicipalityRequest == null)
            {
                throw new ArgumentNullException(nameof(createMunicipalityRequest));
            }
            var obj = await municipalityStore.AddMunicipality(createMunicipalityRequest);
             _cacheService.RemoveData("municipality");

            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendProductMessage(obj);
          
            return obj;
        }
        public async Task<string> UpdateMunicipality(Municipality municipality)
        {
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            var responce = await municipalityStore.UpdateMunicipality(municipality);
             _cacheService.RemoveData("municipality");

            return responce;
        }
        public async Task<string> DeleteMunicipality(Guid municipalityId)
        {
            var municipality = await municipalityStore.GetMunicipalityById(municipalityId);
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            var filteredData = await municipalityStore.DeleteMunicipality(municipalityId);
            //_cacheService.RemoveData("municipality");

            return filteredData;
        }
        public async Task<IEnumerable<Municipality>> GetAllMunicipality()
        {

            var cacheData = _cacheService.GetData<IEnumerable<Municipality>>("municipality");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = await municipalityStore.GetAllMunicipality();
            _cacheService.SetData<IEnumerable<Municipality>>("municipality", cacheData, expirationTime);


            return cacheData;
        }


        public async Task<Municipality> GetMunicipalityById(Guid MunicipalityId)
        {
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }


            Municipality filteredData;
            var cacheData = _cacheService.GetData<IEnumerable<Municipality>>("municipality");
            if (cacheData == null)
            {
                throw new ArgumentNullException(nameof(cacheData));
            }
            filteredData = await municipalityStore.GetMunicipalityById(MunicipalityId);
            return filteredData;
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

    }
}
