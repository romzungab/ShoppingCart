using System;

namespace ShoppingCartV2
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
            Console.WriteLine("\t5\t-\tEmpty my Cart");
            Console.WriteLine("\t0\t-\tExit");

            task = Console.ReadLine();
            switch (task)
            {
                case "1":
                    ShowProductList();
                    break;
                case "2":
                    AddProductToCart();
                    break;
                case "3":
                    ShowMyCart();
                    break;
                case "4":
                    Checkout();
                    break;
                case "5":
                    EmptyCart();
                    break;
                case "0":
                    Exit();
                    break;
                case "sales":
                    PrintSales();
                    break;
                default:
                    Console.WriteLine("Please enter correct input");
                    break;
            }
            ShowMenu();
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

        public static int GetNumberInput(string message)
        {
            int number = 0;
            try
            {
                Console.Write(message);
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("\tEnter numbers only");
                number = GetNumberInput(message);
            }
            return number;
        }

        public static void AddProductToCart()
        {
            int pNumber = GetNumberInput("\tEnter the product number:");
            int quantity = GetNumberInput("\tEnter the quantity: ");
            
            StockedProduct product = MyStore.MyStocks.Find(p => p.ProductNumber == pNumber);
            if (product != null)
            {
                
                SoldProduct addedProduct = new SoldProduct(product.Name, product.Price, product.AvailableStock, product.ProductNumber, quantity);
                MyShoppingCart.AddToCart(addedProduct);
                product.AvailableStock = product.AvailableStock - quantity;
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
            if (MyShoppingCart.IsNotEmpty())
            {
                Console.WriteLine("Checking out your cart");
                Console.WriteLine(MyShoppingCart.ToString());
                Console.WriteLine("Congratulations on your purchase!!");
                Console.WriteLine("See you on your next shopping!!");
                foreach (SoldProduct addP in MyShoppingCart.MyCart)
                {
                    SoldProduct existingProduct = MyStore.GetExistingProductSold(addP.ProductNumber);
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
            else
            {
                Console.WriteLine("You have nothing to check out");
            }
        }

        public static void EmptyCart()
        {
            if (MyShoppingCart.IsNotEmpty())
            {
                Console.WriteLine("\tReturning the following products");
                Console.WriteLine("\n\n\t Name\tPrice\tQty\tAmount\n");
                foreach (SoldProduct addP in MyShoppingCart.MyCart)
                {
                    StockedProduct toBeStocked = MyStore.GetStockedProduct(addP.ProductNumber);
                    Console.WriteLine(addP.ToString());
                    toBeStocked.AvailableStock = toBeStocked.AvailableStock + addP.Quantity;
                }
                MyShoppingCart.EmptyCart();
                Console.WriteLine("\n\t****Cart emptied****");
            }
            else
            {
                Console.WriteLine("You have an already empty cart");
            }
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
