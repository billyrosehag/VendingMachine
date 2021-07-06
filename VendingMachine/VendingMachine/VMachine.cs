using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Products;

namespace VendingMachine.Machine
{
    public class VMachine : IVending
    {
        private int moneyPool = 0;
        private int bill = 0;

        public List <Product> PurchasedProducts;
        public List<Product> VendingProducts;

        public int MoneyPool { get { return moneyPool; } }
        public int Bill { get { return bill; } }

        
        readonly int[] denominations = new int[] {1000, 500, 100, 50, 20, 10, 5, 1};

        Dictionary<int, int> Change = new Dictionary<int, int>();
        //{
        //    {1000,0 },
        //    {500,0 },
        //    {100,0 },
        //    {50,0 },
        //    {10,0 },
        //    {5,0 },
        //    {1,0 },
        //};

        public Dictionary<int, int> EndTransaction()
        {
            for (int i = 0; i < Change.Count; i++)
            {
                int currencyCount = 0;
                int currentIndex = (int)Change.ElementAt(i).Key;

                while (currentIndex <= moneyPool)
                {     
                    currencyCount++;
                    Change[currentIndex] = currencyCount;
                    moneyPool -= currentIndex;
                }
            }

            foreach (KeyValuePair<int,int> change in Change)
            {
                if(change.Value <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine($"{change.Key}:\t{change.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            return Change;
        }

        public VMachine()
        {
            VendingProducts = new List<Product>();
            PurchasedProducts = new List<Product>();
            foreach(int currency in denominations)
            {
                Change.Add(currency, 0);
            }
        }

        //Insert more money to spend
        public int InsertMoney(int money)
        {
           this.moneyPool += money;
            return moneyPool;
        }

        //Purchase item and lose money from money pool
        public int Purchase(Product product)
        {
            PurchasedProducts.Add(product);
            moneyPool -= product.Price;

            return moneyPool;
        }

        //Display each item of the product array inserted
        public void ShowAll(List <Product> productsToShow)
        {
            string strPrice = "\nPrice: ";
            string strType;
            int option = 1;
            foreach (Product product in productsToShow)
            {
                strType = $"\n---- {option}. {product.Type} ----\n";

                Console.WriteLine(strType + product.Name + strPrice + product.Price + " kr");
                option++;
            }
        }

        //
        public string DoesCustomerConsumeProduct(Product purchase)
        {
            //Checks what type of item the purchase is
            string Choice = "\nDo you want to " + (purchase.Type == "Snacks" ? "eat the snacks": 
                                                    purchase.Type == "Beverage" ? "drink your beverage": 
                                                    "Consume Item" + 
                                                    "\nYes or no: ");
            return Choice;           
        }

        public void ConsumePurchase(Product purchase)
        {
            Console.Write(DoesCustomerConsumeProduct(purchase));
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "y")
            {
                Console.WriteLine(purchase.UseItem());
                PurchasedProducts.Remove(purchase);
            }
            else
            {
                Console.WriteLine($"You put {purchase.Name} in your bag.");
            }
        }
    }
}
