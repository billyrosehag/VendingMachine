using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Products
{
    class Candy:Product
    {

        public Candy(int price, string name, string info):base(price, name, info)
        {

            this.type = "Candy";
        }

        public override string Examine()
        {
            return $"{Type}: {Name}\n{Type} Info: {Info}\nPrice: {Price}";
        }

        public override string UseItem()
        {
            return $"You eat the whole package of {Name} candy";
        }
    }
}
