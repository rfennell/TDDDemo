using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClassLibrary.Test
{
    [TestClass]
    public class MockingTests
    {
        [TestMethod]
        public void Can_get_the_current_datetime_fail()
        {
            // arrange
            var sut = new MockingDemo();

            // act
            var actual = sut.GetDateTime();

            // assert
            Assert.AreEqual(System.DateTime.Now, actual, "this will always fails as the time has changed between the start and the end of the test");

        }

        [TestMethod]
        public void Can_get_the_current_datetime_manually_mocked()
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
        public void Can_get_the_current_datetime_auto_mocked()
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

        }

    }
}
