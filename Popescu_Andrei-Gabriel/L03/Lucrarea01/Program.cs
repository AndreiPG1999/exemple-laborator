using LAB02.Domain;
using System;
using System.Threading.Tasks;
using static LAB02.Domain.CartActions;
using static LAB02.Domain.CartState;

namespace Lucrarea03
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var products = ProductsDb.LoadProducts();
            var cart = new Cart();
            var shopping = true;
            var totalPrice = 0m;
            ProductsDb.ShowProducts(products);
            while (shopping)
            {
                var (id, quantity) = RequestProduct();
                var newCartState = await AddToCartAsync(cart, id, quantity, products);
                newCartState.Match(
                    whenEmptyCart: @event =>
                    {
                        Console.WriteLine($"Nothing in cart.");
                        return @event;
                    },
                    whenInvalidCart: @event =>
                    {
                        Console.WriteLine($"Shopping has failed: {@event.Message}");
                        return @event;
                    },
                    whenValidCart: @event =>
                    {
                        totalPrice += quantity * Price.GetPrice(products, id).Match(
                                                                            Some: value=>value.Value,
                                                                            None:()=>0);
                        Console.WriteLine($"All ok. Do you want to continue shopping? (Y/N)");
                        if (Console.ReadLine().ToUpper()=="N")
                        {
                            shopping = false;
                            Console.WriteLine($"Total is {totalPrice} $.Do you want to pay? (Y/N)");
                            PayCart(cart, Console.ReadLine().ToUpper() == "Y" ? "Paid" : "Not Paid");
                        }
                        return @event;
                    },
                    whenPaidCart: @event =>
                    {
                        Console.WriteLine($"Cart paid.{@event}");
                        return @event;
                    }
                );
            }
        }
        public static (int, int) RequestProduct()
        {
            Console.WriteLine("Select a product:");
            Console.WriteLine("Product Id:");

            var input = Console.ReadLine();
            var id = Id.TryParseId(input);

            Console.WriteLine("Quantity:");
            input = Console.ReadLine();
            var quantity = int.TryParse(input, out var quantityResult)? quantityResult : -1;

            return (id.Match(Some: idValue=>idValue.Value,
                    None: ()=>-1), quantity);
        }
    }
}
