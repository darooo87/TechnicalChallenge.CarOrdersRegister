using TechnicalChallenge.CarOrdersRegister.Data;
using TechnicalChallenge.CarOrdersRegister.Interfaces;
using TechnicalChallenge.CarOrdersRegister.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IOrderServiceFactory, OrderServiceFactory>();
        services.AddSingleton<IHireOrderService, HireOrderService>();
        services.AddSingleton<IRepairOrderService, RepairOrderService>();
        services.AddSingleton<IOrderParser, OrderParser>();
        services.AddSingleton<IApplicationInterface, ApplicationInterface>();
        services.AddTransient<Application>();
    })
    .Build();

host.Services.GetRequiredService<Application>().StartProgram();

class Application
{
    private readonly IApplicationInterface _applicationInterface;

    private readonly IOrderServiceFactory _orderServiceFactory;

    private readonly IOrderParser _parser;

    public Application(IOrderServiceFactory registry, IOrderParser orderParser, IApplicationInterface applicationInterface)
    {
        _orderServiceFactory = registry;
        _parser = orderParser;
        _applicationInterface = applicationInterface;
    }

    public void StartProgram()
    {
        while (true)
        {
            _applicationInterface.DisplayWelcomeMessage();

            var order = _parser.ParseOrder(_applicationInterface.GetOrderData());

            var response = _orderServiceFactory.GetService(order).ProcessOrder(order);

            _applicationInterface.DisplayResult(response);
        }
    }
}








