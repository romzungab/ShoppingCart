using System;
using System.Collections.Generic;
using System.Text;


namespace ShoppingCartV2
{
    public class Cart
    {
        public List<SoldProduct> MyCart { get; set; }

        public Cart()
        {
            MyCart = new List<SoldProduct>();
        }


        public void AddToCart(SoldProduct product)
        {
            MyCart.Add(product);
            Console.WriteLine("\t" + product.Quantity + " " + product.Name + " Added to Cart Successfully!");
        }


        public void EmptyCart()
        {
            MyCart.Clear();
        }

        public override string ToString()
        {
            if (MyCart.Count > 0)
            {
                StringBuilder cartString = new StringBuilder();
                float total = 0.0f;
                cartString.Append("\n\t**********************************************");
                cartString.Append("\n\tYou have the following products in your cart");
                cartString.Append("\n\t**********************************************");
                cartString.Append("\n\n\t Name\tPrice\tQty\tAmount\n");
                foreach (SoldProduct p in MyCart)
                {
                    cartString.Append(p.ToString());
                    float amount = p.Price * p.Quantity;
                    total = total + amount;
                }
                cartString.Append("\n\t**********************************************");
                cartString.Append("\n\tAMOUNT:" + total);
                float gst = total * .12f;
                cartString.Append("\n\tGST (12%):" + gst);
                total = total + gst;
                cartString.Append("\n\tTOTAL:" + total);
                cartString.Append("\n\t**********************************************");
                return cartString.ToString();
            }
            else return "\nYou have an EMPTY cart. Please add items to your cart";
        }

        public bool IsNotEmpty()
        {
            if (MyCart.Count > 0)
                return true;
            else return false;
        }

        public bool ProductExists(int productNumber)
        {
            if (MyCart.Find(ap => ap.ProductNumber == productNumber) == null)
                return false;
            else return true;

        }

        public SoldProduct GetProduct(int productNumber)
        {
            return MyCart.Find(ap => ap.ProductNumber == productNumber);
        }
    }
}
