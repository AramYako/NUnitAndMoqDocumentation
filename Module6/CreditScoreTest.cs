using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Module6
{
    [TestFixture]
    public class CreditScoreTest
    {
        private Mock<ICreditScore> _mockCreditScore;
        private LoadProcess _loadProcess; 

        [SetUp]
        public void SetUp()
        {

            _mockCreditScore = new Mock<ICreditScore>();

            _loadProcess = new LoadProcess(_mockCreditScore.Object);
        }


        #region ModifyProperty

        [Test]
        [TestCase(200, ExpectedResult =false)]
        [TestCase(600, ExpectedResult = true)]
        public bool CreditScoreValue_CheckIfCreditScoreIsValid_ExpectToBeValidated(int creditScore)
        {
            _mockCreditScore
                .Setup(x => x.CreditScoreValue)
                .Returns(creditScore);

            return _loadProcess.Execute();
        }
        #endregion

        #region Track properties

        [Test]
        [TestCase(200)]
        public void CreditScoreValue_CheckForUpdates_ExpectOneUpdate(int creditScore)
        {

            _mockCreditScore.SetupAllProperties(); //Track all properties 

            _loadProcess.Execute();

            Assert.That(_mockCreditScore.Object.Count, Is.EqualTo(1));
        }
        #endregion

        #region Verify Property Was Read
        [Test]
        [TestCase(200)]
        public void CreditScoreValue_ValidatePropertyHasBeenRead_PropertyHasBeenRead(int creditScore)
        {

            _loadProcess.Execute();

            _mockCreditScore.VerifyGet(x => x.CreditScoreValue);


        }
        #endregion

        #region Verify Property Was Set
        [Test]
        [TestCase(200)]
        public void CreditScoreValue_ValidatePropertyHasBeenSet_PropertyHasBeenSet(int creditScore)
        {

            _loadProcess.Execute();

            _mockCreditScore.VerifySet(x => x.Count = It.IsAny<int>(), Times.Once);


        }
        #endregion

    }
}
