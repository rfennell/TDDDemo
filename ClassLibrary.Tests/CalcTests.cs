using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassLibrary.Test
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void An_empty_string_returns_zero()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("");

            // assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void A_single_number_returns_the_value()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("5");

            // assert
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void Two_numbers_comma_delimited_returns_the_sum()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("5, 6");

            // assert
            Assert.AreEqual(11, actual);
        }

        [TestMethod]
        public void Three_numbers_comma_delimited_returns_the_sum()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("5, 6, 2");

            // assert
            Assert.AreEqual(13, actual);
        }

        [TestMethod]
        public void Three_numbers_newline_delimited_returns_the_sum()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("5 " + Environment.NewLine + "6" + Environment.NewLine + " 2");

            // assert
            Assert.AreEqual(13, actual);
        }

        [TestMethod]
        public void Three_numbers_mixed_delimited_returns_the_sum()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("5 , 6" + Environment.NewLine + " 2");

            // assert
            Assert.AreEqual(13, actual);
        }

        [TestMethod]
        public void Two_numbers_newline_delimited_returns_the_sum()
        {
            // arrange
            var sut = new Calculator();

            // act
            var actual = sut.Sum("5 " + Environment.NewLine + " 6");

            // assert
            Assert.AreEqual(11, actual);
        }

        [TestMethod]
        public void Negative_numbers_throw_an_exception()
        {
            // arrange
            var sut = new Calculator();

            // act

            // assert
            Assert.ThrowsException<InvalidOperationException>(() => sut.Sum("5, -6"));
        }
    }
}