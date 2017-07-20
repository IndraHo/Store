using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> mCartLines = new List<CartLine>();
        public IEnumerable<CartLine> Lines
        {
            get
            {
                return mCartLines;
            }
        }
        public void Add(Product product, int quantity)
        {
            CartLine line = mCartLines
                .Where(p => p.Product.ID == product.ID)
                .FirstOrDefault();
            if (line == null)
            {
                mCartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void Remove(Product product)
        {
            mCartLines.RemoveAll(l => l.Product.ID == product.ID);
        }
        public decimal ComputerTotalValue()
        {
            return mCartLines.Sum(c => c.Product.Price * c.Quantity);
        }
        public void Clear()
        {
            mCartLines.Clear();
        }
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
