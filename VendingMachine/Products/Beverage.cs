using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Products
{
    class Beverage : Product
    {
        public Beverage(int price,string name, string info):base(price,name,info)
        {

            this.type = "Beverage";
        }

        public override string Examine()
        {
            return $"{Type}: {Name}\n{Type} Info: {Info}\nPrice: {Price}";
        }

        public override string UseItem()
        {
            return $"You drink up the entire bottle of {Name}";
        }
    }
}
