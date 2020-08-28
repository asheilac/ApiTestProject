using Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestProject
{
    [TestFixture]
    public class CalculatorTests
    {       
        [Test]
        public void CalcLogic_Add_ShouldReturnCorrectAddition()
        {
            //Arrange
            var calclogic = new CalcLogic();
            int num1 = 5;
            int num2 = 6;

            //Act
            var result = calclogic.Add(num1,num2);

            //Assert
            Assert.AreEqual(11, result);
        }
        [Test]
        public void CalcLogic_Subtract_ShouldReturnCorrectSubtraction()
        {
            //Arrange
            var calclogic = new CalcLogic();
            int num1 = 5;
            int num2 = 6;

            //Act
            var result = calclogic.Subtract(num1, num2);

            //Assert
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void CalcLogic_Multiply_ShouldReturnCorrectMultiplication()
        {
            //Arrange
            var calclogic = new CalcLogic();
            int num1 = 5;
            int num2 = 6;

            //Act
            var result = calclogic.Multiply(num1, num2);

            //Assert
            Assert.AreEqual(30, result);
        }
        [Test]
        public void CalcLogic_Divide_ShouldReturnCorrectDivision()
        {
            //Arrange
            var calclogic = new CalcLogic();
            int num1 = 30;
            int num2 = 6;

            //Act
            var result = calclogic.Divide(num1, num2);

            //Assert
            Assert.AreEqual(5, result);
        }
    }    
}
