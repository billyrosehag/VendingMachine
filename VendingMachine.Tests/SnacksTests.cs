using System;
using Xunit;
using VendingMachine.Products;

namespace VendingMachine.Tests
{
    public class SnacksTests
    {
        [Fact]
        public void ReturnTypeSnacks()
        {
            //Arrange
            Product sut = new Snacks(15, "chips", "potato chips.");

            //Act
            string expected = "Snacks";
            string actual = sut.Type;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(15, "hi", "bye")]
        [InlineData(5, "peanuts", "Are you allergic")]
        [InlineData(12, "cheese doodles", "Yummy")]
        [InlineData(15, "Sticks", "Dislike")]
        public void GiveRightInfoBack(int expectedPrice, string expectedName, string expectedInfo)
        {
            //Arrange
            Product sut = new Snacks(expectedPrice, expectedName,expectedInfo);

            //Act


            //Assert
            Assert.Equal(expectedPrice, sut.Price);
            Assert.Equal(expectedName, sut.Name);
            Assert.Equal(expectedInfo, sut.Info);
        }
        [Fact]
        public void GiveExamineString()
        {
            //Arrange
            Product sut = new Snacks(60, "name", "info");

            //Act
            string expected = $"Snacks: {sut.Name}\nInfo: {sut.Info}\nPrice: {sut.Price}";
            string actual = sut.Examine();

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GiveUseString()
        {
            //Arrange
            Snacks sut = new Snacks(1, "name", "info");

            //Act
            string expected = $"You consume the entire bag of {sut.Name} snacks";
            string actual = sut.UseItem();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SnacksIsProduct()
        {
            //Arrange
            Product sut = new Snacks(5, "name", "info");

            //Act

            //Assert
            Assert.True(sut is Product);
        }

        [Fact]
        public void CannotGiveNullOrWhiteSpace()
        {
            //Arrange
            string expectedName = "Popcorn";
            string expectedInfo = "salty Corn that has been poped";

            Snacks sut = new Snacks(0, expectedName, expectedInfo);

            //Act
            sut.Name = "";
            sut.Info = "";
            string actualName = sut.Name;
            string actualInfo = sut.Info;

            //Assert
            Assert.NotNull(sut.Name);
            Assert.NotNull(sut.Info);
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedInfo, actualInfo);
        }
    }
}
