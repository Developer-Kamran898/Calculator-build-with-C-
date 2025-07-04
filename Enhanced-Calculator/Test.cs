using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnhancedCalculator;

namespace EnhancedCalculator.Tests
{
    [TestClass]
    public class OperationsTests
    {
        private Operations _operations;

        [TestInitialize]
        public void Setup()
        {
            _operations = new Operations();
        }

        #region Basic Operations Tests

        [TestMethod]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            double num1 = 5.5;
            double num2 = 3.2;
            double expected = 8.7;

            // Act
            double result = _operations.Add(num1, num2);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Add_PositiveAndNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            double num1 = 10;
            double num2 = -3;
            double expected = 7;

            // Act
            double result = _operations.Add(num1, num2);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            double num1 = 10;
            double num2 = 4;
            double expected = 6;

            // Act
            double result = _operations.Subtract(num1, num2);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            double num1 = 4;
            double num2 = 5;
            double expected = 20;

            // Act
            double result = _operations.Multiply(num1, num2);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            double num1 = 15;
            double num2 = 3;
            double expected = 5;

            // Act
            double result = _operations.Divide(num1, num2);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            double num1 = 10;
            double num2 = 0;

            // Act
            _operations.Divide(num1, num2);
        }

        [TestMethod]
        public void Power_PositiveBase_ReturnsCorrectResult()
        {
            // Arrange
            double baseNumber = 2;
            double exponent = 3;
            double expected = 8;

            // Act
            double result = _operations.Power(baseNumber, exponent);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void SquareRoot_PositiveNumber_ReturnsCorrectResult()
        {
            // Arrange
            double number = 16;
            double expected = 4;

            // Act
            double result = _operations.SquareRoot(number);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareRoot_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            double number = -16;

            // Act
            _operations.SquareRoot(number);
        }

        [TestMethod]
        public void Percentage_ValidInputs_ReturnsCorrectResult()
        {
            // Arrange
            double value = 200;
            double percentage = 15;
            double expected = 30;

            // Act
            double result = _operations.Percentage(value, percentage);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        #endregion

        #region Scientific Operations Tests

        [TestMethod]
        public void Sine_Zero_ReturnsZero()
        {
            // Arrange
            double angle = 0;
            double expected = 0;

            // Act
            double result = _operations.Sine(angle);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Cosine_Zero_ReturnsOne()
        {
            // Arrange
            double angle = 0;
            double expected = 1;

            // Act
            double result = _operations.Cosine(angle);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Log10_Ten_ReturnsOne()
        {
            // Arrange
            double number = 10;
            double expected = 1;

            // Act
            double result = _operations.Log10(number);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Log10_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            double number = -10;

            // Act
            _operations.Log10(number);
        }

        [TestMethod]
        public void Factorial_Zero_ReturnsOne()
        {
            // Arrange
            int number = 0;
            long expected = 1;

            // Act
            long result = _operations.Factorial(number);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Factorial_Five_ReturnsCorrectResult()
        {
            // Arrange
            int number = 5;
            long expected = 120;

            // Act
            long result = _operations.Factorial(number);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Factorial_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            int number = -5;

            // Act
            _operations.Factorial(number);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Factorial_LargeNumber_ThrowsOverflowException()
        {
            // Arrange
            int number = 25;

            // Act
            _operations.Factorial(number);
        }

        #endregion

        #region Statistical Operations Tests

        [TestMethod]
        public void Mean_ListOfNumbers_ReturnsCorrectMean()
        {
            // Arrange
            List<double> numbers = new List<double> { 1, 2, 3, 4, 5 };
            double expected = 3;

            // Act
            double result = _operations.Mean(numbers);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Mean_EmptyList_ThrowsArgumentException()
        {
            // Arrange
            List<double> numbers = new List<double>();

            // Act
            _operations.Mean(numbers);
        }

        [TestMethod]
        public void Median_OddNumberOfElements_ReturnsMiddleElement()
        {
            // Arrange
            List<double> numbers = new List<double> { 1, 3, 2, 5, 4 };
            double expected = 3;

            // Act
            double result = _operations.Median(numbers);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void Median_EvenNumberOfElements_ReturnsAverageOfMiddleElements()
        {
            // Arrange
            List<double> numbers = new List<double> { 1, 2, 3, 4 };
            double expected = 2.5;

            // Act
            double result = _operations.Median(numbers);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void StandardDeviation_ListOfNumbers_ReturnsCorrectValue()
        {
            // Arrange
            List<double> numbers = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };
            double expected = 2.138; // Approximate expected value

            // Act
            double result = _operations.StandardDeviation(numbers);

            // Assert
            Assert.AreEqual(expected, result, 0.01);
        }

        #endregion
    }

    [TestClass]
    public class HistoryTests
    {
        private History _history;

        [TestInitialize]
        public void Setup()
        {
            _history = new History();
        }

        [TestMethod]
        public void AddCalculation_ValidCalculation_AddsToHistory()
        {
            // Arrange
            string calculation = "2 + 3 = 5";

            // Act
            _history.AddCalculation(calculation);

            // Assert
            Assert.AreEqual(1, _history.Count);
            Assert.IsFalse(_history.IsEmpty);
        }

        [TestMethod]
        public void AddCalculation_NullOrEmptyCalculation_DoesNotAddToHistory()
        {
            // Act
            _history.AddCalculation(null);
            _history.AddCalculation("");
            _history.AddCalculation("   ");

            // Assert
            Assert.AreEqual(0, _history.Count);
            Assert.IsTrue(_history.IsEmpty);
        }

        [TestMethod]
        public void Clear_RemovesAllCalculations()
        {
            // Arrange
            _history.AddCalculation("2 + 3 = 5");
            _history.AddCalculation("4 * 5 = 20");

            // Act
            _history.Clear();

            // Assert
            Assert.AreEqual(0, _history.Count);
            Assert.IsTrue(_history.IsEmpty);
        }

        [TestMethod]
        public void GetLastCalculations_ReturnsCorrectNumber()
        {
            // Arrange
            _history.AddCalculation("1 + 1 = 2");
            _history.AddCalculation("2 + 2 = 4");
            _history.AddCalculation("3 + 3 = 6");

            // Act
            var lastTwo = _history.GetLastCalculations(2);

            // Assert
            Assert.AreEqual(2, lastTwo.Count);
        }
    }

    [TestClass]
    public class MemoryTests
    {
        private Memory _memory;

        [TestInitialize]
        public void Setup()
        {
            _memory = new Memory();
        }

        [TestMethod]
        public void Store_ValidValue_StoresInMemory()
        {
            // Arrange
            double value = 42.5;

            // Act
            _memory.Store(value);

            // Assert
            Assert.AreEqual(value, _memory.Recall(), 0.0001);
            Assert.IsTrue(_memory.HasValue);
        }

        [TestMethod]
        public void Add_ValidValue_AddsToMemory()
        {
            // Arrange
            _memory.Store(10);
            double valueToAdd = 5;

            // Act
            _memory.Add(valueToAdd);

            // Assert
            Assert.AreEqual(15, _memory.Recall(), 0.0001);
        }

        [TestMethod]
        public void Subtract_ValidValue_SubtractsFromMemory()
        {
            // Arrange
            _memory.Store(10);
            double valueToSubtract = 3;

            // Act
            _memory.Subtract(valueToSubtract);

            // Assert
            Assert.AreEqual(7, _memory.Recall(), 0.0001);
        }

        [TestMethod]
        public void Clear_ResetsMemoryToZero()
        {
            // Arrange
            _memory.Store(100);

            // Act
            _memory.Clear();

            // Assert
            Assert.AreEqual(0, _memory.Recall(), 0.0001);
            Assert.IsFalse(_memory.HasValue);
        }

        [TestMethod]
        public void CurrentValue_ReturnsStoredValue()
        {
            // Arrange
            double expectedValue = 25.75;
            _memory.Store(expectedValue);

            // Act
            double currentValue = _memory.CurrentValue;

            // Assert
            Assert.AreEqual(expectedValue, currentValue, 0.0001);
        }
    }
}