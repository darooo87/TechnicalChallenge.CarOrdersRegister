using TechnicalChallenge.CarOrdersRegister.Interfaces;
using TechnicalChallenge.CarOrdersRegister.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TechnicalChallenge.CarOrdersRegister.Tests;

[TestClass]
public class OrderParserTests
{
    IOrderParser _parser;

    public OrderParserTests()
    {
        _parser = new OrderParser();
    }

    [TestMethod]
    public void ParseNullOrder()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            _parser.ParseOrder(null);
        });
    }

    [TestMethod]
    public void ParseOrderWithLessArguments()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _parser.ParseOrder(new List<string> { "Hire", "true", "false" });
        });
    }

    [TestMethod]
    public void ParseOrderWithWrongOrderOfArguments()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _parser.ParseOrder(new List<string> { "true", "Hire", "true", "false" });
        });
    }

    [TestMethod]
    public void ParseCorrectOrder1()
    {
        var result = _parser.ParseOrder(new List<string> { "Hire", "true", "true", "true" });

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderType == Model.OrderType.Hire);
        Assert.IsTrue(result.IsRushOrder);
        Assert.IsTrue(result.IsLargeOrder);
        Assert.IsTrue(result.IsNewCustomer);
    }

    [TestMethod]
    public void ParseCorrectOrder2()
    {
        var result = _parser.ParseOrder(new List<string> { "Repair", "false", "false", "false" });

        Assert.IsNotNull(result);
        Assert.IsTrue(result.OrderType == Model.OrderType.Repair);
        Assert.IsFalse(result.IsRushOrder);
        Assert.IsFalse(result.IsLargeOrder);
        Assert.IsFalse(result.IsNewCustomer);
    }
}
