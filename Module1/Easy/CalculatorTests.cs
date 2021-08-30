using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestableCodeDemos.Module1.Easy
{
    [TestFixture]
    [Category("Calculator Test")]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        [TestCase(1.00, 2.00, 0.50)]
        [TestCase(1.00, 2.00, 0.50)]
        [TestCase(1.00, 2.00, 0.50)]
        public void GetTotal_CalculateSub_GetCorrectSumBack(decimal parts, decimal service, decimal discount)
        {
            var result = _calculator.GetTotal(parts, service, discount);

            Assert.That(result, Is.EqualTo(2.50m));
            Assert.That(result > 0, Is.True);
            Assert.That(result > 0, Is.Not.False);
            Assert.That(result, Is.GreaterThan(0));

        }
    }
}
