using System;
using Xunit;
using VendingMachine.Products;

namespace VendingMachine.Tests
{
    public class BeverageTests
    {
        [Fact]
        public void ReturnTypeBeverage()
        {
            //Arrange
            Beverage sut = new Beverage(15, "beer", "A nice, cold beer.");

            //Act
            string expected = "Beverage";
            string actual = sut.Type;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(15, "Beer", "Cold beer")]
        [InlineData(5, "Water", "Water in a bottle")]
        [InlineData(12, "Cola", "Sugerinfested soda")]
        [InlineData(15, "T-Röd", "Dont drink this")]
        public void GiveRightInfoBack(int expectedPrice, string expectedName, string expectedInfo)
        {
            //Arrange
            Beverage sut = new Beverage(expectedPrice, expectedName,expectedInfo);

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
            Beverage sut = new Beverage(1, "name", "info");

            //Act
            string expected = $"{sut.Type}: {sut.Name}\nInfo: {sut.Info}\nPrice: {sut.Price}";
            string actual = sut.Examine();

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GiveUseString()
        {
            //Arrange
            Beverage sut = new Beverage(1, "name", "info");

            //Act
            string expected = $"You drink up the entire bottle of name";
            string actual = sut.UseItem();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
