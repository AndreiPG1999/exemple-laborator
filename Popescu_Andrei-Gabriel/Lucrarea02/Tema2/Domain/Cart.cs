using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L01.Fake;

namespace L01.Domain
{
    public record Cart(IEnumerable<(Product Product, int Quantity)> Items)
    {
        public Cart() : this(Enumerable.Empty<(Product, int)>()) { }
    }
}
