using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Products
{
    public class Price
    {
        public readonly decimal value;
        public readonly string currency;
        public Price(decimal value, string currency)
        {
            this.value = value;
            this.currency = currency;
        }

        public static Price operator *(Price price, int amount)
        {
            decimal newPriceValue = price.value * amount;
            return new Price(newPriceValue, price.currency);
        }
    }
}
