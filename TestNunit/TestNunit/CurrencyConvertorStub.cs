using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    class CurrencyConvertorStub : ICurrencyConvertor
    {
        private float rateEurRon;

        public CurrencyConvertorStub(float rateEurRon)
        {
            if (rateEurRon > 0)
                this.rateEurRon = rateEurRon;
            else
                this.rateEurRon = 0;
        }

        public float EurToRon(float ValueInEur)
        {
            return ValueInEur * rateEurRon;
        }

        public float RonToEur(float ValueInRon)
        {
            return ValueInRon / rateEurRon;
        }
    }
}
