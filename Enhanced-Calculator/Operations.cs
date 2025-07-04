using System;
using System.Collections.Generic;
using System.Linq;

namespace EnhancedCalculator
{
    /// <summary>
    /// Provides mathematical operations for the calculator
    /// </summary>
    public class Operations
    {
        private const double EPSILON = 1e-10;

        #region Basic Operations

        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Sum of the two numbers</returns>
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Subtracts second number from first number
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Difference of the two numbers</returns>
        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Product of the two numbers</returns>
        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Divides first number by second number
        /// </summary>
        /// <param name="num1">Dividend</param>
        /// <param name="num2">Divisor</param>
        /// <returns>Quotient of the division</returns>
        /// <exception cref="DivideByZeroException">Thrown when divisor is zero</exception>
        public double Divide(double num1, double num2)
        {
            if (Math.Abs(num2) < EPSILON)
                throw new DivideByZeroException("Cannot divide by zero");

            return num1 / num2;
        }

        /// <summary>
        /// Raises first number to the power of second number
        /// </summary>
        /// <param name="baseNumber">Base number</param>
        /// <param name="exponent">Exponent</param>
        /// <returns>Result of base raised to the power of exponent</returns>
        public double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        /// <summary>
        /// Calculates square root of a number
        /// </summary>
        /// <param name="number">Number to find square root of</param>
        /// <returns>Square root of the number</returns>
        /// <exception cref="ArgumentException">Thrown when number is negative</exception>
        public double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentException("Cannot calculate square root of negative number");

            return Math.Sqrt(number);
        }

        /// <summary>
        /// Calculates percentage of a value
        /// </summary>
        /// <param name="value">Original value</param>
        /// <param name="percentage">Percentage to calculate</param>
        /// <returns>Percentage of the value</returns>
        public double Percentage(double value, double percentage)
        {
            return (value * percentage) / 100;
        }

        #endregion

        #region Scientific Operations

        /// <summary>
        /// Calculates sine of an angle in radians
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Sine of the angle</returns>
        public double Sine(double angle)
        {
            return Math.Sin(angle);
        }

        /// <summary>
        /// Calculates cosine of an angle in radians
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Cosine of the angle</returns>
        public double Cosine(double angle)
        {
            return Math.Cos(angle);
        }

        /// <summary>
        /// Calculates tangent of an angle in radians
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Tangent of the angle</returns>
        public double Tangent(double angle)
        {
            return Math.Tan(angle);
        }

        /// <summary>
        /// Calculates logarithm base 10 of a number
        /// </summary>
        /// <param name="number">Number to find logarithm of</param>
        /// <returns>Logarithm base 10 of the number</returns>
        /// <exception cref="ArgumentException">Thrown when number is not positive</exception>
        public double Log10(double number)
        {
            if (number <= 0)
                throw new ArgumentException("Logarithm is only defined for positive numbers");

            return Math.Log10(number);
        }

        /// <summary>
        /// Calculates natural logarithm of a number
        /// </summary>
        /// <param name="number">Number to find natural logarithm of</param>
        /// <returns>Natural logarithm of the number</returns>
        /// <exception cref="ArgumentException">Thrown when number is not positive</exception>
        public double LogE(double number)
        {
            if (number <= 0)
                throw new ArgumentException("Natural logarithm is only defined for positive numbers");

            return Math.Log(number);
        }

        /// <summary>
        /// Calculates factorial of a non-negative integer
        /// </summary>
        /// <param name="number">Non-negative integer</param>
        /// <returns>Factorial of the number</returns>
        /// <exception cref="ArgumentException">Thrown when number is negative</exception>
        /// <exception cref="OverflowException">Thrown when factorial is too large</exception>
        public long Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Factorial is only defined for non-negative integers");

            if (number > 20)
                throw new OverflowException("Factorial too large to calculate (maximum supported: 20!)");

            if (number == 0 || number == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        #endregion

        #region Statistical Operations

        /// <summary>
        /// Calculates the mean (average) of a list of numbers
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <returns>Mean of the numbers</returns>
        /// <exception cref="ArgumentException">Thrown when list is empty</exception>
        public double Mean(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Cannot calculate mean of empty list");

            return numbers.Average();
        }

        /// <summary>
        /// Calculates the median of a list of numbers
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <returns>Median of the numbers</returns>
        /// <exception cref="ArgumentException">Thrown when list is empty</exception>
        public double Median(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Cannot calculate median of empty list");

            var sortedNumbers = numbers.OrderBy(x => x).ToList();
            int count = sortedNumbers.Count;

            if (count % 2 == 0)
            {
                // Even number of elements - average of two middle elements
                return (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2;
            }
            else
            {
                // Odd number of elements - middle element
                return sortedNumbers[count / 2];
            }
        }

        /// <summary>
        /// Calculates the mode(s) of a list of numbers
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <returns>List of mode values</returns>
        /// <exception cref="ArgumentException">Thrown when list is empty</exception>
        public List<double> Mode(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Cannot calculate mode of empty list");

            var frequency = numbers.GroupBy(x => x)
                                  .GroupBy(g => g.Count(), g => g.Key)
                                  .OrderByDescending(x => x.Key)
                                  .First();

            return frequency.ToList();
        }

        /// <summary>
        /// Calculates the standard deviation of a list of numbers
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <returns>Standard deviation of the numbers</returns>
        /// <exception cref="ArgumentException">Thrown when list is empty</exception>
        public double StandardDeviation(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Cannot calculate standard deviation of empty list");

            if (numbers.Count == 1)
                return 0;

            double mean = Mean(numbers);
            double sumOfSquaredDifferences = numbers.Sum(x => Math.Pow(x - mean, 2));

            return Math.Sqrt(sumOfSquaredDifferences / (numbers.Count - 1));
        }

        #endregion
    }
}