using LanguageExt;
using System.Collections.Generic;
using static LanguageExt.Prelude;

namespace LAB02.Domain
{
    public class Price
    {
        public decimal Value { get; }

        public Price(decimal value)
        {
            Value = value;
        }
        public static Option<Price> GetPrice(IEnumerable<Product> products, int id)
        {
            foreach (var product in products)
            {
                if (product.Id.Value == id)
                {
                    return new Some<Price>(new Price(product.Price.Value));
                }
            }

            return None;
        }
    }
}
