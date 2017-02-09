using System.Text;


namespace ShoppingCartV2
{
    public class SoldProduct : StockedProduct
    {


        public int Quantity { get; set; }
        public SoldProduct() : base() { }
        public SoldProduct(string name, float price, int availableStock,int productNumber, int quantity) : base(name, price, availableStock, productNumber)
        {
            Quantity = quantity;
        }


        public override string ToString()
        {
            StringBuilder soldProductString = new StringBuilder();
            soldProductString.Append("\n\t" + Name + "\t" + Price + "\t" + Quantity + "\t" + Quantity * Price);
            return soldProductString.ToString();
        }
    }
}
