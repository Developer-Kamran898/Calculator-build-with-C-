using System;

namespace EnhancedCalculator
{
    /// <summary>
    /// Manages memory operations for the calculator
    /// </summary>
    public class Memory
    {
        private double _memoryValue;

        /// <summary>
        /// Initializes a new instance of the Memory class
        /// </summary>
        public Memory()
        {
            _memoryValue = 0;
        }

        /// <summary>
        /// Stores a value in memory
        /// </summary>
        /// <param name="value">Value to store</param>
        public void Store(double value)
        {
            _memoryValue = value;
        }

        /// <summary>
        /// Recalls the value from memory
        /// </summary>
        /// <returns>The value stored in memory</returns>
        public double Recall()
        {
            return _memoryValue;
        }

        /// <summary>
        /// Adds a value to the current memory value
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Add(double value)
        {
            _memoryValue += value;
        }

        /// <summary>
        /// Subtracts a value from the current memory value
        /// </summary>
        /// <param name="value">Value to subtract</param>
        public void Subtract(double value)
        {
            _memoryValue -= value;
        }

        /// <summary>
        /// Clears the memory (sets it to zero)
        /// </summary>
        public void Clear()
        {
            _memoryValue = 0;
        }

        /// <summary>
        /// Gets the current memory value
        /// </summary>
        /// <returns>Current memory value</returns>
        public double CurrentValue => _memoryValue;

        /// <summary>
        /// Checks if memory has a non-zero value
        /// </summary>
        /// <returns>True if memory contains a non-zero value, false otherwise</returns>
        public bool HasValue => Math.Abs(_memoryValue) > double.Epsilon;
    }
}