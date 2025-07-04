using System;
using System.Collections.Generic;
using System.Linq;

namespace EnhancedCalculator
{
    public class CalculatorUI
    {
        private readonly Operations _operations;
        private readonly History _history;
        private readonly Memory _memory;
        private bool _isRunning;
        private bool _isScientificMode;

        public CalculatorUI()
        {
            _operations = new Operations();
            _history = new History();
            _memory = new Memory();
            _isRunning = true;
            _isScientificMode = false;
        }

        public void Run()
        {
            Console.WriteLine("=== Welcome to Enhanced C# Calculator ===");
            Console.WriteLine("Type 'help' for available commands");

            while (_isRunning)
            {
                try
                {
                    DisplayMenu();
                    string input = Console.ReadLine()?.ToLower().Trim();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Please enter a valid option.");
                        continue;
                    }

                    ProcessInput(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                if (_isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine($"\n=== Calculator Menu ({(_isScientificMode ? "Scientific" : "Basic")} Mode) ===");
            Console.WriteLine("Basic Operations:");
            Console.WriteLine("1) Add (+)");
            Console.WriteLine("2) Subtract (-)");
            Console.WriteLine("3) Multiply (*)");
            Console.WriteLine("4) Divide (/)");
            Console.WriteLine("5) Power (^)");
            Console.WriteLine("6) Square Root (√)");
            Console.WriteLine("7) Percentage (%)");

            if (_isScientificMode)
            {
                Console.WriteLine("\nScientific Operations:");
                Console.WriteLine("8) Sine (sin)");
                Console.WriteLine("9) Cosine (cos)");
                Console.WriteLine("10) Tangent (tan)");
                Console.WriteLine("11) Logarithm (log)");
                Console.WriteLine("12) Natural Log (ln)");
                Console.WriteLine("13) Factorial (!)");
            }

            Console.WriteLine("\nUtility Functions:");
            Console.WriteLine("h) View History");
            Console.WriteLine("c) Clear History");
            Console.WriteLine("m) Memory Functions");
            Console.WriteLine("s) Toggle Scientific Mode");
            Console.WriteLine("stats) Statistical Functions");
            Console.WriteLine("help) Show Help");
            Console.WriteLine("exit) Exit Program");

            Console.Write("\nEnter your choice: ");
        }

        private void ProcessInput(string input)
        {
            switch (input)
            {
                case "1":
                case "+":
                    PerformTwoNumberOperation("Addition", _operations.Add);
                    break;
                case "2":
                case "-":
                    PerformTwoNumberOperation("Subtraction", _operations.Subtract);
                    break;
                case "3":
                case "*":
                    PerformTwoNumberOperation("Multiplication", _operations.Multiply);
                    break;
                case "4":
                case "/":
                    PerformTwoNumberOperation("Division", _operations.Divide);
                    break;
                case "5":
                case "^":
                    PerformTwoNumberOperation("Power", _operations.Power);
                    break;
                case "6":
                case "√":
                case "sqrt":
                    PerformSingleNumberOperation("Square Root", _operations.SquareRoot);
                    break;
                case "7":
                case "%":
                    PerformPercentageOperation();
                    break;
                case "8":
                case "sin":
                    if (_isScientificMode) PerformSingleNumberOperation("Sine", _operations.Sine);
                    else Console.WriteLine("Enable Scientific Mode to use this function.");
                    break;
                case "9":
                case "cos":
                    if (_isScientificMode) PerformSingleNumberOperation("Cosine", _operations.Cosine);
                    else Console.WriteLine("Enable Scientific Mode to use this function.");
                    break;
                case "10":
                case "tan":
                    if (_isScientificMode) PerformSingleNumberOperation("Tangent", _operations.Tangent);
                    else Console.WriteLine("Enable Scientific Mode to use this function.");
                    break;
                case "11":
                case "log":
                    if (_isScientificMode) PerformSingleNumberOperation("Logarithm (base 10)", _operations.Log10);
                    else Console.WriteLine("Enable Scientific Mode to use this function.");
                    break;
                case "12":
                case "ln":
                    if (_isScientificMode) PerformSingleNumberOperation("Natural Logarithm", _operations.LogE);
                    else Console.WriteLine("Enable Scientific Mode to use this function.");
                    break;
                case "13":
                case "!":
                    if (_isScientificMode) PerformFactorialOperation();
                    else Console.WriteLine("Enable Scientific Mode to use this function.");
                    break;
                case "h":
                case "history":
                    ShowHistory();
                    break;
                case "c":
                case "clear":
                    ClearHistory();
                    break;
                case "m":
                case "memory":
                    HandleMemoryOperations();
                    break;
                case "s":
                case "scientific":
                    ToggleScientificMode();
                    break;
                case "stats":
                    HandleStatisticalOperations();
                    break;
                case "help":
                    ShowHelp();
                    break;
                case "exit":
                case "quit":
                    _isRunning = false;
                    Console.WriteLine("Thank you for using the Enhanced Calculator!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Type 'help' for available commands.");
                    break;
            }
        }

        private void PerformTwoNumberOperation(string operationName, Func<double, double, double> operation)
        {
            try
            {
                double num1 = GetNumberInput("Enter first number: ");
                double num2 = GetNumberInput("Enter second number: ");

                double result = operation(num1, num2);
                string calculation = $"{num1} {GetOperationSymbol(operationName)} {num2} = {result:F6}";

                Console.WriteLine($"\n{operationName} Result: {result:F6}");
                _history.AddCalculation(calculation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing {operationName.ToLower()}: {ex.Message}");
            }
        }

        private void PerformSingleNumberOperation(string operationName, Func<double, double> operation)
        {
            try
            {
                double num = GetNumberInput("Enter number: ");

                double result = operation(num);
                string calculation = $"{operationName}({num}) = {result:F6}";

                Console.WriteLine($"\n{operationName} Result: {result:F6}");
                _history.AddCalculation(calculation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing {operationName.ToLower()}: {ex.Message}");
            }
        }

        private void PerformPercentageOperation()
        {
            try
            {
                double value = GetNumberInput("Enter the value: ");
                double percentage = GetNumberInput("Enter the percentage: ");

                double result = _operations.Percentage(value, percentage);
                string calculation = $"{percentage}% of {value} = {result:F6}";

                Console.WriteLine($"\nPercentage Result: {result:F6}");
                _history.AddCalculation(calculation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating percentage: {ex.Message}");
            }
        }

        private void PerformFactorialOperation()
        {
            try
            {
                Console.Write("Enter a non-negative integer: ");
                if (int.TryParse(Console.ReadLine(), out int num) && num >= 0)
                {
                    long result = _operations.Factorial(num);
                    string calculation = $"{num}! = {result}";

                    Console.WriteLine($"\nFactorial Result: {result}");
                    _history.AddCalculation(calculation);
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating factorial: {ex.Message}");
            }
        }

        private double GetNumberInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                Console.WriteLine("Please enter a valid number.");
            }
        }

        private string GetOperationSymbol(string operationName)
        {
            return operationName switch
            {
                "Addition" => "+",
                "Subtraction" => "-",
                "Multiplication" => "*",
                "Division" => "/",
                "Power" => "^",
                _ => ""
            };
        }

        private void ShowHistory()
        {
            var calculations = _history.GetHistory();
            if (calculations.Count == 0)
            {
                Console.WriteLine("No calculations in history.");
                return;
            }

            Console.WriteLine("\n=== Calculation History ===");
            for (int i = 0; i < calculations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {calculations[i]}");
            }
        }

        private void ClearHistory()
        {
            _history.Clear();
            Console.WriteLine("History cleared.");
        }

        private void HandleMemoryOperations()
        {
            Console.WriteLine("\n=== Memory Operations ===");
            Console.WriteLine("1) Memory Store (MS)");
            Console.WriteLine("2) Memory Recall (MR)");
            Console.WriteLine("3) Memory Add (M+)");
            Console.WriteLine("4) Memory Subtract (M-)");
            Console.WriteLine("5) Memory Clear (MC)");
            Console.Write("Choose memory operation: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    double value = GetNumberInput("Enter value to store: ");
                    _memory.Store(value);
                    Console.WriteLine($"Value {value:F6} stored in memory.");
                    break;
                case "2":
                    Console.WriteLine($"Memory value: {_memory.Recall():F6}");
                    break;
                case "3":
                    double addValue = GetNumberInput("Enter value to add to memory: ");
                    _memory.Add(addValue);
                    Console.WriteLine($"Added {addValue:F6} to memory. New value: {_memory.Recall():F6}");
                    break;
                case "4":
                    double subtractValue = GetNumberInput("Enter value to subtract from memory: ");
                    _memory.Subtract(subtractValue);
                    Console.WriteLine($"Subtracted {subtractValue:F6} from memory. New value: {_memory.Recall():F6}");
                    break;
                case "5":
                    _memory.Clear();
                    Console.WriteLine("Memory cleared.");
                    break;
                default:
                    Console.WriteLine("Invalid memory operation.");
                    break;
            }
        }

        private void HandleStatisticalOperations()
        {
            Console.WriteLine("\n=== Statistical Operations ===");
            Console.WriteLine("1) Mean (Average)");
            Console.WriteLine("2) Median");
            Console.WriteLine("3) Mode");
            Console.WriteLine("4) Standard Deviation");
            Console.Write("Choose statistical operation: ");

            string choice = Console.ReadLine();

            List<double> numbers = GetNumberList();
            if (numbers.Count == 0) return;

            switch (choice)
            {
                case "1":
                    double mean = _operations.Mean(numbers);
                    Console.WriteLine($"Mean: {mean:F6}");
                    _history.AddCalculation($"Mean of {numbers.Count} numbers = {mean:F6}");
                    break;
                case "2":
                    double median = _operations.Median(numbers);
                    Console.WriteLine($"Median: {median:F6}");
                    _history.AddCalculation($"Median of {numbers.Count} numbers = {median:F6}");
                    break;
                case "3":
                    var modes = _operations.Mode(numbers);
                    Console.WriteLine($"Mode: {string.Join(", ", modes.Select(m => m.ToString("F6")))}");
                    _history.AddCalculation($"Mode of {numbers.Count} numbers = {string.Join(", ", modes)}");
                    break;
                case "4":
                    double stdDev = _operations.StandardDeviation(numbers);
                    Console.WriteLine($"Standard Deviation: {stdDev:F6}");
                    _history.AddCalculation($"Standard Deviation of {numbers.Count} numbers = {stdDev:F6}");
                    break;
                default:
                    Console.WriteLine("Invalid statistical operation.");
                    break;
            }
        }

        private List<double> GetNumberList()
        {
            List<double> numbers = new List<double>();

            Console.WriteLine("Enter numbers (press Enter without input to finish):");
            int count = 1;

            while (true)
            {
                Console.Write($"Number {count}: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                if (double.TryParse(input, out double number))
                {
                    numbers.Add(number);
                    count++;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered.");
            }

            return numbers;
        }

        private void ToggleScientificMode()
        {
            _isScientificMode = !_isScientificMode;
            Console.WriteLine($"Scientific mode {(_isScientificMode ? "enabled" : "disabled")}.");
        }

        private void ShowHelp()
        {
            Console.WriteLine("\n=== Calculator Help ===");
            Console.WriteLine("Basic Operations: +, -, *, /, ^, √, %");
            Console.WriteLine("Scientific Functions: sin, cos, tan, log, ln, ! (factorial)");
            Console.WriteLine("Memory: Store, recall, add, subtract, clear values");
            Console.WriteLine("Statistics: Calculate mean, median, mode, standard deviation");
            Console.WriteLine("History: View and clear calculation history");
            Console.WriteLine("Scientific Mode: Toggle advanced mathematical functions");
            Console.WriteLine("\nTips:");
            Console.WriteLine("- Use decimal numbers for precise calculations");
            Console.WriteLine("- Memory operations persist throughout the session");
            Console.WriteLine("- History shows your last 50 calculations");
            Console.WriteLine("- Scientific functions work with radians");
        }
    }
}