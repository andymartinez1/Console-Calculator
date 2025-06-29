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

    internal static double BasicOperations(OperationType operationType)
    {
        Operation operation = new Operation(operationType);

        var twoNumbers = Helpers.GetTwoNumbers();
        operation.Operand1 = twoNumbers[0];
        operation.Operand2 = twoNumbers[1];

        if (operationType == OperationType.Addition)
        {
            operation.Result = (double)(operation.Operand1 + operation.Operand2);
            Helpers.PrintTwoNumberCalculation(
                operation.Operand1,
                (double)operation.Operand2,
                "+",
                operation.Result
            );
            Helpers.AddToCalculationList(
                $"{operation.Operand1} + {operation.Operand2} = {operation.Result}"
            );
        }
        else if (operationType == OperationType.Subtraction)
        {
            operation.Result = (double)(operation.Operand1 - operation.Operand2);
            Helpers.PrintTwoNumberCalculation(
                operation.Operand1,
                (double)operation.Operand2,
                "-",
                operation.Result
            );
            Helpers.AddToCalculationList(
                $"{operation.Operand1} - {operation.Operand2} = {operation.Result}"
            );
        }
        else if (operationType == OperationType.Multiplication)
        {
            operation.Result = (double)(operation.Operand1 * operation.Operand2);
            Helpers.PrintTwoNumberCalculation(
                operation.Operand1,
                (double)operation.Operand2,
                "*",
                operation.Result
            );
            Helpers.AddToCalculationList(
                $"{operation.Operand1} * {operation.Operand2} = {operation.Result}"
            );
        }
        else if (operationType == OperationType.Division)
        {
            operation.Result = (double)(operation.Operand1 / operation.Operand2);
            Helpers.PrintTwoNumberCalculation(
                operation.Operand1,
                (double)operation.Operand2,
                "/",
                operation.Result
            );
            Helpers.AddToCalculationList(
                $"{operation.Operand1} / {operation.Operand2} = {operation.Result}"
            );
        }
        else if (operationType == OperationType.Exponentiation)
        {
            operation.Result = Math.Pow(operation.Operand1, (double)operation.Operand2);
            Helpers.PrintTwoNumberCalculation(
                operation.Operand1,
                (double)operation.Operand2,
                "^",
                operation.Result
            );
            Helpers.AddToCalculationList(
                $"{operation.Operand1} ^ {operation.Operand2} = {operation.Result}"
            );
        }

        return operation.Result;
    }

    internal static double AdvancedOperations(OperationType operationType)
    {
        Operation operation = new Operation(operationType);

        operation.Operand1 = Helpers.GetSingleNumber();

        if (operationType == OperationType.SquareRoot)
        {
            if (operation.Operand1 < 0)
            {
                AnsiConsole.WriteLine(
                    "Cannot calculate the square root of a negative number. Please try again."
                );
                operation.Operand1 = Helpers.GetSingleNumber();
            }
            operation.Result = Math.Sqrt(operation.Operand1);
            Helpers.PrintSingleNumberCalculation(operation.Operand1, "√", operation.Result);
            Helpers.AddToCalculationList($"√{operation.Operand1} = {operation.Result}");
        }
        else if (operationType == OperationType.Sine)
        {
            operation.Result = Math.Sin(operation.Operand1);
            Helpers.PrintSingleNumberCalculation(operation.Operand1, "sin", operation.Result);
            Helpers.AddToCalculationList($"sin({operation.Operand1}) = {operation.Result}");
        }
        else if (operationType == OperationType.Cosine)
        {
            operation.Result = Math.Cos(operation.Operand1);
            Helpers.PrintSingleNumberCalculation(operation.Operand1, "cos", operation.Result);
            Helpers.AddToCalculationList($"cos({operation.Operand1}) = {operation.Result}");
        }
        else if (operationType == OperationType.Tangent)
        {
            operation.Result = Math.Tan(operation.Operand1);
            Helpers.PrintSingleNumberCalculation(operation.Operand1, "tan", operation.Result);
            Helpers.AddToCalculationList($"tan({operation.Operand1}) = {operation.Result}");
        }

        return operation.Result;
    }

    // Closes the JSON object and array and outputs the log file to bin/debug.
    public void Finish()
    {
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }
}
