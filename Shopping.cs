using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Shopping
    {
        static Store MyStore;
        static Cart MyShoppingCart;
        public static void Main(string[] args)
        {
            MyStore = new Store("Tech Store");
            MyShoppingCart = new Cart();
            Welcome();
            ShowMenu();
        }

        public static void Welcome()
        {
            Console.WriteLine("\nWelcome to my " + MyStore.StoreName);
            Console.WriteLine("\nEnjoy Shopping!!!");
        }
        public static void ShowMenu()
        {
            string task;
            Console.WriteLine("\n\tPlease select what you want to do, enter the number");
            Console.WriteLine("\t1\t-\tShow Product List");
            Console.WriteLine("\t2\t-\tAdd Product to Cart");
            Console.WriteLine("\t3\t-\tShow my Cart");
            Console.WriteLine("\t4\t-\tCheckout");
            Console.WriteLine("\t5\t-\tExit");

            task = Console.ReadLine();
            switch (task)
            {
                case "1":
                    ShowProductList();
                    ShowMenu();
                    break;
                case "2":
                    AddProductToCart();
                    ShowMenu();
                    break;
                case "3":
                    ShowMyCart();
                    ShowMenu();
                    break;
                case "4":
                    Checkout();
                    ShowMenu();
                    break;
                case "5":
                    Exit();
                    break;
                case "sales":
                    PrintSales();
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Please enter correct input");
                    ShowMenu();
                    break;
            }
        }

        public static void ShowProductList()
        {
            Console.WriteLine("\n*************************************************");
            Console.WriteLine("\tPlease select from the products below");
            Console.WriteLine("\tNumber\tName\tPrice\tIn Stock");
            foreach (Product p in MyStore.MyStocks)
            {
                Console.WriteLine("\t" + p.ToString());
            }
            Console.WriteLine("*************************************************");

        }

        public static void AddProductToCart()
        {
            Console.Write("\tEnter the product number:");
            int pNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\tEnter the quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product product = MyStore.MyStocks.Find(p => p.ProductNumber == pNumber);
            if (product != null)
            {
                AddedProduct addedProduct = new AddedProduct(product, quantity);
                MyShoppingCart.AddToCart(addedProduct);
                product.NumberAvailable = product.NumberAvailable - quantity;
            }
            else
            {
                Console.WriteLine("\n! The product you entered DOES NOT EXIST !");
            }
        }
        public static void ShowMyCart()
        {
            Console.WriteLine(MyShoppingCart.ToString());
        }

        public static void Checkout()
        {
            Console.WriteLine("Checking out your cart");
            Console.WriteLine(MyShoppingCart.ToString());
            Console.WriteLine("Congratulations on your purchase!!");
            Console.WriteLine("See you on your next shopping!!");
            foreach (AddedProduct addP in MyShoppingCart.MyCart)
            {
                AddedProduct existingProduct = MyStore.GetExistingProductSold(addP.MyProduct.ProductNumber);
                if (existingProduct == null)
                {
                    MyStore.AddToSales(addP);
                }
                else
                {
                    existingProduct.Quantity = existingProduct.Quantity + addP.Quantity;
                }
            }
            MyShoppingCart.MyCart.Clear();

        }


        public static void Exit()
        {
            Console.WriteLine("Thank you for shopping. Have a nice day");
            Environment.Exit(0);
        }

        public static void PrintSales()
        {
            Console.WriteLine(MyStore.PrintSales());
        }
    }
}
