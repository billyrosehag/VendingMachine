using System;
using VendingMachine.Products;
using VendingMachine.Machine;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static VMachine myMachine = new VMachine();
        static void Main(string[] args)
        {

            Product[] myProducts = new Product[]
           {
            new Snacks(15, "Sour Cream Chips", "80 gram potato chips flavored with sour cream."),
            new Snacks(20, "Cheese Crunchers", "75 gram crunchy cheese seasoned corn sticks"),
            new Beverage(25, "Coca Cola", "33 cl Cola flavored soda"),
            new Beverage(50, "Brämhults Juice", "25 cl Orange juice, 100% orange juice."),
            new Snacks(5, "Salta Pinnar", "200 gram salty sticks, will last a long time."),
            new Candy(15, "Plopp", "50 gram cola cream filled chocolate bar."),
            new Candy(10, "Gummy bears", "40 gram bear shaped gummy candy.")
           };

            foreach (Product product in myProducts)
            {
                myMachine.VendingProducts.Add(product);
            }

            MainMenu();



        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("----------- WELCOME TO THE VENDING MACHINE -----------");

            Console.WriteLine("THE FOLLOWING OPTIONS ARE AVAILABLE:");
            myMachine.ShowAll(myMachine.VendingProducts);

            Console.WriteLine("\nCurrent money left to spend: " + myMachine.MoneyPool);

            Console.WriteLine("\nDo you want to:"
                            + "\n1. Add money"
                            + "\n2. Inspect Item"
                            + "\n3. Purchase Item"
                            + "\n4. Stop Transaction");


            MainMenuChoice(StringToInt(
                "\nChoose by inputting the corresponding number: "));//Player inputs their choice
        }

        public static void MainMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddMoney();

                    break;
                case 2:
                    InspectItem();
                    break;
                case 3:
                    PurchaseSection();
                    break;
                case 4:
                    myMachine.EndTransaction();
                    break;
                default:
                    Console.WriteLine("Choice not available.");
                    AnyKeyToContinue();
                    break;
            }
        }
        //Methods for the different options available.
        public static void AddMoney()
        {
            myMachine.InsertMoney(StringToInt("How much do you want to add: "));
            AnyKeyToContinue();
        }

        public static void InspectItem()
        {
           

            //Starts the examine method for the product the user inputs 
            Console.WriteLine(myMachine.VendingProducts[StringToInt("What item would you like to inspect: ") - 1].Examine());

            AnyKeyToContinue();
        }

        public static void PurchaseSection()
        {
            int choice = StringToInt("What item do you want to purchase: ") - 1;
            if(myMachine.MoneyPool >= myMachine.VendingProducts[choice].Price)
            {
                myMachine.Purchase(myMachine.VendingProducts[choice]);
                myMachine.ConsumePurchase(PurchaseItem(choice, myMachine.VendingProducts));
            }
            else
            {
                Console.WriteLine("Not enough money inserted for the purchase.");             
            }
            AnyKeyToContinue();
        }

        public static Product PurchaseItem(int choice,List <Product> options)
        {
            Product itemToPurchase = null;
            try
            {
                itemToPurchase = options[choice];
                Console.WriteLine($"You purchased: {itemToPurchase.Name} for {itemToPurchase.Price}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("That item does not exist");
            }
            return itemToPurchase;
        }

        public static bool EndTransactionSection()
        {

        }

        //Methods used for user input and alike
        public static int StringToInt(string inputWhat)
        {
            bool isNumber = false;
            int result = 0;
            do
            {
                Console.WriteLine(inputWhat);
                
                string playerInput = Console.ReadLine();

                isNumber = int.TryParse(playerInput, out result);

                if (!isNumber)
                {
                    inputWhat = "Invalid input. Please input a number: ";
                }

            } while (!isNumber);


            return result;

        }

        public static void AnyKeyToContinue()
        {
            Console.WriteLine("Will return to main menu. Press any key to continue");
            Console.ReadKey();
            MainMenu();
        }







        //Console.WriteLine(strMoneyPool + myMachine.MoneyPool);

        //Console.ReadKey();

        //myMachine.InsertMoney(3527);

        //Console.WriteLine(strMoneyPool + myMachine.MoneyPool);
        //myMachine.Purchase(myMachine.VendingProducts[2]);
        //Console.WriteLine(strMoneyPool + myMachine.MoneyPool);
        //myMachine.Purchase(myMachine.VendingProducts[1]);
        //Console.WriteLine(strMoneyPool + myMachine.MoneyPool);
        //myMachine.Purchase(myMachine.VendingProducts[0]);
        //Console.ReadKey();

        //myMachine.ShowAll(myMachine.PurchasedProducts);
        //Console.ReadKey();


        //myMachine.ConsumePurchase(myMachine.PurchasedProducts[1]);

        //Console.ReadKey();

        //Dictionary<int, int> myDic = myMachine.EndTransaction();
    }

}
