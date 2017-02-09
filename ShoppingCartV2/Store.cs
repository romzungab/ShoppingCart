using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartV2
{
    class Store
    {
        public List<StockedProduct> MyStocks { get; set; }
        public List<SoldProduct> MySales { get; set; }
        public string StoreName { get; set; }

        public Store(String name)
        {
            Console.WriteLine("Initializing Store");
            StoreName = name;

            StockedProduct product1 = new StockedProduct("Laptop", 1700.12f, 12,1);
            StockedProduct product2 = new StockedProduct("Phone", 501.20f, 12,2);
            StockedProduct product3 = new StockedProduct("Tablet", 307.30f, 12,3);
            StockedProduct product4 = new StockedProduct("Charger", 10.20f, 12, 4);
            StockedProduct product5 = new StockedProduct("Watch", 70.30f, 12, 5);

            MyStocks = new List<StockedProduct>();
            MyStocks.Add(product1);
            MyStocks.Add(product2);
            MyStocks.Add(product3);

            MySales = new List<SoldProduct>();
            Console.WriteLine("Store is Ready");
        }

        public void AddToSales(SoldProduct soldProduct)
        {
            MySales.Add(soldProduct);
        }

        public string PrintSales()
        {
            if (MySales.Count() > 0)
            {
                StringBuilder salesString = new StringBuilder();
                float total = 0.0f;
                salesString.Append("\n\t**********************************************");
                salesString.Append("\n\tYou have sold the following products");
                salesString.Append("\n\n\tName\tPrice\tQty\tAmount\n");
                foreach (SoldProduct p in MySales)
                {
                    salesString.Append(p.ToString());
                    float amount = p.Price * p.Quantity;
                    total = total + amount;
                }
                salesString.Append("\n\t**********************************************");
                salesString.Append("\n\tAmount Sold:" + total);
                float gst = total * .12f;
                salesString.Append("\n\tGST (12%):" + gst);
                total = total + gst;
                salesString.Append("\n\tTOTAL:" + total);
                salesString.Append("\n\t**********************************************");
                return salesString.ToString();
            }
            else return "\nYou have no sales yet.";
        }

        public SoldProduct GetExistingProductSold(int productNumber)
        {
            return MySales.Find(ap => ap.ProductNumber == productNumber);
        }

        public StockedProduct GetStockedProduct(int productNumber)
        {
            return MyStocks.Find(ap => ap.ProductNumber == productNumber);
        }

    }

}
