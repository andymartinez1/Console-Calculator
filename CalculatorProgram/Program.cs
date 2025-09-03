using Calculator.Services;
using Calculator.Views;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddTransient<IMenu, Menu>();
serviceCollection.AddTransient<ICalculatorService, CalculatorService>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var menu = serviceProvider.GetRequiredService<IMenu>();

menu.ShowMenu();
