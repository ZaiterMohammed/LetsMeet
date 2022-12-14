using LetsMeet.Abstractions.Models;
using LetsMeet.Abstractions.Store;
using LetsMeet.Business;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LetsMeet.Testing
{
    public class MunicipalityManagerTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionIfMunicipalityStoreIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MunicipalityManager(null));
        }

        [Fact]
        public async Task AddMunicipalityShouldShouldThrowExceptionIfCreateMunicipalityRequestIsNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();
           
            var createMunicipalityRequest = new CreateMunicipalityRequest();

            var manager = new MunicipalityManager(mockStore.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.AddMunicipality(null));
        }

        [Fact]
        public async Task ManagerShouldCallStoreCreateMunicipality()
        {
            var mockStore = new Mock<IMunicipalityStore>();

            var createMunicipalityRequest = new CreateMunicipalityRequest();

            mockStore.Setup(x => x.AddMunicipality(createMunicipalityRequest)).ReturnsAsync("Municipality save Successfully");

            var manager = new MunicipalityManager(mockStore.Object);

            var result = await manager.AddMunicipality(createMunicipalityRequest);
            Assert.Equal("Municipality save Successfully", result);

            mockStore.Verify(e => e.AddMunicipality(createMunicipalityRequest));
        }

        [Fact]
        public async Task ManagerShouldCallStoreUpdateMunicipality()
        {
            var mockStore = new Mock<IMunicipalityStore>();

            var municipality = new Municipality();

            mockStore.Setup(x => x.UpdateMunicipality(municipality)).ReturnsAsync("Municipality was Successfully Updated");

            var manager = new MunicipalityManager(mockStore.Object);

            var result = await manager.UpdateMunicipality(municipality);
            Assert.Equal("Municipality was Successfully Updated", result);

            mockStore.Verify(e => e.UpdateMunicipality(municipality));
        }

        [Fact]
        public async Task AddAdminShouldShouldThrowExceptionIfCreateAdminRequestIsNull()
        {
            var mockStore = new Mock<IMunicipalityStore>();

            var createAdminRequest = new CreateAdminRequest();

            var manager = new MunicipalityManager(mockStore.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.AddAdmin(null));
        }

        [Fact]
        public async Task ManagerShouldCallStoreGetAllAdminsByMunicipalityId()
        {
            var mockStore = new Mock<IMunicipalityStore>();

            var createAdminRequest = new CreateAdminRequest();
            List<Admins> admins = new List<Admins>();
            mockStore.Setup(x => x.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId)).ReturnsAsync(admins);

            var manager = new MunicipalityManager(mockStore.Object);

            var result = await manager.GetAllAdminsByMunicipalityId(createAdminRequest.MunicipalityId);
            Assert.False(result.Count == 0);

            mockStore.Verify(e => e.AddAdmin(createAdminRequest));
        }
    }
}
