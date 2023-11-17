using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClassLibrary.Test
{
    //[TestClass]
    public class MockingTests
    {
        //[TestMethod]
        public void Can_get_the_production_datetime()
        {
            // arrange
            var sut = new MockingDemo();

            // act
            var actual = sut.GetDateTime();

            // assert
            Assert.AreEqual(System.DateTime.Now, actual, "This will always fails as the time has changed between the start and the end of the test");

        }

        [TestMethod]
        public void Can_get_the_manually_mocked_datetime()
        {
            // arrange
            var testdate = new System.DateTime(2021, 1, 1, 12, 0, 0);
            var provider = new MyTestDateTimeProvider(testdate);
            var sut = new MockingDemo(provider);

            // act
            var actual = sut.GetDateTime();

            // assert
            Assert.AreEqual(testdate, actual);

        }

        [TestMethod]
        public void Can_get_the_auto_mocked_datetime()
        {
            // arrange
            var testdate = new System.DateTime(2021, 1, 1, 12, 0, 0);
            var provider = new Mock<IDateTimeProvider>();
            provider.Setup(p => p.GetDateTime()).Returns(testdate);

            var sut = new MockingDemo(provider.Object);

            // act
            var actual = sut.GetDateTime();

            // assert
            Assert.AreEqual(testdate, actual);
            provider.Verify(p => p.GetDateTime(), Times.Once);


        }
    }
}
