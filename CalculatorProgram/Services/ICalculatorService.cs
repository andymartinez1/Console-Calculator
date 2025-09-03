using Calculator.Models;

namespace Calculator.Services;

public interface ICalculatorService
{
    public void BasicOperations(OperationType operationType);

    public void AdvancedOperations(OperationType operationType);
}
