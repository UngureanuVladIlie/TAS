using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    class ContBancar
    {
        private float fSumaBani;
        public float FSumaBani { get => fSumaBani; }

        public ContBancar()
        {
            fSumaBani = 0;
        }

        public ContBancar(float fValoare)
        {
            if (fValoare >= 0)
            {
                fSumaBani = fValoare;
            }
            else
            {
                throw new NegativeInputValueException();
            }
        }

        public void vDepunereNumerar(float fValoare)
        {
            if (fValoare >= 0)
            {
                fSumaBani += fValoare;
            }
            else
            {
                throw new NegativeInputValueException();
            }
        }

        public bool bRetrageNumerar(float fValoare)
        {
            bool bSuccesOperatie = false;
            if (fValoare >= 0)
            {
                if (fSumaBani >= fValoare)
                {
                    fSumaBani -= fValoare;
                    bSuccesOperatie = true;
                }
            }
            else
            {
                throw new NegativeInputValueException();
            }
            return bSuccesOperatie;
        }

        public bool bTransferNumerar(float fValoare, ContBancar oContDestinatie)
        {
            bool bSuccesOperatie = false;
            if (fValoare >= 0)
            {
                if (bRetrageNumerar(fValoare))
                {
                    oContDestinatie.vDepunereNumerar(fValoare);
                    bSuccesOperatie = true;
                }
            }
            else
            {
                throw new NegativeInputValueException();
            }
            return bSuccesOperatie;
        }
        public bool bTransferFundsFromEurAmount(ContBancar destinatie, float fSumaInEuro, ICurrencyConvertor convertor)
        {
            float fSumaInRon = convertor.EurToRon(fSumaInEuro);
            bool bSuccesOperatie = this.bTransferNumerar(fSumaInRon, destinatie);
            return bSuccesOperatie;
        }
    }
}
