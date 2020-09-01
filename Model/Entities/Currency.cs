using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Entities
{
    public class Currency
    {
        private string currency;
        //public string Currency
        //{
        //    get
        //    {
        //        return currency;
        //    }
        //    set
        //    {

        //        currency = value;
        //    }
        //}

        private enum currencies { USD, EUR, RUB };

        public void SetCurrency(string currency)
        {
            //TODO: map with enum
        }
    }
}
