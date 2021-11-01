using CSharp.Choices;

namespace LAB02.Domain
{
    [AsChoice]
    public static partial class CartState
    {
        public interface ICartState { }
        public record EmptyCart(Cart Cart) : ICartState;
        public record InvalidCart(Cart Cart, string Message) : ICartState;
        public record ValidCart(Cart Cart) : ICartState;
        public record PaidCart() : ICartState;
    }
}
