//namespace LetsMeet.Testing
//{
//    using LetsMeet.Abstractions.Models;
//    using LetsMeet.Abstractions.Store;
//    using LetsMeet.Business;
//    using Moq;
//    using Xunit;

//    public class PostManagerTest
//    {
//        [Fact]
//        public void ConstructorShouldThrowExceptionIfPostStoreIsNull()
//        {
//            var mockStoreOrg = new Mock<IRabitMQProducer>();

//            Assert.Throws<ArgumentNullException>(() => new PostManager(null,
//                                    new Mock<IOrganisationStore>().Object));
//        }

//        [Fact]
//        public void ConstructorShouldThrowExceptionIfOrganisationStoreIsNull()
//        {
//            Assert.Throws<ArgumentNullException>(() => new PostManager(new Mock<IPostStore>().Object,
//                                    null));
//        }


//        [Fact]
//        public async Task AddLikeShouldShouldThrowExceptionIfPostActionIsNull()
//        {
//            var mockStore = new Mock<IPostStore>();
//            var mockStoreOrg = new Mock<IOrganisationStore>();

//            var manager = new PostManager(mockStore.Object, mockStoreOrg.Object);
//            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.AddLike(null));
//        }

//        [Fact]
//        public async Task AddLikeShouldShouldThrowExceptionIfPostIsNull()
//        {
//            var mockStoreOrg = new Mock<IOrganisationStore>();
//            var likeRequest = new PostAction();
//            var managerOrg = new OrganisationManager(mockStoreOrg.Object);

//            var post = await managerOrg.GetPostById(likeRequest.PostId);
//            Assert.True(post == null);
//        }


//        [Fact]
//        public async Task ManagerShouldCallStoreCreatePost()
//        {
//            var mockStore = new Mock<IPostStore>();

//            var likeRequest = new PostAction();
//            mockStore.Setup(x => x.AddLike(likeRequest)).ReturnsAsync("Like save Successfully");

//            var mockStoreOrg = new Mock<IOrganisationStore>();

//            var manager = new PostManager(mockStore.Object, mockStoreOrg.Object);

//            var result = await manager.AddLike(likeRequest);
//            Assert.Equal("Like save Successfully", result);

//            mockStore.Verify(e => e.AddLike(likeRequest));
//        }




//        //----------------------------------delete-------------------------------------
//        [Fact]
//        public async Task DeleteLikeShouldThrowExceptionIfPostIdIsNull()
//        {
//            var mockStoreOrg = new Mock<IOrganisationStore>();
//            var likeRequest = new PostAction();
//            var managerOrg = new OrganisationManager(mockStoreOrg.Object);

//            var post = await managerOrg.GetPostById(likeRequest.PostId);
//            Assert.True(post == null);
//        }

//        [Fact]
//        public async Task ManagerShouldCallStoreDeleteLike()
//        {
//            var mockStore = new Mock<IPostStore>();

//            var likeRequest = new PostAction();
//            mockStore.Setup(x => x.DeleteLike(likeRequest.PostId, likeRequest.UserId)).ReturnsAsync("Like was Successfully Deleted");

//            var mockStoreOrg = new Mock<IOrganisationStore>();

//            var manager = new PostManager(mockStore.Object, mockStoreOrg.Object);

//            var result = await manager.DeleteLike(likeRequest.PostId,likeRequest.UserId);
//            Assert.Equal("Like was Successfully Deleted", result);

//            mockStore.Verify(e => e.DeleteLike(likeRequest.PostId, likeRequest.UserId));
//        }

//    }
//}
