using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02.Domain
{
    public class Stock
    {
        public int Value { get; set; }
        public Stock(int value)
        {
            Value = value;
        }
        public static int UpdateStock(int id, int quantity, IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                if (product.Id.Value == id)
                {
                    return product.Stock.Value -= quantity;
                }
            }
            return 0;
        }
    }
}
