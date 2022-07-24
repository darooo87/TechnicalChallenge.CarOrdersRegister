using TechnicalChallenge.CarOrdersRegister.Interfaces;
using TechnicalChallenge.CarOrdersRegister.Model;

namespace TechnicalChallenge.CarOrdersRegister.Data;

public class RepairOrderService : IRepairOrderService, IOrderService
{
    public ICustomerOrderResponse ProcessOrder(ICustomerOrder order)
    {
        if (order == null)
            throw new ArgumentNullException("");

        if (order.OrderType != OrderType.Repair)
            throw new ArgumentException($"Order type {order.OrderType} is invalid for this service");

        if (order.IsNewCustomer && order.IsLargeOrder)
            return new RepairCustomerOrderResponse
            {
                OrderStatus = OrderStatus.Closed
            };

        if (order.IsLargeOrder)
            return new RepairCustomerOrderResponse
            {
                OrderStatus = OrderStatus.AuthorisationRequired
            };

        if (order.IsRushOrder && order.IsNewCustomer)
            return new RepairCustomerOrderResponse
            {
                OrderStatus = OrderStatus.AuthorisationRequired
            };

        return new RepairCustomerOrderResponse
        {
            OrderStatus = OrderStatus.Confirmed
        };
    }
}
