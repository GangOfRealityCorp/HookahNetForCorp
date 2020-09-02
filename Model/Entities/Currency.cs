using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Entities
{
    public class Currency
    {
        public string CurrencyName { get; private set; }
        public int CurrencyValue { get; private set; }

        public enum Currencies { USD, EUR, RUB };

        public void SetCurrency(int currency)
        {
            CurrencyName = Enum.GetName(typeof(Currencies), currency);
            CurrencyValue = currency;
        }
    }
}
