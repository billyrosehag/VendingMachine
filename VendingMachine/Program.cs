using System;
using VendingMachine.Products;
using VendingMachine.Machine;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Program
    {
        public static string dashes = "-----------------------------";
        static VMachine myMachine = new VMachine();
        static int inputNumber;
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

            Console.ForegroundColor = ConsoleColor.White;

            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("----------- WELCOME TO THE VENDING MACHINE -----------");

            Console.WriteLine($"THE FOLLOWING OPTIONS ARE AVAILABLE:");
            myMachine.ShowAll(myMachine.VendingProducts);

            Console.WriteLine($"{dashes}\nCurrent money left to spend: {myMachine.MoneyPool} kr");

            Console.WriteLine("\nDo you want to:"
                            + "\n1. Add money"
                            + "\n2. Inspect Item"
                            + "\n3. Purchase Item"
                            + "\n4. Stop Transaction");


            MainMenuChoice(StringToInt(
                $"{dashes}\nChoose by inputting the corresponding number: "));//Player inputs their choice
        }

        public static void MainMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine(dashes);
                    AddMoney();
                    break;
                case 2:
                    Console.WriteLine(dashes);
                    InspectItem();
                    break;
                case 3:
                    Console.WriteLine(dashes);
                    PurchaseSection();
                    break;
                case 4:
                    Console.WriteLine(dashes);
                    EndTransactionSection();
                    break;
                default:
                    Console.WriteLine(dashes);
                    Console.WriteLine("Choice not available.");
                    AnyKeyToContinue();
                    break;
            }
        }
        //Methods for the different options available.
        public static void AddMoney()
        {
            myMachine.InsertMoney(StringToInt("How much do you want to add: "));
            Console.WriteLine($"You now have {myMachine.MoneyPool} kr to spend");
            AnyKeyToContinue();
        }

        public static void InspectItem()
        {
            //Starts the examine method for the product the user inputs 

            inputNumber = StringToInt("What item would you like to inspect: ", 1, myMachine.VendingProducts.Count) - 1;

            Console.WriteLine(myMachine.VendingProducts[inputNumber].Examine());

            AnyKeyToContinue();
        }

        public static void PurchaseSection()
        {
            int choice = StringToInt("What item do you want to purchase: ", 1, myMachine.VendingProducts.Count) - 1;
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
            if(myMachine.MoneyPool > 0)
            {
                Console.WriteLine($"\nHere is your change\n");
                myMachine.EndTransaction();
            }
            Console.WriteLine($"{dashes}\nThank you and welcome again.");
            System.Threading.Thread.Sleep(1000);

            return false;
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
        public static int StringToInt(string inputWhat, int start, int end)
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
                else if (result < start)
                {
                    inputWhat = "Too low number. Try again: ";
                }
                else if (result > end)
                {
                    inputWhat = "Too high number. Try again: ";
                }

            } while (!isNumber || result < start || result > end);


            return result;

        }

        public static void AnyKeyToContinue()
        {
            Console.WriteLine("Will return to main menu. Press any key to continue");
            Console.ReadKey();
            MainMenu();
        }

        
    }

}
