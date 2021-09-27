using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Models;
using Web.Services;

namespace Web.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IRoomService> _roomService;

        public UnitTest1()
        {
            _roomService = new Mock<IRoomService>();
        }

        public RegistrationService Subject()
        {
            return new RegistrationService(_roomService.Object);
        }

        [TestMethod]
        public void Age_over_18_Valid()
        {
            var service = Subject();
            var isValid = service.ValidateUser( new Room() {IsColerAllaved = true} ,new Models.User() { Age=20 });
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Age_under_18_InValid()
        {
            var service = Subject();
            var isValid = service.ValidateUser(new Room() { IsColerAllaved = true }, new Models.User() { Age = 12 });
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Age_over_18_Mens_isAlloved_Valid()
        {
            var service = Subject();
            _roomService.Setup(x => x.isUserAllowed(new Room() { Id = 1, IsColerAllaved = true })).Returns(true);
            var isValid = service.ValidateUser(new Room() { IsColerAllaved = true }, new Models.User() { Age = 20, Gender = Models.Gender.Men });
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Age_over_18_Womens_isAllowed_InValid()
        {
            var service = Subject();
            _roomService.Setup(x => x.isUserAllowed(new Room() { Id = 1, IsColerAllaved = true })).Returns(true);
            var isValid = service.ValidateUser(new Room() { IsColerAllaved = true }, new Models.User() { Age = 20, Gender = Models.Gender.Women });
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Age_over_18_Mens_isAlloved_withBlueDress_inValid()
        {
            var service = Subject();
            _roomService.Setup( x=>x.isUserAllowed(new Room() { Id =1, IsColerAllaved = false })).Returns( false );
            var isValid = service.ValidateUser(new Room() { IsColerAllaved = false }, new Models.User() { Age = 20, Gender = Models.Gender.Men });

            Assert.IsTrue(isValid);

        }


    }
}
