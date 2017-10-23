using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TestNunit
{
    [TestFixture]
    public class TestClassMockFramework
    {
        [Test]
        [TestCase(500, 0, 4, 100, 100, 400, true)]
        [TestCase(500, 0, 4.5f, 100, 50, 450, true)]
        [TestCase(500, 0, 0, 100, 500, 0, true)]
        [TestCase(0, 0, 4.5f, 100, 0, 0, false)]
        public void TransferFundsFromEurAmount_MockFramework(float fSumaInitialaSursa, float fSumaInitialaDest, float fRataE2R, float fSumaInEuro, float fSumaAsteptataSursa, float fSumaAsteptataDest, bool bRezultatOperatieAsteptat)
        {
            //arrange
            ContBancar contSursa = new ContBancar(fSumaInitialaSursa);
            ContBancar contDest = new ContBancar(fSumaInitialaDest);
            Mock<ICurrencyConvertor> convertorMock = new Mock<ICurrencyConvertor>();
            bool bSuccesOperatie = false;
            convertorMock.Setup(m => m.EurToRon(fSumaInEuro)).Returns(fSumaInEuro * fRataE2R);
            //act
            bSuccesOperatie = contSursa.bTransferFundsFromEurAmount(contDest, fSumaInEuro, convertorMock.Object);
            //assert
            Assert.AreEqual(fSumaAsteptataSursa, contSursa.FSumaBani);
            Assert.AreEqual(fSumaAsteptataDest, contDest.FSumaBani);
            Assert.AreEqual(bRezultatOperatieAsteptat, bSuccesOperatie);
            convertorMock.Verify(m => m.EurToRon(fSumaInEuro), Times.Once());
        }

        [Test]
        [TestCase(500, 0, -4.5f, 100, 500, 0, false, true)]
        public void TransferFundsFromEurAmount_MockFramework_Exception(float fSumaInitialaSursa, float fSumaInitialaDest, float fRataE2R, float fSumaInEuro, float fSumaAsteptataSursa, float fSumaAsteptataDest, bool bRezultatOperatieAsteptat, bool bEroareAsteptata)
        {
            //arrange
            ContBancar contSursa = new ContBancar(fSumaInitialaSursa);
            ContBancar contDest = new ContBancar(fSumaInitialaDest);
            Mock<ICurrencyConvertor> convertorMock = new Mock<ICurrencyConvertor>();
            bool bSuccesOperatie = false;
            bool bExceptie = false;
            convertorMock.Setup(m => m.EurToRon(fSumaInEuro)).Returns(fSumaInEuro * fRataE2R);
            //act
            try
            {
                bSuccesOperatie = contSursa.bTransferFundsFromEurAmount(contDest, fSumaInEuro, convertorMock.Object);
            }
            catch (NegativeInputValueException)
            {
                bExceptie = true;
            }
            //assert
            Assert.AreEqual(fSumaAsteptataSursa, contSursa.FSumaBani);
            Assert.AreEqual(fSumaAsteptataDest, contDest.FSumaBani);
            Assert.AreEqual(bRezultatOperatieAsteptat, bSuccesOperatie);
            Assert.AreEqual(bEroareAsteptata, bExceptie);
            convertorMock.Verify(m => m.EurToRon(fSumaInEuro), Times.Once());
        }

    }
}
