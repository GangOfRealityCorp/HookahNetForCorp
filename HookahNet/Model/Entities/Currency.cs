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

        public Currency()
        {
            CurrencyName = Enum.GetName(typeof(Currencies), 0);
            CurrencyValue = 0;
        }
        public enum Currencies { USD, EUR, RUB };

        public void SetCurrency(Currencies currency)
        {
            CurrencyName = Enum.GetName(typeof(Currencies), (int)currency);
            CurrencyValue = (int)currency;
        }
    }
}
