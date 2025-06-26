using Newtonsoft.Json;
using Spectre.Console;

namespace CalculatorLibrary;

public class Helpers
{
    public static List<string> calculationList = new();

    public static void PrintTwoNumberCalculation(
        double num1,
        double num2,
        string operationType,
        double result
    )
    {
        Console.WriteLine($"\t The result of {num1} {operationType} {num2} is {result}\n");
    }

    public static void PrintSingleNumberCalculation(double num, string operationType, double result)
    {
        Console.WriteLine($"\t The result of {operationType} {num} is {result}\n");
    }

    public static string AddToCalculationList(string calculation)
    {
        calculationList.Add(calculation);
        return calculation;
    }

    // public static double GetPreviousResult()
    // {
    //     var previousResults = calculationList;
    //     var resultsArray = previousResults.Select(x => double.Parse(x)).ToArray();
    //
    //     var userChoice = AnsiConsole.Prompt(
    //         new SelectionPrompt<string>()
    //             .Title("Please select a calculation to use as input:")
    //             .AddChoices(resultsArray)
    //     );
    //
    //     return userChoice;
    // }

    public static void PrintCalculationList()
    {
        Console.Clear();
        if (calculationList.Count == 0)
        {
            Console.WriteLine("No calculations have been performed yet.");
            return;
        }

        Console.WriteLine("----------------------------------------------------\n");
        Console.WriteLine("\t Calculation History:\n");
        foreach (var calculation in calculationList)
            Console.WriteLine($"\t {calculation}");

        DeleteCalculationList();
    }

    public static void DeleteCalculationList()
    {
        Console.WriteLine("\n----------------------------------------------------\n");
        Console.WriteLine("Would you like to clear the history? (y/n)");
        var clearHistory = Console.ReadLine()?.Trim().ToLower();
        if (clearHistory == "y")
        {
            calculationList.Clear();
            Console.WriteLine("Calculation history cleared.");
        }
        else if (clearHistory == "n")
        {
            Console.WriteLine("Calculation history retained.");
        }
        else
        {
            Console.WriteLine("Invalid input. Calculation history retained.");
        }
    }

    public static double[] GetTwoNumbers()
    {
        var input1 = "";
        var input2 = "";
        var result = new double[2];

        Console.WriteLine("Enter your first number: ");
        input1 = Console.ReadLine();

        double cleanNum1 = 0;
        while (!double.TryParse(input1, out cleanNum1))
        {
            Console.Write("Invalid input. Please enter a numeric value: ");
            input1 = Console.ReadLine();
        }

        Console.WriteLine("Enter your second number: ");
        input2 = Console.ReadLine();

        double cleanNum2 = 0;
        while (!double.TryParse(input2, out cleanNum2))
        {
            Console.Write("Invalid input. Please enter a numeric value: ");
            input2 = Console.ReadLine();
        }

        result[0] = cleanNum1;
        result[1] = cleanNum2;
        return result;
    }

    public static double GetSingleNumber()
    {
        var input = "";
        double cleanNum = 0;

        Console.WriteLine("Enter your number: ");
        input = Console.ReadLine();

        while (!double.TryParse(input, out cleanNum))
        {
            Console.Write("Invalid input. Please enter a numeric value: ");
            input = Console.ReadLine();
        }

        return cleanNum;
    }
}
