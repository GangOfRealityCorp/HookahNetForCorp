using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models.Products
{
    public class Price
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public readonly decimal value;
        public readonly string currency = string.Empty;
        public Price()
        {
        }
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

        public static Price operator +(Price price, Price price2)
        {
            if(price.currency != price2.currency)
            {
                throw new Exception("Currencies of summable products are not equals");
            }
            decimal newPriceValue = price.value + price2.value;
            return new Price(newPriceValue, price.currency);
        }
    }
}
