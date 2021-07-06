using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Products
{
    public class Snacks:Product
    {
        public Snacks(int price,  string name, string info):base(price,name,info)
        {

            this.type = "Snacks";
        }

        public override string Examine()
        {
            return $"{Type}: {Name}\nInfo: {Info}\nPrice: {Price}";
        }

        public override string UseItem()
        {
            return $"You consume the entire bag of {Name} snacks";
        }
    }
}
