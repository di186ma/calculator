using System;
using Xunit;

namespace CalculatorTests
{
    public class UnitTests
    {
        [Fact]
        public void SumTest()
        {
            string expression = "2+2";
            string result = "4";
            string testing = CalculatorLogic.Calculations.Calculate(expression);
            Assert.Equal(result, testing);
        }

        [Fact]
        public void SubTest()
        {
            string expression = "100-100";
            string result = "0";
            string testing = CalculatorLogic.Calculations.Calculate(expression);
            Assert.Equal(result, testing);
        }

        [Fact]
        public void MultTest()
        {
            string expression = "10*10";
            string result = "100";
            string testing = CalculatorLogic.Calculations.Calculate(expression);
            Assert.Equal(result, testing);
        }

        [Fact]
        public void DivTest()
        {
            string expression = "5/5";
            string result = "1";
            string testing = CalculatorLogic.Calculations.Calculate(expression);
            Assert.Equal(result, testing);
        }

        [Fact]
        public void ComplexExpressionTest()
        {
            string expression = "3*8/9-10/5-100/10+46/8";
            double result = -2.58;
            double testing = double.Parse(CalculatorLogic.Calculations.Calculate(expression));
            testing = Math.Round(testing, 2);
            Assert.Equal(result, testing);
        }

        [Fact]
        public void ZeroDivTest()
        {
            string expression = "100/0";
            Assert.Throws<Exception>(() => CalculatorLogic.Calculations.Calculate(expression));
        }

        [Fact]
        public void IncorrectInputTest1()
        {
            string expression = "qwe";
            Assert.Throws<Exception>(() => CalculatorLogic.Calculations.Calculate(expression));
        }

        [Fact]
        public void IncorrectInputTest4()
        {
            string expression = "10";
            Assert.Throws<ArgumentException>(() => CalculatorLogic.Calculations.Calculate(expression));
        }

        [Fact]
        public void IncorrectInputTest2()
        {
            string expression = "2+t";
            Assert.Throws<Exception>(() => CalculatorLogic.Calculations.Calculate(expression));
        }

        [Fact]
        public void IncorrectInputTest3()
        {
            string expression = "2+";
            Assert.Throws<Exception>(() => CalculatorLogic.Calculations.Calculate(expression));
        }

    }
}
