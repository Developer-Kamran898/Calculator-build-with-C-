# Enhanced C# Calculator

A comprehensive console-based calculator application built in C# that demonstrates advanced programming concepts, clean architecture, and professional software development practices.

## 🚀 Features

### Basic Operations
- **Addition (+)** - Add two numbers
- **Subtraction (-)** - Subtract two numbers  
- **Multiplication (*)** - Multiply two numbers
- **Division (/)** - Divide two numbers with zero-division protection
- **Power (^)** - Raise a number to a power
- **Square Root (√)** - Calculate square root of positive numbers
- **Percentage (%)** - Calculate percentage of a value

### Scientific Operations
- **Trigonometric Functions** - Sine, Cosine, Tangent (in radians)
- **Logarithmic Functions** - Log₁₀ and Natural Logarithm (ln)
- **Factorial (!)** - Calculate factorial of non-negative integers (up to 20!)
- **Scientific Mode Toggle** - Switch between basic and scientific modes

### Statistical Operations
- **Mean (Average)** - Calculate arithmetic mean of multiple numbers
- **Median** - Find the middle value in a sorted list
- **Mode** - Find the most frequently occurring value(s)
- **Standard Deviation** - Calculate population standard deviation

### Memory Functions
- **Memory Store (MS)** - Store a value in memory
- **Memory Recall (MR)** - Recall stored value
- **Memory Add (M+)** - Add to memory value
- **Memory Subtract (M-)** - Subtract from memory value
- **Memory Clear (MC)** - Clear memory

### History Management
- **Calculation History** - Automatically tracks last 50 calculations with timestamps
- **View History** - Display all previous calculations
- **Clear History** - Remove all calculation history

### User Experience
- **Input Validation** - Comprehensive error handling for invalid inputs
- **Flexible Input** - Accept both numbers and command shortcuts
- **Help System** - Built-in help with usage instructions
- **Clean Interface** - Organized menu system with clear navigation

## 🏗️ Architecture

### Clean Code Principles
- **Separation of Concerns** - UI, Business Logic, and Data layers are separated
- **Single Responsibility** - Each class has a single, well-defined purpose
- **Proper Error Handling** - Custom exceptions and validation throughout
- **Comprehensive Documentation** - XML documentation for all public methods

### Project Structure
```
EnhancedCalculator/
├── Program.cs           # Application entry point
├── CalculatorUI.cs      # User interface and interaction logic
├── Operations.cs        # Mathematical operations and calculations
├── History.cs           # Calculation history management
├── Memory.cs            # Memory operations functionality
├── Tests.cs             # Comprehensive unit tests
└── README.md           # Project documentation
```

## 🔧 Technical Highlights

### Error Handling
- **Division by Zero Protection** - Prevents crashes with proper exception handling
- **Input Validation** - Validates all user inputs with helpful error messages
- **Domain-Specific Exceptions** - Custom exceptions for mathematical constraints
- **Graceful Degradation** - Application continues running even after errors

### Advanced Features
- **Floating Point Precision** - Uses double precision for accurate calculations
- **Overflow Protection** - Prevents integer overflow in factorial calculations
- **Memory Management** - Efficient memory usage with proper cleanup
- **Extensible Design** - Easy to add new operations and features

### Testing
- **Unit Tests** - Comprehensive test coverage for all mathematical operations
- **Edge Case Testing** - Tests for boundary conditions and error scenarios
- **Test-Driven Development** - Tests validate expected behavior and constraints

## 📋 Usage Examples

### Basic Calculation
```
Enter your choice: 1
Enter first number: 15.5
Enter second number: 4.3
Addition Result: 19.800000
```

### Scientific Mode
```
Enter your choice: s
Scientific mode enabled.

Enter your choice: sin
Enter number: 1.5708
Sine Result: 1.000000
```

### Statistical Analysis
```
Enter your choice: stats
Choose statistical operation: 1
Enter numbers (press Enter without input to finish):
Number 1: 10
Number 2: 20
Number 3: 30
Number 4: 40
Number 5: 50

Mean: 30.000000
```

### Memory Operations
```
Enter your choice: m
Choose memory operation: 1
Enter value to store: 42.5
Value 42.500000 stored in memory.

Enter your choice: m
Choose memory operation: 2
Memory value: 42.500000
```

## 🚦 Getting Started

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or VS Code (optional)
- MSTest framework for running tests

### Installation
1. Clone the repository
```bash
git clone https://github.com/yourusername/enhanced-calculator.git
cd enhanced-calculator
```

2. Build the project
```bash
dotnet build
```

3. Run the application
```bash
dotnet run
```

4. Run tests (optional)
```bash
dotnet test
```

## 🎯 Commands Reference

### Quick Commands
- `+` or `1` - Addition
- `-` or `2` - Subtraction  
- `*` or `3` - Multiplication
- `/` or `4` - Division
- `^` or `5` - Power
- `√` or `sqrt` or `6` - Square Root
- `%` or `7` - Percentage
- `h` or `history` - View History
- `c` or `clear` - Clear History
- `m` or `memory` - Memory Operations
- `s` or `scientific` - Toggle Scientific Mode
- `stats` - Statistical Operations
- `help` - Show Help
- `exit` or `quit` - Exit Program

### Scientific Mode Commands
- `sin` - Sine function
- `cos` - Cosine function  
- `tan` - Tangent function
- `log` - Logarithm base 10
- `ln` - Natural logarithm
- `!` - Factorial

## 🧪 Testing

The project includes comprehensive unit tests covering:
- All mathematical operations
- Edge cases and error conditions
- Memory functionality
- History management
- Statistical calculations

Run tests with:
```bash
dotnet test --verbosity normal
```

## 🔮 Future Enhancements

- **Expression Parser** - Support for complex mathematical expressions
- **Graphing Calculator** - Visual representation of functions
- **Currency Converter** - Real-time currency conversion
- **Unit Converter** - Length, weight, temperature conversions
- **Equation Solver** - Linear and quadratic equation solving
- **Matrix Operations** - Basic matrix calculations
- **Number Base Converter** - Binary, hexadecimal, octal conversions

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 📞 Contact

Your Name - your.email@example.com

Project Link: https://github.com/yourusername/enhanced-calculator

---

⭐ If you found this project helpful, please give it a star on GitHub!
