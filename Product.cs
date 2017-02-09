namespace ShoppingCart
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumberAvailable { get; set; }
        public int ProductNumber { get; set; }
        public static int _prodNumber = 1;
        public Product(string name, float price, int numberAvailable)
        {
            this.Name = name;
            this.Price = price;
            this.NumberAvailable = numberAvailable;
            this.ProductNumber = _prodNumber++;
        }
        override
        public string ToString()
        {
            return this.ProductNumber + "\t" + this.Name + "\t" + this.Price + "\t" + this.NumberAvailable;
        }
    }
}
