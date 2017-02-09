using System.Text;


namespace ShoppingCartV2
{
    public class StockedProduct : Product
    {
        public int ProductNumber { get; set; }
        public int AvailableStock { get; set; }
        

        public StockedProduct() : base() { }
        public StockedProduct(string name, float price, int availableStock, int productNumber) : base(name, price)
        {
            ProductNumber = productNumber;
            AvailableStock = availableStock;
        }


        public override string ToString()
        {
            StringBuilder soldProductString = new StringBuilder();
            soldProductString.Append("\n\t" + this.ProductNumber + base.ToString() + this.AvailableStock);
            return soldProductString.ToString();
        }
    }
}
