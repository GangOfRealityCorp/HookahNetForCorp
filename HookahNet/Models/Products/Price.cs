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
        public decimal Value { get; private set; }
        public string Currency { get; private set; }
        public Price()
        {
        }
        public Price(decimal value, string currency)
        {
            this.Value = value;
            this.Currency = currency;
        }

        public static Price operator *(Price price, int amount)
        {
            decimal newPriceValue = price.Value * amount;
            return new Price(newPriceValue, price.Currency);
        }

        public static Price operator +(Price price, Price price2)
        {
            if(price.Currency != price2.Currency)
            {
                throw new Exception("Currencies of summable products are not equals");
            }
            decimal newPriceValue = price.Value + price2.Value;
            return new Price(newPriceValue, price.Currency);
        }
    }
}
