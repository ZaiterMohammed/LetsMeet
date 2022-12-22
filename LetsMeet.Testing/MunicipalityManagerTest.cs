
namespace LetsMeet.Testing
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Business;
    using LetsMeet.WebApi;
    using LetsMeet.WebApi.RabbitMQ;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class MunicipalityManagerTest
    {

        [Fact]
        public void ConstructorShouldThrowExceptionIfMunicipalityStoreIsNull()
        {
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();
            Assert.Throws<ArgumentNullException>(() => new MunicipalityManager(null, mockCacheService.Object, mockRabitMqProcedure.Object));
        }

        [Fact]
        public async Task AddMunicipalityShouldShouldThrowExceptionIfCreateMunicipalityRequestIsNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createMunicipalityRequest = new CreateMunicipalityRequest();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.CreateMunicipality(null));
        }

        [Fact]
        public async Task ManagerShouldCallStoreCreateMunicipality()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createMunicipalityRequest = new CreateMunicipalityRequest();

            mockStore.Setup(x => x.AddMunicipality(createMunicipalityRequest)).ReturnsAsync("Municipality save Successfully");

            var manager = new MunicipalityManager(mockStore.Object,mockCacheService.Object, mockRabitMqProcedure.Object);

            var result = await manager.CreateMunicipality(createMunicipalityRequest);
            Assert.Equal("Municipality save Successfully", result);

            mockStore.Verify(e => e.AddMunicipality(createMunicipalityRequest));
        }

        [Fact]
        public async Task ManagerShouldCallStoreUpdateMunicipality()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var municipality = new Municipality();

            mockStore.Setup(x => x.UpdateMunicipality(municipality)).ReturnsAsync("Municipality was Successfully Updated");

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            var result = await manager.UpdateMunicipality(municipality);
            Assert.Equal("Municipality was Successfully Updated", result);

            mockStore.Verify(e => e.UpdateMunicipality(municipality));
        }

        [Fact]
        public async Task AddAdminShouldShouldThrowExceptionIfCreateAdminRequestIsNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createAdminRequest = new CreateAdminRequest();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.AddAdmin(null));
        }

        [Fact]
        public async Task ManagerShouldCallStoreGetAllAdminsByMunicipalityId()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createAdminRequest = new CreateAdminRequest() { MunicipalityId = Guid.NewGuid(), UserId = Guid.NewGuid() };

            List<Admins> admins = new List<Admins>();

            mockStore.Setup(x => x.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId)).ReturnsAsync(admins);

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            var result = await manager.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async Task AddAdminShouldThrowExceptionIfCreateAdminRequestUserIdDifferentAdminUserId()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createAdminRequest = new CreateAdminRequest() { MunicipalityId = Guid.NewGuid(), UserId = Guid.NewGuid() };

            List<Admins> admins = new List<Admins>();
            admins.Add(new Admins() { AdminId = Guid.NewGuid(), UserId = Guid.NewGuid() });

            mockStore.Setup(x => x.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId)).ReturnsAsync(admins);

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            var result = await manager.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId);

            Assert.True(admins.Count > 0);
            foreach (var admin in admins)
            {
                Assert.True(admin.UserId != createAdminRequest.UserId);
            }
        }


        [Fact]
        public async Task ManagerShouldCallStoreAddAdmin()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createAdminRequest = new CreateAdminRequest(Guid.NewGuid(), Guid.NewGuid());

            mockStore.Setup(x => x.AddAdmin(createAdminRequest)).ReturnsAsync("Admin save Successfully");

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);


            var result = await manager.AddAdmin(createAdminRequest);
            Assert.Equal("Admin save Successfully", result);


            mockStore.Verify(e => e.AddAdmin(createAdminRequest));
        }


        [Fact]
        public async Task DeleteAdminShouldThrowExceptionIfDeleteAdminRequestAdminIdNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.DeleteAdmin(Guid.Empty, Guid.NewGuid(), Guid.NewGuid()));
        }

        [Fact]
        public async Task DeleteAdminShouldThrowExceptionIfDeleteAdminRequestUserIdIdNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.DeleteAdmin(Guid.NewGuid(), Guid.Empty, Guid.NewGuid()));
        }

        [Fact]
        public async Task DeleteAdminShouldThrowExceptionIfDeleteAdminRequestMunicipalityIdIdNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.DeleteAdmin(Guid.NewGuid(), Guid.NewGuid(), Guid.Empty));
        }


        [Fact]
        public async Task DeleteAdminShouldThrowExceptionIfAdminUserIdDifferentUserId()
        {
            var userId = Guid.NewGuid();
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var createAdminRequest = new CreateAdminRequest(Guid.NewGuid(), Guid.NewGuid());

            mockStore.Setup(x => x.AddAdmin(createAdminRequest)).ReturnsAsync("Admin save Successfully");


            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () => await manager.AddAdmin(createAdminRequest));

            var admins = await manager.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId);

            //Assert.True(admins[0].UserId == userId);
        }


        [Fact]
        public async Task GetAllAdminsByMunicipalityIdShouldThrowExceptionIfMunicipalityIdIsEmpty()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.GetAllAdminsByMunicipalityId(Guid.Empty));
        }



        [Fact]
        public async Task GetAllAdminsByMunicipalityIdShouldCallStoreGetAllAdminsByMunicipalityId()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var admins = new List<Admins>();
            admins.Add(new Admins()
            {
                AdminId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                MunicipalityId = Guid.NewGuid(),
            });
            mockStore.Setup(x => x.GetAllAdminsByMunicipalityId(Guid.NewGuid())).ReturnsAsync(admins);


            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            var result = await manager.GetAllAdminsByMunicipalityId(admins[0].MunicipalityId);
            Assert.NotEqual(admins, result);

            mockStore.Verify(e => e.GetAllAdminsByMunicipalityId(admins[0].MunicipalityId));
        }


        [Fact]
        public async Task GetMunicipalityByIdShouldThrowExceptionIfMunicipalityIdIsEmpty()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.GetMunicipalityById(Guid.Empty));
        }

        [Fact]
        public async Task GetMunicipalityByIdShouldCallStoreGetMunicipalityById()
        {
            var mockStore = new Mock<IMunicipalityStore>();
            var mockCacheService = new Mock<ICacheService>();
            var mockRabitMqProcedure = new Mock<IRabitMQProducer>();

            var municipality =
            new Municipality()
            {
                MunicipalityId = Guid.NewGuid(),
                MunicipalityName = "Akkar",
                CountryId = Guid.NewGuid(),
            };

            mockStore.Setup(x => x.GetMunicipalityById(municipality.MunicipalityId)).ReturnsAsync(municipality);


            var manager = new MunicipalityManager(mockStore.Object, mockCacheService.Object, mockRabitMqProcedure.Object);

            var result = await manager.GetMunicipalityById(municipality.MunicipalityId);
            Assert.Equal(municipality, result);

            mockStore.Verify(e => e.GetMunicipalityById(municipality.MunicipalityId));
        }

    }
}
