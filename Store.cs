using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Store
    {
        public List<Product> MyStocks { get; set; }
        public List<AddedProduct> MySales { get; set; }
        public string StoreName { get; set; }

        public Store(String name) {
            Console.WriteLine("Initializing Store");
            StoreName = name;
            Product product1 = new Product("Laptop", 1700.12f, 12);
            Product product2 = new Product("Phone", 501.20f, 12);
            Product product3 = new Product("Tablet", 307.30f, 12);

            MyStocks = new List<Product>();
            MyStocks.Add(product1);
            MyStocks.Add(product2);
            MyStocks.Add(product3);

            MySales = new List<AddedProduct>();
           Console.WriteLine("Store is Ready");
        }

        public void AddToSales(AddedProduct soldProduct) {
            MySales.Add(soldProduct);
        }

        public string PrintSales() {
            if (MySales.Count() > 0)
            {
                StringBuilder salesString = new StringBuilder();
                float total = 0.0f;
                salesString.Append("\n\t**********************************************");
                salesString.Append("\n\tYou have sold the following products");
                salesString.Append("\n\n\tName\tPrice\tQty\tAmount\n");
                foreach (AddedProduct p in MySales)
                {
                    salesString.Append(p.ToString());
                    float amount = p.MyProduct.Price * p.Quantity;
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

        public AddedProduct GetExistingProductSold(int productNumber) {
            return MySales.Find(ap => ap.MyProduct.ProductNumber == productNumber);
        }
    }

}
