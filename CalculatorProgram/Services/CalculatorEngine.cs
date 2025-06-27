using CalculatorLibrary.Models;
using Newtonsoft.Json;
using Spectre.Console;

namespace CalculatorLibrary;

public class CalculatorEngine
{
    private readonly JsonWriter writer;
    internal static List<double> Results = new();

    public CalculatorEngine()
    {
        var logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
    }

    internal static double BasicOperations(Operation operation)
    {
        var twoNumbers = Helpers.GetTwoNumbers();
        operation.Operand1 = twoNumbers[0];
        operation.Operand2 = twoNumbers[1];
        if (operation.OperationType == OperationType.Addition)
        {
            operation.Result = (double)(operation.Operand1 + operation.Operand2);
        }
        else if (operation.OperationType == OperationType.Subtraction)
        {
            operation.Result = (double)(operation.Operand1 - operation.Operand2);
        }
        else if (operation.OperationType == OperationType.Multiplication)
        {
            operation.Result = (double)(operation.Operand1 * operation.Operand2);
        }
        else if (operation.OperationType == OperationType.Division)
        {
            operation.Result = (double)(operation.Operand1 / operation.Operand2);
        }
        else if (operation.OperationType == OperationType.Exponentiation)
        {
            operation.Result = Math.Pow(operation.Operand1,  (double)operation.Operand2);
        }

        return operation.Result;
    }

    internal static double AdvancedOperations(Operation operation)
    {
        if (operation.OperationType == OperationType.SquareRoot)
        {
            operation.Operand1 = Helpers.GetSingleNumber();
            if (operation.Operand1 < 0)
            {
                AnsiConsole.WriteLine("Cannot calculate the square root of a negative number. Please try again.");
                operation.Operand1 = Helpers.GetSingleNumber();
            }
            operation.Result = Math.Sqrt(operation.Operand1);
        }
        else if (operation.OperationType == OperationType.Sine)
        {
            operation.Operand1 = Helpers.GetSingleNumber();
            operation.Result = Math.Sin(operation.Operand1);
        }
        else if (operation.OperationType == OperationType.Cosine)
        {
            operation.Operand1 = Helpers.GetSingleNumber();
            operation.Result = Math.Cos(operation.Operand1);
        }
        else if (operation.OperationType == OperationType.Tangent)
        {
            operation.Operand1 = Helpers.GetSingleNumber();
            operation.Result = Math.Tan(operation.Operand1);
        }

        return operation.Result;
    }

    internal static double AddOperation()
    {
        var twoNumbers = Helpers.GetTwoNumbers();
        var num1 = twoNumbers[0];
        var num2 = twoNumbers[1];
        var result = num1 + num2;

        Helpers.PrintTwoNumberCalculation(num1, num2, "+", result);
        Helpers.AddToCalculationList($"{num1} + {num2} = {result}");

        return result;
    }

    internal static double SubtractOperation()
    {
        var twoNumbers = Helpers.GetTwoNumbers();
        var num1 = twoNumbers[0];
        var num2 = twoNumbers[1];
        var result = num1 - num2;

        Helpers.PrintTwoNumberCalculation(num1, num2, "-", result);
        Helpers.AddToCalculationList($"{num1} - {num2} = {result}");

        return result;
    }

    internal static double MultiplyOperation()
    {
        var twoNumbers = Helpers.GetTwoNumbers();
        var num1 = twoNumbers[0];
        var num2 = twoNumbers[1];
        var result = num1 * num2;

        Helpers.PrintTwoNumberCalculation(num1, num2, "*", result);
        Helpers.AddToCalculationList($"{num1} * {num2} = {result}");

        return result;
    }

    internal static double DivideOperation()
    {
        var twoNumbers = Helpers.GetTwoNumbers();
        var num1 = twoNumbers[0];
        var num2 = twoNumbers[1];

        if (num1 == 0 || num2 == 0)
        {
            AnsiConsole.WriteLine("Cannot divide by zero. Please try again.");
            twoNumbers = Helpers.GetTwoNumbers();
        }

        var result = num1 / num2;

        Helpers.PrintTwoNumberCalculation(num1, num2, "/", result);
        Helpers.AddToCalculationList($"{num1} / {num2} = {result}");

        return result;
    }

    internal static double ExponentiateOperation()
    {
        var twoNumbers = Helpers.GetTwoNumbers();
        var num1 = twoNumbers[0];
        var num2 = twoNumbers[1];
        var result = Math.Pow(num1, num2);

        Helpers.PrintTwoNumberCalculation(num1, num2, "^", result);
        Helpers.AddToCalculationList($"{num1} ^ {num2} = {result}");

        return result;
    }

    internal static double SquareRootOperation()
    {
        var num = Helpers.GetSingleNumber();

        if (num < 0)
        {
            AnsiConsole.WriteLine("Cannot calculate the square root of a negative number. Please try again.");
            num = Helpers.GetSingleNumber();
        }

        var result = Math.Sqrt(num);

        Helpers.PrintSingleNumberCalculation(num, "√", result);
        Helpers.AddToCalculationList($"√{num} = {result}");

        return result;
    }

    internal static double SineOperation()
    {
        var num = Helpers.GetSingleNumber();
        var result = Math.Sin(num);

        Helpers.PrintSingleNumberCalculation(num, "sin", result);
        Helpers.AddToCalculationList($"sin({num}) = {result}");

        return result;
    }

    internal static double CosineOperation()
    {
        var num = Helpers.GetSingleNumber();
        var result = Math.Cos(num);

        Helpers.PrintSingleNumberCalculation(num, "cos", result);
        Helpers.AddToCalculationList($"cos({num}) = {result}");

        return result;
    }

    internal static double TangentOperation()
    {
        var num = Helpers.GetSingleNumber();
        var result = Math.Tan(num);

        Helpers.PrintSingleNumberCalculation(num, "tan", result);
        Helpers.AddToCalculationList($"tan({num}) = {result}");

        return result;
    }

    // Closes the JSON object and array and outputs the log file to bin/debug.
    public void Finish()
    {
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }
}