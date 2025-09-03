using Calculator.Models;
using Calculator.Services;
using Calculator.Utils;
using Spectre.Console;

namespace Calculator.Views;

public class Menu : IMenu
{
    private readonly ICalculatorService _calculatorService;

    public Menu(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    public void ShowMenu()
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
                    _calculatorService.BasicOperations(OperationType.Addition);
                    break;
                case "Subtract Numbers":
                    AnsiConsole.Clear();
                    _calculatorService.BasicOperations(OperationType.Subtraction);
                    break;
                case "Multiply Numbers":
                    AnsiConsole.Clear();
                    _calculatorService.BasicOperations(OperationType.Multiplication);
                    break;
                case "Divide Numbers":
                    AnsiConsole.Clear();
                    _calculatorService.BasicOperations(OperationType.Division);
                    break;
                case "Exponentiate Numbers":
                    AnsiConsole.Clear();
                    _calculatorService.BasicOperations(OperationType.Exponentiation);
                    break;
                case "Square Root":
                    AnsiConsole.Clear();
                    _calculatorService.AdvancedOperations(OperationType.SquareRoot);
                    break;
                case "Sine":
                    AnsiConsole.Clear();
                    _calculatorService.AdvancedOperations(OperationType.Sine);
                    break;
                case "Cosine":
                    AnsiConsole.Clear();
                    _calculatorService.AdvancedOperations(OperationType.Cosine);
                    break;
                case "Tangent":
                    AnsiConsole.Clear();
                    _calculatorService.AdvancedOperations(OperationType.Tangent);
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
