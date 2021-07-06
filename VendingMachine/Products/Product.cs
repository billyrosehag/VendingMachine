using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Products
{
    public abstract class Product
    {
        //Private fields
        protected int price;
        protected string info;
        protected string use;
        protected string type;
        protected string name;

        //Stores all the products 
        public static Product[] products;

        //Public Prop
        public int Price { get { return price; } }
        public string Info
        {
            get { return info; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Info cannot be null or just white spaces. Please insert a description.");
                }
                else
                {
                    info = value;
                }
            }
        }
        public string Name {

            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Info cannot be null or just white spaces. Please insert a description.");
                }
                else
                {
                    name = value;
                }

            }
        }
        public string Type { get { return type; } }

        //Constructor
        public Product(int price,string name, string info)
        {
            this.price = price;
            this.Info = info;
            this.Name = name;
        }
        //Used to examine the product
        public abstract string Examine();
        //Whether the player decides to use the item.
        public abstract string UseItem();

    }
}
