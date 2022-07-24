using TechnicalChallenge.CarOrdersRegister.Data;
using TechnicalChallenge.CarOrdersRegister.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TechnicalChallenge.CarOrdersRegister.Tests;

[TestClass]
public class OrderServiceFactoryTests
{
    IOrderServiceFactory _factory;

    IRepairOrderService _repairOrderService;

    IHireOrderService _hireOrderService;

    public OrderServiceFactoryTests()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IHireOrderService, HireOrderService>();
        services.AddSingleton<IRepairOrderService, RepairOrderService>();
        services.AddSingleton<IOrderServiceFactory, OrderServiceFactory>();

        var serviceProvider = services.BuildServiceProvider();

        var factory = serviceProvider.GetService<IOrderServiceFactory>();
        var hireOrderService = serviceProvider.GetService<IHireOrderService>();
        var repairOrderService = serviceProvider.GetService<IRepairOrderService>();

        if (factory == null || repairOrderService == null || hireOrderService == null)
            throw new Exception("Error when configuring OrderServiceTests");

        _factory = factory;
        _hireOrderService = hireOrderService;
        _repairOrderService = repairOrderService;
    }

    [TestMethod]
    public void GetServiceForNullOrder()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            _factory.GetService(null);
        });
    }

    [TestMethod]
    public void GetServiceForHireOrder()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Hire);

        var result = _factory.GetService(orderMock.Object);

        Assert.IsNotNull(result);
        Assert.IsTrue(result == _hireOrderService);
    }

    [TestMethod]
    public void GetServiceForRepairOrder()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Repair);

        var result = _factory.GetService(orderMock.Object);

        Assert.IsNotNull(result);
        Assert.IsTrue(result == _repairOrderService);
    }
}
