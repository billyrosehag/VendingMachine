using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine;
using VendingMachine.Products;
using Xunit;

namespace VendingMachine.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ReturnFalse()
        {
            //Assert
            Assert.False(Program.EndTransactionSection());
        }

        [Fact]
        public void GiveCheeseCrunchers()
        {
            //Arrange
            List <Product> myProducts = new List <Product>
           {
            new Snacks(15, "Sour Cream Chips", "80 gram potato chips flavored with sour cream."),
            new Snacks(20, "Cheese Crunchers", "75 gram crunchy cheese seasoned corn sticks"),
            new Beverage(25, "Coca Cola", "33 cl Cola flavored soda"),
            new Beverage(50, "Brämhults Juice", "25 cl Orange juice, 100% orange juice."),
            new Snacks(5, "Salta Pinnar", "200 gram salty sticks, will last a long time."),
            new Candy(15, "Plopp", "50 gram cola cream filled chocolate bar."),
            new Candy(10, "Gummy bears", "40 gram bear shaped gummy candy.")
           };

            //Act
            int expectedPrice = 20;
            string expectedName = "Cheese Crunchers";
            string expectedInfo = "75 gram crunchy cheese seasoned corn sticks";

            Product sut = Program.PurchaseItem(1, myProducts);

            int actualPrice = sut.Price;
            string actualName = sut.Name;
            string actualInfo = sut.Info;

            //Assert
            Assert.Equal(expectedPrice, actualPrice);
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedInfo, actualInfo);
        }

        //[Theory]
        //[InlineData(5, "5")]
        //[InlineData(55,"55")]
        //[InlineData(753, "753")]
        //[InlineData(2345, "2345")]
        //[InlineData(13456675435345, "13456675435345")]
        //public void TurnStringToInt(int expected, string actual)
        //{

        //    //Assert
        //    Assert.Equal(expected, Program.StringToInt(actual));
        //}

    }   
}
