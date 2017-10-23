using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit
{
    //Domain testing
    [TestFixture]
    public class TestClassDomain
    {
        [Test]
        [Category("Pass")]
        [TestCase(0, 0)]
        [TestCase(500, 500)]
        [TestCase(float.MaxValue, float.MaxValue)]
        public void Contructor_Domain_Success(float fSumaInitiala, float fSumaAsteptata)
        {
            //arrange
            ContBancar contA;
            //act
            contA = new ContBancar(fSumaInitiala);
            //assert
            Assert.AreEqual(fSumaAsteptata, contA.FSumaBani);
        }

        [Test]
        [Category("Fail")]
        [TestCase(-1, 0, true)]
        public void Contructor_Domain_Exception(float fSumaInitiala, float fSumaAsteptata, bool bEroareAsteptata)
        {
            //arrange
            bool bExceptie = false;
            ContBancar contA;
            //act
            try
            {
                contA = new ContBancar(fSumaInitiala);
            }
            catch (NegativeInputValueException)
            {
                bExceptie = true;
            }
            //assert
            Assert.AreEqual(bEroareAsteptata, bExceptie);
        }

        [Test]
        [Category("Pass")]
        [TestCase(100, 0, 100)]
        [TestCase(100, 500, 600)]
        [TestCase(100, float.MaxValue, float.MaxValue)]
        public void DepunereNumerar_Domain_Success(float fSumaInitiala, float fSumaDepusa, float fSumaNouaAsteptata)
        {
            //arrange
            ContBancar contA = new ContBancar(fSumaInitiala);
            //act
            contA.vDepunereNumerar(fSumaDepusa);
            //assert
            Assert.AreEqual(fSumaNouaAsteptata, contA.FSumaBani);
        }

        [Test]
        [Category("Fail")]
        [TestCase(100, -1, 100, true)]
        public void DepunereNumerar_Domain_Exception(float fSumaInitiala, float fSumaDepusa, float fSumaNouaAsteptata, bool bEroareAsteptata)
        {
            //arrange
            bool bExceptie = false;
            ContBancar contA = new ContBancar(fSumaInitiala);
            //act
            try
            {
                contA.bRetrageNumerar(fSumaDepusa);
            }
            catch (NegativeInputValueException)
            {
                bExceptie = true;
            }
            //assert
            Assert.AreEqual(bEroareAsteptata, bExceptie);
            Assert.AreEqual(fSumaNouaAsteptata, contA.FSumaBani);
        }

        [Test]
        [Category("Pass")]
        [TestCase(500, 0, 500, true)]
        [TestCase(500, 100, 400, true)]
        [TestCase(500, 500, 0, true)]
        [TestCase(500, 501, 500, false)]
        public void RetragereNumerar_Domain_Success(float fSumaInitiala, float fSumaRetrasa, float fSumaRamasaAsteptata, bool bRezltatOperatieAsteptat)
        {
            //arrange
            bool bSuccesOperatie = false;
            ContBancar contA = new ContBancar(fSumaInitiala);
            //act
            bSuccesOperatie = contA.bRetrageNumerar(fSumaRetrasa);
            //assert
            Assert.AreEqual(fSumaRamasaAsteptata, contA.FSumaBani);
            Assert.AreEqual(bRezltatOperatieAsteptat, bSuccesOperatie);
        }

        [Test]
        [Category("Fail")]
        [TestCase(500, -1, 500, false, true)]
        public void RetragereNumerar_Domain_Exception(float fSumaInitiala, float fSumaRetrasa, float fSumaRamasaAsteptata, bool bRezltatOperatieAsteptat, bool bEroareAsteptata)
        {
            //arrange
            bool bSuccesOperatie = false;
            bool bExceptie = false;
            ContBancar contA = new ContBancar(fSumaInitiala);
            //act
            try
            {
                bSuccesOperatie = contA.bRetrageNumerar(fSumaRetrasa);
            }
            catch (NegativeInputValueException)
            {
                bExceptie = true;
            }
            //assert
            Assert.AreEqual(bEroareAsteptata, bExceptie);
            Assert.AreEqual(fSumaRamasaAsteptata, contA.FSumaBani);
            Assert.AreEqual(bRezltatOperatieAsteptat, bSuccesOperatie);
        }

        [Test]
        [Category("Pass")]
        [TestCase(500, 200, 0, 500, 200, true)]
        [TestCase(500, 200, 100, 400, 300, true)]
        [TestCase(500, 200, 500, 0, 700, true)]
        [TestCase(500, 200, 501, 500, 200, false)]
        public void TransferNumerar_Domain_Success(float fSumaInitialaSursa, float fSumaInitialaDest, float fValoareTransferata, float fSumaAsteptataSursa, float fSumaAsteptataDest, bool bRezultatOperatieAsteptat)
        {
            //arrange
            bool bSuccesOperatie = false;
            ContBancar contSursa = new ContBancar(fSumaInitialaSursa);
            ContBancar contDest = new ContBancar(fSumaInitialaDest);
            //act
            bSuccesOperatie = contSursa.bTransferNumerar(fValoareTransferata, contDest);
            //assert
            Assert.AreEqual(fSumaAsteptataSursa, contSursa.FSumaBani);
            Assert.AreEqual(fSumaAsteptataDest, contDest.FSumaBani);
            Assert.AreEqual(bRezultatOperatieAsteptat, bSuccesOperatie);
        }

        [Test]
        [Category("Fail")]
        [TestCase(500, 200, -1, 500, 200, false, true)]
        public void TransferNumerar_Domain_Exception(float fSumaInitialaSursa, float fSumaInitialaDest, float fValoareTransferata, float fSumaAsteptataSursa, float fSumaAsteptataDest, bool bRezultatOperatieAsteptat, bool bEroareAsteptata)
        {
            //arrange
            bool bSuccesOperatie = false;
            bool bExceptie = false;
            ContBancar contSursa = new ContBancar(fSumaInitialaSursa);
            ContBancar contDest = new ContBancar(fSumaInitialaDest);
            //act
            try
            {
                bSuccesOperatie = contSursa.bTransferNumerar(fValoareTransferata, contDest);
            }
            catch (NegativeInputValueException)
            {
                bExceptie = true;
            }
            //assert
            Assert.AreEqual(bEroareAsteptata, bExceptie);
            Assert.AreEqual(fSumaAsteptataSursa, contSursa.FSumaBani);
            Assert.AreEqual(fSumaAsteptataDest, contDest.FSumaBani);
            Assert.AreEqual(bRezultatOperatieAsteptat, bSuccesOperatie);
        }
    }
}
