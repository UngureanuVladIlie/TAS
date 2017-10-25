using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    [TestFixture]
    public class TestClassCoverage
    {
        [Test]
        [TestCase(0)]
        public void ContructorNoParameters_Domain_Success(float fSumaAsteptata)
        {
            //arrange
            ContBancar contA;
            //act
            contA = new ContBancar();
            //assert
            Assert.AreEqual(fSumaAsteptata, contA.FSumaBani);
        }

        [Test]
        [TestCase(100, -50, 100, true)]
        public void DepunereNumerar_Exception(float fSumaInitiala, float fSumaDepusa, float fSumaAsteptata, bool bEroareAsteptata)
        {
            //arrange
            ContBancar contA = new ContBancar(fSumaInitiala);
            bool bExceptie = false;
            //act
            try
            {
                contA.vDepunereNumerar(fSumaDepusa);
            }
            catch (NegativeInputValueException)
            {
                bExceptie = true;
            }
            //assert
            Assert.AreEqual(fSumaAsteptata, contA.FSumaBani);
            Assert.AreEqual(bEroareAsteptata, bExceptie);
        }
    }
}
