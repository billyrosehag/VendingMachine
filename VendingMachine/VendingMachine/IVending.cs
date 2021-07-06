using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Products
{
    public interface IVending
    {
        const string INFOSTART = "---- INFO ----\n";
        
        public int Purchase(Product product);

        public void ShowAll(List <Product> products);

        public int InsertMoney(int money);

        public Dictionary<int, int> EndTransaction();

    }
}
