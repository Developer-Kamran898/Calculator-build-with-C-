using System;
using System.Collections.Generic;
using System.Linq;

namespace EnhancedCalculator
{
    /// <summary>
    /// Manages calculation history for the calculator
    /// </summary>
    public class History
    {
        private readonly List<string> _calculations;
        private const int MAX_HISTORY_SIZE = 50;

        /// <summary>
        /// Initializes a new instance of the History class
        /// </summary>
        public History()
        {
            _calculations = new List<string>();
        }

        /// <summary>
        /// Adds a calculation to the history
        /// </summary>
        /// <param name="calculation">The calculation string to add</param>
        public void AddCalculation(string calculation)
        {
            if (string.IsNullOrWhiteSpace(calculation))
                return;

            _calculations.Add($"{DateTime.Now:HH:mm:ss} - {calculation}");

            // Keep only the last MAX_HISTORY_SIZE calculations
            if (_calculations.Count > MAX_HISTORY_SIZE)
            {
                _calculations.RemoveAt(0);
            }
        }

        /// <summary>
        /// Gets the complete calculation history
        /// </summary>
        /// <returns>List of calculation strings</returns>
        public List<string> GetHistory()
        {
            return new List<string>(_calculations);
        }

        /// <summary>
        /// Gets the last N calculations from history
        /// </summary>
        /// <param name="count">Number of calculations to retrieve</param>
        /// <returns>List of the last N calculations</returns>
        public List<string> GetLastCalculations(int count)
        {
            if (count <= 0)
                return new List<string>();

            return _calculations.TakeLast(count).ToList();
        }

        /// <summary>
        /// Clears all calculations from history
        /// </summary>
        public void Clear()
        {
            _calculations.Clear();
        }

        /// <summary>
        /// Gets the number of calculations in history
        /// </summary>
        /// <returns>Number of calculations</returns>
        public int Count => _calculations.Count;

        /// <summary>
        /// Checks if history is empty
        /// </summary>
        /// <returns>True if history is empty, false otherwise</returns>
        public bool IsEmpty => _calculations.Count == 0;
    }
}