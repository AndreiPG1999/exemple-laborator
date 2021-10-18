using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01.Fake
{
    public static class FakeDB
    {
        public static IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new Product(1, "Paine", 0.99f),
                new Product(2, "Zahar", 1.00f),
                new Product(3, "Cafea", 3.99f),
                new Product(4, "Mere", 1.99f),
            };
        }
    }
}
