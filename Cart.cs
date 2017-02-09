using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Cart
    {
        public List<AddedProduct> MyCart { get; set; }

        public Cart()
        {
            MyCart = new List<AddedProduct>();
        }


        public void AddToCart(AddedProduct product)
        {
            MyCart.Add(product);
            Console.WriteLine("\t" + product.Quantity + " " + product.MyProduct.Name + " Added to Cart Successfully!");
        }

        override
        public string ToString()
        {
            if (MyCart.Count > 0)
            {
                StringBuilder cartString = new StringBuilder();
                float total = 0.0f;
                cartString.Append("\n\t**********************************************");
                cartString.Append("\n\tYou have the following products in your cart");
                cartString.Append("\n\t**********************************************");
                cartString.Append("\n\n\t Name\tPrice\tQty\tAmount\n");
                foreach (AddedProduct p in MyCart)
                {
                    cartString.Append(p.ToString());
                    float amount = p.MyProduct.Price * p.Quantity;
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

    }
}
