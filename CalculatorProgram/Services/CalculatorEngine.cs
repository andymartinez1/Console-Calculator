using Newtonsoft.Json;
using Spectre.Console;

namespace CalculatorLibrary;

public class CalculatorEngine
{
    private readonly JsonWriter writer;

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
