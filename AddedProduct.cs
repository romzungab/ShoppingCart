using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class AddedProduct
    {
        public Product MyProduct { get; set; }
        public int Quantity { get; set; }
        public AddedProduct(Product myProduct, int quantity)
        {
            MyProduct = myProduct;
            Quantity = quantity;
        }
        override
        public string ToString()
        {
            StringBuilder addedProductString = new StringBuilder();

            addedProductString.Append("\n\t" + MyProduct.Name + "\t" + MyProduct.Price + "\t" + Quantity + "\t" + Quantity * MyProduct.Price);
            return addedProductString.ToString();
        }
    }
}
