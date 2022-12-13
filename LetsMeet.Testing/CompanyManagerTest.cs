
namespace LetsMeet.Testing
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Business;
    using Moq;
    using Xunit;

    public class CompanyManagerTest
    {
        [Fact]
        public void ConstructorShouldThrowExceptionIfStoreIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CompanyManager(null));
        }

        [Fact]
        public void ManagerShouldCallStoreCreateCompany()
        {
            var mockStore = new Mock<ICompanyStore>();

            var companyRequest = new CreateCompanyRequest();
            mockStore.Setup(x => x.AddCompany(companyRequest)).Returns("Company save Successfully");

            var manager = new CompanyManager(mockStore.Object);

            var result = manager.AddCompany(companyRequest);
            Assert.Equal("Company save Successfully", result);

            mockStore.Verify(e => e.AddCompany(companyRequest));

        }
    }
}
