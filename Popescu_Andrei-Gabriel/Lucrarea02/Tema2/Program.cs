using LanguageExt;
using System;
using L01.Fake;
using System.Linq;
using static L01.Domain.AppDomain;
using static L01.Domain.CartState;
using L01.Extensions;
using L01.Domain;

namespace L01
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = (CreateCart() as EmptyCart).Cart;
            while (true)
            {
                var (product, quantity) = RequestItem();
                var result = AddItemToCart(cart, product, quantity);
                var message = string.Empty;
                (cart, message) = result switch
                {
                    ValidCart a => (a.Cart, ""),
                    InvalidCart a => (a.Cart, a.Message + (Environment.NewLine * (StringMultiplication)2))
                };
                Displayitems(cart);

                Console.Write(message);
                if (RequestPayment())
                {
                    PayCart(cart);
                    Console.WriteLine($"O zi buna!");
                    break;
                }
            }
        }

        public static Unit Displayitems(Cart cart)
        {
            Console.WriteLine("Obiecte:");
            Console.Write(cart.Items
                .OrderBy(a => a.Product.Id)
                .Select(a => $"\t{a.Product.Id} / {a.Product.Name} / {a.Product.Price} / {a.Quantity}" + Environment.NewLine)
                .Aggregate((a, b) => a + b));
            Console.Write("Pret total: ");
            Console.WriteLine(cart.Items.Select(a => a.Product.Price * a.Quantity).Aggregate((a, b) => a + b));
            Console.WriteLine();
            return Unit.Default;
        }

        public static string RequestCredentials()
        {
            Console.Write("Va rugam introduceti parola: ");
            return Console.ReadLine();
        }

        public static (Option<Product>, int) RequestItem()
        {
            var products = FakeDB.LoadProducts();
            products.Iter(a => Console.WriteLine($"Id: {a.Id}, Pret: {a.Price}, Nume: {a.Name}"));
            Console.WriteLine("Va rugam selectati un item dupa id si introduceti cantitatea");
            Console.Write("Id produs: ");
            var productId = Console.ReadLine().Trim();
            Console.Write("Cantitate: ");
            var quantity = int.Parse(Console.ReadLine().Trim());
            var product = products.FirstOrDefault(a => a.Id.ToString() == productId);
            return (product, quantity);
        }

        public static bool RequestPayment()
        {
            Console.WriteLine("Va rugam introduceti \"Y\" daca doriti sa platiti sau orice altceva pentru a continua cumparaturile:");
            return Console.ReadLine().Trim().ToLower() switch
            {
                "y" => true,
                _ => false
            };
        }
    }
}
