using TechnicalChallenge.CarOrdersRegister.Data;
using TechnicalChallenge.CarOrdersRegister.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TechnicalChallenge.CarOrdersRegister.Tests;

[TestClass]
public class OrderServiceTests
{
    IOrderServiceFactory _orderServiceFactory;

    public OrderServiceTests()
    {
        var services = new ServiceCollection();
        
        services.AddTransient<IHireOrderService, HireOrderService>();
        services.AddTransient<IRepairOrderService, RepairOrderService>();
        services.AddTransient<IOrderServiceFactory, OrderServiceFactory>();

        var serviceProvider = services.BuildServiceProvider();

        var orderServiceFactory = serviceProvider.GetService<IOrderServiceFactory>();

        if (orderServiceFactory == null)
            throw new Exception("Error when configuring OrderServiceTests");

        _orderServiceFactory = orderServiceFactory;
    }

    [TestMethod]
    public void ProcessLargeRepairForNewCustomer()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Repair);
        orderMock.Setup(s => s.IsRushOrder).Returns(false);
        orderMock.Setup(s => s.IsLargeOrder).Returns(true);
        orderMock.Setup(s => s.IsNewCustomer).Returns(true);

        var order = orderMock.Object;

        var service = _orderServiceFactory.GetService(order);

        Assert.IsNotNull(service);

        var result = service.ProcessOrder(order);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderStatus == Model.OrderStatus.Closed);
    }

    [TestMethod]
    public void ProcessLargeRushHire()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Hire);
        orderMock.Setup(s => s.IsRushOrder).Returns(true);
        orderMock.Setup(s => s.IsLargeOrder).Returns(true);
        orderMock.Setup(s => s.IsNewCustomer).Returns(false);

        var order = orderMock.Object;

        var service = _orderServiceFactory.GetService(order);

        Assert.IsNotNull(service);

        var result = service.ProcessOrder(order);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderStatus == Model.OrderStatus.Closed);
    }

    [TestMethod]
    public void ProcessLargeRepair()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Repair);
        orderMock.Setup(s => s.IsRushOrder).Returns(false);
        orderMock.Setup(s => s.IsLargeOrder).Returns(true);
        orderMock.Setup(s => s.IsNewCustomer).Returns(false);

        var order = orderMock.Object;

        var service = _orderServiceFactory.GetService(order);

        Assert.IsNotNull(service);

        var result = service.ProcessOrder(order);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderStatus == Model.OrderStatus.AuthorisationRequired);
    }

    [TestMethod]
    public void ProcessRushOrderForNewCustomer()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Repair);
        orderMock.Setup(s => s.IsRushOrder).Returns(true);
        orderMock.Setup(s => s.IsLargeOrder).Returns(false);
        orderMock.Setup(s => s.IsNewCustomer).Returns(true);

        var order = orderMock.Object;

        var service = _orderServiceFactory.GetService(order);

        Assert.IsNotNull(service);

        var result = service.ProcessOrder(order);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderStatus == Model.OrderStatus.AuthorisationRequired);
    }

    [TestMethod]
    public void ProcessStandardRepair()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Repair);
        orderMock.Setup(s => s.IsRushOrder).Returns(false);
        orderMock.Setup(s => s.IsLargeOrder).Returns(false);
        orderMock.Setup(s => s.IsNewCustomer).Returns(true);

        var order = orderMock.Object;

        var service = _orderServiceFactory.GetService(order);

        Assert.IsNotNull(service);

        var result = service.ProcessOrder(order);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderStatus == Model.OrderStatus.Confirmed);
    }

    [TestMethod]
    public void ProcessStandardHire()
    {
        var orderMock = new Mock<ICustomerOrder>();

        orderMock.Setup(s => s.OrderType).Returns(Model.OrderType.Hire);
        orderMock.Setup(s => s.IsRushOrder).Returns(false);
        orderMock.Setup(s => s.IsLargeOrder).Returns(false);
        orderMock.Setup(s => s.IsNewCustomer).Returns(true);

        var order = orderMock.Object;

        var service = _orderServiceFactory.GetService(order);

        Assert.IsNotNull(service);

        var result = service.ProcessOrder(order);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderStatus == Model.OrderStatus.Confirmed);
    }
}
