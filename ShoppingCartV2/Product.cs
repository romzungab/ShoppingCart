using System.Text;


namespace ShoppingCartV2
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public Product() { }
        public Product(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString() {
            StringBuilder productString = new StringBuilder();
            productString.Append("\t" + this.Name + "\t" + this.Price + "\t" );
            return productString.ToString();
        }
    }
}
