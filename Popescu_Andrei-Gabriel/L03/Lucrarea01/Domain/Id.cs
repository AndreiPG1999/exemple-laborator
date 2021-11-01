using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace LAB02.Domain
{
    public class Id
    {
        public int Value { get; set; }

        public Id(int value)
        {
            Value = value;
        }

        public static Option<Id> TryParseId(string id)
        {
            if (int.TryParse(id, out var idResult))
                return Some<Id>( new Id(idResult));
            Console.WriteLine("Product Id must be an integer >0");
            return None;
        }
    }
}
