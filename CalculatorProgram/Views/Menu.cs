using CalculatorLibrary;
using Spectre.Console;

namespace CalculatorProgram;

public class Menu
{
    internal void ShowMenu()
    {
        var isGameOn = true;

        var calculator = new CalculatorEngine();

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
                    CalculatorEngine.AddOperation();
                    break;
                case "Subtract Numbers":
                    AnsiConsole.Clear();
                    CalculatorEngine.SubtractOperation();
                    break;
                case "Multiply Numbers":
                    AnsiConsole.Clear();
                    CalculatorEngine.MultiplyOperation();
                    break;
                case "Divide Numbers":
                    AnsiConsole.Clear();
                    CalculatorEngine.DivideOperation();
                    break;
                case "Exponentiate Numbers":
                    AnsiConsole.Clear();
                    CalculatorEngine.ExponentiateOperation();
                    break;
                case "Square Root":
                    AnsiConsole.Clear();
                    CalculatorEngine.SquareRootOperation();
                    break;
                case "Sine":
                    AnsiConsole.Clear();
                    CalculatorEngine.SineOperation();
                    break;
                case "Cosine":
                    AnsiConsole.Clear();
                    CalculatorEngine.CosineOperation();
                    break;
                case "Tangent":
                    AnsiConsole.Clear();
                    CalculatorEngine.TangentOperation();
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