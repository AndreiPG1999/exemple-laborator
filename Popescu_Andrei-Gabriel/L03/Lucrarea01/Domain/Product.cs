using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB02.Domain
{
    public class Product
    {
        public Product(Id id, string name, Price price, Stock stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Id Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public Stock Stock { get; set; }

        public static bool ProductExists(int id, IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                if (product.Id.Value == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDuplicate(Cart cart, int id)
        {
            return cart.ItemsInCart.Keys.Any(productKey => productKey == id);
        }
    }
}