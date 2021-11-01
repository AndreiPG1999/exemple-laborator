using System;
using System.Collections.Generic;
namespace LAB02.Domain
{
    public static class ProductsDb
    {
        public static IEnumerable<Product> LoadProducts()
        {
            return new List<Product>
            {
                new Product(new Id(1), "Produs1", new Price(9.99m), new Stock(24)),
                new Product(new Id(2), "Produs2", new Price(1.25m), new Stock(4)),
                new Product(new Id(3), "Produs3", new Price(6.99m), new Stock(11)),
                new Product(new Id(4), "Produs4", new Price(5.01m), new Stock(30)),
                new Product(new Id(5), "Produs5", new Price(3.30m), new Stock(21)),
                new Product(new Id(6), "Produs6", new Price(0.30m), new Stock(3))
            };
        }

        public static void ShowProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($@"ID: {product.Id.Value} Name: {product.Name} Price: {product.Price.Value};");
            }
        }
    }
}
