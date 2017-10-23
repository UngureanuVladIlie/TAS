using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    //Stunt doubles
    [TestFixture]
    public class TestClassDoubles
    {
        [Test]
        [Category("Pass")]
        // fSumaInitialaSursa,fSumaInitialaDest,fRataE2R,fSumaInEuro,fSumaAsteptataSursa,fSumaAsteptataDest,bRezultatOperatieAsteptat
        [TestCase(500, 0, 4, 100, 100, 400, true)]
        [TestCase(500, 0, 4.5f, 100, 50, 450, true)]
        [TestCase(500, 0, 0, 100, 500, 0, true)]
        [TestCase(500, 0, -4.5f, 100, 500, 0, true)]
        [TestCase(0, 0, 4.5f, 100, 0, 0, false)]
        public void TransfFundsFromEroAmount_simpleValues_Success(float fSumaInitialaSursa, float fSumaInitialaDest, float fRataE2R, float fSumaInEuro, float fSumaAsteptataSursa, float fSumaAsteptataDest, bool bRezultatOperatieAsteptat)
        {
            //arrange
            ContBancar contSursa = new ContBancar(fSumaInitialaSursa);
            ContBancar contDest = new ContBancar(fSumaInitialaDest);
            CurrencyConvertorStub convertorE2R = new CurrencyConvertorStub(fRataE2R);
            bool bSuccesOperatie = false;
            //act
            bSuccesOperatie = contSursa.bTransferFundsFromEurAmount(contDest, fSumaInEuro, convertorE2R);
            //assert
            Assert.AreEqual(fSumaAsteptataSursa, contSursa.FSumaBani);
            Assert.AreEqual(fSumaAsteptataDest, contDest.FSumaBani);
            Assert.AreEqual(bRezultatOperatieAsteptat, bSuccesOperatie);
        }
    }
}
