namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Notifications;
    using LetsMeet.Redis;
    using LetsMeet.WebApi.RabbitMQ;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MunicipalityManager : IMunicipalityManager
    {
        private readonly IMunicipalityStore municipalityStore;
        private readonly ICacheService cachingService;
        private readonly IRabitMQProducer messageBroker;

        public MunicipalityManager(IMunicipalityStore municipalityStore, ICacheService cacheService, IRabitMQProducer rabitMQProducer)
        {
            this.municipalityStore = municipalityStore ?? throw new ArgumentNullException(nameof(municipalityStore));
            this.cachingService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this.messageBroker = rabitMQProducer ?? throw new ArgumentNullException(nameof(rabitMQProducer));
        }

        public async Task<Guid> CreateMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            if (createMunicipalityRequest == null)
            {
                throw new ArgumentNullException(nameof(createMunicipalityRequest));
            }

            var municipalityId = await municipalityStore.CreateMunicipality(createMunicipalityRequest);

            messageBroker.SendProductMessage(new NotificationMessage() { Type = NotificationType.MunicipalityCreated, Id = municipalityId });

            return municipalityId;
        }

        public async Task<Guid> UpdateMunicipality(Municipality municipality)
        {
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            var responceMuniciId = await municipalityStore.UpdateMunicipality(municipality);

            cachingService.RemoveData($"municipality:{municipality.MunicipalityId}");

            return responceMuniciId;
        }

        public async Task<Guid> RemoveMunicipality(Guid municipalityId)
        {
            var municipality = await municipalityStore.GetMunicipalityById(municipalityId);
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            var responceMuniciId = await municipalityStore.RemoveMunicipality(municipalityId);

            cachingService.RemoveData($"municipality:{municipalityId}");

            return responceMuniciId;
        }
        public async Task<IEnumerable<Municipality>> GetAllMunicipality()
        {

            var cacheData = cachingService.GetData<IEnumerable<Municipality>>("municipality");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = await municipalityStore.GetAllMunicipality();
            cachingService.SetData<IEnumerable<Municipality>>($"municipality", cacheData, expirationTime);
            foreach ( var municipality in cacheData)
            {
                cachingService.SetData<IEnumerable<Municipality>>($"municipality:{municipality.MunicipalityId}", cacheData, expirationTime);
            }
            return cacheData;
        }


        public async Task<Municipality> GetMunicipalityById(Guid MunicipalityId)
        {
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }

            Municipality filteredData;
            var cacheData = cachingService.GetData<IEnumerable<Municipality>>($"municipality{MunicipalityId}");
            if (cacheData == null)
            {
                throw new ArgumentNullException(nameof(cacheData));
            }
            filteredData = await municipalityStore.GetMunicipalityById(MunicipalityId);
            return filteredData;
        }


        public async Task<Guid> AssignAdmin(Guid municipalityId , Guid userId)
        {
            if (municipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(municipalityId));
            }
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var admins = await GetAllAdminsByMunicipalityId(municipalityId);

            if (admins.Count() == 0)
            {
                return await municipalityStore.AssignAdmin(municipalityId , userId);
            }
            foreach (var admin in admins)
            {
                if (admin.UserId != userId)
                {
                    throw new Exception("you can no add an admin because you are not admin");
                }
            }

            messageBroker.SendProductMessage(new NotificationMessage()
            {
                Type = NotificationType.MunicipalityCreated,
                Id = municipalityId
            });

            return await municipalityStore.AssignAdmin(municipalityId,userId);
        }
        public async Task<Guid> RemoveAdmin(Guid AdminId, Guid UserId, Guid MunicipalityId)
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

            cachingService.RemoveData($"municipality:{AdminId}");

            return await municipalityStore.RemoveAdmin(AdminId, UserId, MunicipalityId);
        }
        public async Task<IEnumerable<Admins>> GetAllAdminsByMunicipalityId(Guid MunicipalityId)
        {
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }

            var cacheData = cachingService.GetData<IEnumerable<Admins>>("admins");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = await municipalityStore.GetAllAdminsByMunicipalityId(MunicipalityId);
            cachingService.SetData<IEnumerable<Admins>>("admins", cacheData, expirationTime);
            
            foreach (var admin in cacheData)
            {
                cachingService.SetData<IEnumerable<Admins>>($"municipality:{admin.AdminId}", cacheData, expirationTime);
            }


            return await municipalityStore.GetAllAdminsByMunicipalityId(MunicipalityId);
        }
    }
}
