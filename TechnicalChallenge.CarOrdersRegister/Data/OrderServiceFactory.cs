using TechnicalChallenge.CarOrdersRegister.Interfaces;
using TechnicalChallenge.CarOrdersRegister.Model;

namespace TechnicalChallenge.CarOrdersRegister.Data;

public class OrderServiceFactory : IOrderServiceFactory
{
    IOrderService _hireService;

    IOrderService _repairService;

    public OrderServiceFactory(IHireOrderService hireService, IRepairOrderService repairService)
    {
        _hireService = hireService;
        _repairService = repairService;
    }

    public IOrderService GetService(ICustomerOrder order)
    {
        if (order == null)
            throw new ArgumentNullException();

        if (order.OrderType == OrderType.Hire)
            return _hireService;

        if(order.OrderType == OrderType.Repair)
            return _repairService;

        throw new NotImplementedException("This type of order is not implemented");
    }
}
