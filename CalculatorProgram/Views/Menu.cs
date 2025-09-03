using Calculator.Models;
using Calculator.Services;
using Spectre.Console;

namespace Calculator.Views;

public class Menu
{
    internal void ShowMenu()
    {
        var isGameOn = true;

        var calculator = new CalculatorService();

        AnsiConsole.Write(new FigletText("Calculator").Color(Color.Green));

        while (isGameOn)
        {
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select an operation:")
                    .AddChoices(
                        "View History",
                        "Add Numbers",
                        "Subtract Numbers",
                        "Multiply Numbers",
                        "Divide Numbers",
                        "Exponentiate Numbers",
                        "Square Root",
                        "Sine",
                        "Cosine",
                        "Tangent",
                        "Exit Program"
                    )
            );

            switch (userChoice)
            {
                case "View History":
                    AnsiConsole.Clear();
                    Helpers.PrintCalculationList();
                    break;
                case "Add Numbers":
                    AnsiConsole.Clear();
                    CalculatorService.BasicOperations(OperationType.Addition);
                    break;
                case "Subtract Numbers":
                    AnsiConsole.Clear();
                    CalculatorService.BasicOperations(OperationType.Subtraction);
                    break;
                case "Multiply Numbers":
                    AnsiConsole.Clear();
                    CalculatorService.BasicOperations(OperationType.Multiplication);
                    break;
                case "Divide Numbers":
                    AnsiConsole.Clear();
                    CalculatorService.BasicOperations(OperationType.Division);
                    break;
                case "Exponentiate Numbers":
                    AnsiConsole.Clear();
                    CalculatorService.BasicOperations(OperationType.Exponentiation);
                    break;
                case "Square Root":
                    AnsiConsole.Clear();
                    CalculatorService.AdvancedOperations(OperationType.SquareRoot);
                    break;
                case "Sine":
                    AnsiConsole.Clear();
                    CalculatorService.AdvancedOperations(OperationType.Sine);
                    break;
                case "Cosine":
                    AnsiConsole.Clear();
                    CalculatorService.AdvancedOperations(OperationType.Cosine);
                    break;
                case "Tangent":
                    AnsiConsole.Clear();
                    CalculatorService.AdvancedOperations(OperationType.Tangent);
                    break;
                case "Exit Program":
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine(
                        "[red]Thank you for using this calculator app! Press any key to exit. Goodbye![/]"
                    );
                    Console.ReadKey();
                    isGameOn = false;
                    break;
            }
        }

        calculator.Finish();
    }
}
