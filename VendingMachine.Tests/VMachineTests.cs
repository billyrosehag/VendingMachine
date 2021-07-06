using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Products;
using VendingMachine.Machine;

namespace VendingMachine.Tests
{
    public class VMachineTests
    {
        [Fact]
        public void GiveBackZeroCurrenciesIfNoMoneyInserted()
        {
            //Arrange
            VMachine sut = new VMachine();

            //Act
             List<int> expected = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
             List<int> actual = new List<int>();

             foreach(KeyValuePair<int,int> currency in sut.Change)
            {
                actual.Add(currency.Value);
            }

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);
        }
        [Fact]
        public void GiveBackRightAmountOfEachCurrenciesIfMoneyInserted()
        {
            //Arrange
            VMachine sut = new VMachine();
            int money = 2989;
            sut.InsertMoney(money);
            sut.EndTransaction();

            //Act                                1000,500,100,50,20,10,5,1  
            List<int> expected = new List<int>() { 2, 1, 4, 1, 1, 1, 1, 4 };
            List<int> actual = new List<int>();

            foreach (KeyValuePair<int, int> currency in sut.Change)
            {
                actual.Add(currency.Value);
            }

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);
        }



        [Theory]
        [InlineData(100,50, 150)]
        [InlineData(20,70, 90)]
        [InlineData(55,3, 58)]
        [InlineData(678,1, 679)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 0, 0)]
        public void ReturnRightAmountOfMoney(int moneyInsert1, int moneyInsert2, int expected)
        {
            //Arrange
            VMachine sut = new VMachine();

            //Act
            sut.InsertMoney(moneyInsert1);
            sut.InsertMoney(moneyInsert2);

            //Assert
            Assert.Equal(expected, sut.MoneyPool);

        }

        [Theory]
        [InlineData(0, 100, 85)]
        [InlineData(1, 20, 0)]
        [InlineData(2, 53, 28)]
        [InlineData(3, 678, 628)]
        [InlineData(4, 15, 10)]
        [InlineData(5, 55, 40)]
        [InlineData(6, 5, -5)]
        public void ReturnRightAmountAfterPurchase(int index, int moneyPool, int expected)
        {
            //Arrange
            VMachine sut = new VMachine();
            Product[] products = new Product[]
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
            sut.InsertMoney(moneyPool);


            //Assert
            Assert.Equal(expected, sut.Purchase(products[index]));

        }

        [Fact]
        public void BeOfRightTypeWhenUsed()
        {
            //Arrange
            Product test1 = new Beverage(10, "name", "info");
            Product test2 = new Snacks(10, "name", "info");
            Beverage test3 = new Beverage(10, "name", "info");
            Candy test4 = new Candy(10, "name", "info");

            VMachine sut = new VMachine();
            //Act
            string expected1 = "drink your beverage";
            string expected2 = "eat the snacks";
            string expected3 = "drink your beverage";
            string expected4 = "consume Item";

            string actual1 = sut.DoesCustomerConsumeProduct(test1);
            string actual2 = sut.DoesCustomerConsumeProduct(test2);
            string actual3 = sut.DoesCustomerConsumeProduct(test3);
            string actual4 = sut.DoesCustomerConsumeProduct(test4);

            //Assert
            Assert.Contains(expected1, actual1);
            Assert.Contains(expected2, actual2);
            Assert.Contains(expected3, actual3);
            Assert.Contains(expected4, actual4);
        }
    }
}
