using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    public interface ICurrencyConvertor
    {
        float EurToRon(float ValueInEur);
        float RonToEur(float ValueInRon);

    }
}
