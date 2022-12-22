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

        public async Task CreateMunicipality(CreateMunicipalityRequest createMunicipalityRequest)
        {
            if (createMunicipalityRequest == null)
            {
                throw new ArgumentNullException(nameof(createMunicipalityRequest));
            }

            var municipalityId = await municipalityStore.CreateMunicipality(createMunicipalityRequest);

            messageBroker.SendProductMessage(new NotificationMessage()
            {
                Type = NotificationType.MunicipalityCreated,
                Id = municipalityId
            });
        }

        //remarks:
       //1-remove invalid response from managers and stores
       //2-rename your apis and controllers
       //3-fix rabbitMq configuration (add them to appsettings.json)
       //4-use microservices architecture in your solution (separate your services), and reflect your changes to docker-compose file
       //5-use multiple subscribers for your notification types
       //6-add statistics feature (table in sql) to count number of companies, organizations, post, etc...
       //7-expose apis for statistics to be viewable for end-users

        public async Task<string> UpdateMunicipality(Municipality municipality)
        {
            if (municipality == null)
            {
                throw new ArgumentNullException(nameof(municipality));
            }
            var responce = await municipalityStore.UpdateMunicipality(municipality);

            cachingService.RemoveData($"municipality:{municipality.MunicipalityId}");

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

            var cacheData = cachingService.GetData<IEnumerable<Municipality>>("municipality");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = await municipalityStore.GetAllMunicipality();
            cachingService.SetData<IEnumerable<Municipality>>("municipality", cacheData, expirationTime);


            return cacheData;
        }


        public async Task<Municipality> GetMunicipalityById(Guid MunicipalityId)
        {
            if (MunicipalityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(MunicipalityId));
            }


            Municipality filteredData;
            var cacheData = cachingService.GetData<IEnumerable<Municipality>>("municipality");
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
