using TechnicalChallenge.CarOrdersRegister.Interfaces;
using TechnicalChallenge.CarOrdersRegister.Model;

namespace TechnicalChallenge.CarOrdersRegister.Data;

public class HireOrderService : IHireOrderService, IOrderService
{
    public ICustomerOrderResponse ProcessOrder(ICustomerOrder order)
    {
        if (order == null)
            throw new ArgumentNullException("");

        if (order.OrderType != OrderType.Hire)
            throw new ArgumentException($"Order type {order.OrderType} is invalid for this service");


        if (order.IsRushOrder && order.IsLargeOrder)
            return new HireCustomerOrderResponse
            {
                OrderStatus = OrderStatus.Closed
            };

        if (order.IsRushOrder && order.IsNewCustomer)
            return new HireCustomerOrderResponse
            {
                OrderStatus = OrderStatus.AuthorisationRequired
            };

        return new HireCustomerOrderResponse
        {
            OrderStatus = OrderStatus.Confirmed
        };
    }
}
