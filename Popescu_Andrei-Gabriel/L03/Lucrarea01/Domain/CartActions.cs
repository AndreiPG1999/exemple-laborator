using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LAB02.Domain.CartState;

namespace LAB02.Domain
{
    public static class CartActions
    {
        public static async Task<ICartState> AddToCartAsync(Cart cart, int id, int quantity, IEnumerable<Product> products)
        {
            ICartState cartState = new CartState.EmptyCart(cart);

            if (await Task.Run(() => Product.ProductExists(id, products) == false))
            {
                return new InvalidCart(cart, "doesn't exists");
            }

            if (quantity <= 0)
            {
                cartState = new InvalidCart(cart, "Quantity must be bigger than 0");
                return cartState;
            }
            if (id <= 0)
            {
                return new InvalidCart(cart, "Selected product is not available");
            }
            if (await Task.Run(() => Product.IsDuplicate(cart, id)))
            {
                return new InvalidCart(cart, "Product is already in Cart");
            }
            if (await Task.Run(() => Stock.UpdateStock(id, quantity, products) < 0))
            {
                return new InvalidCart(cart, "Product is out of stock");
            }

            cart.ItemsInCart.Add(id, quantity);
            return new ValidCart(cart);
        }

        public static ICartState PayCart(Cart cart, string message)
        {
            Console.WriteLine($"Cart is {message}");
            return new PaidCart();
        }
    }
}
