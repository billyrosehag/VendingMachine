using System;
using Xunit;
using VendingMachine.Products;

namespace VendingMachine.Tests
{
    public class CandyTests
    {
        [Fact]
        public void ReturnTypeCandy()
        {
            //Arrange
            Product sut = new Candy(15, "Chocolate", "40 gram chocolate.");

            //Act
            string expected = "Candy";
            string actual = sut.Type;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(15, "hi", "bye")]
        [InlineData(5, "candy", "carrot cake")]
        [InlineData(12, "I", "stund")]
        [InlineData(15, "Like", "Dislike")]
        public void GiveRightInfoBack(int expectedPrice, string expectedName, string expectedInfo)
        {
            //Arrange
            Candy sut = new Candy(expectedPrice, expectedName,expectedInfo);

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
            Candy sut = new Candy(1, "name", "info");

            //Act
            string expected = $"Candy: {sut.Name}\nInfo: {sut.Info}\nPrice: {sut.Price}";
            string actual = sut.Examine();

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GiveUseString()
        {
            //Arrange
            Candy sut = new Candy(1, "name", "info");

            //Act
            string expected = $"You eat the whole package of name candy";
            string actual = sut.UseItem();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CandyIsProduct()
        {
            //Arrange
            Candy sut = new Candy(5, "name", "info");

            //Act

            //Assert
            Assert.True(sut is Product);
        }
    }
}
