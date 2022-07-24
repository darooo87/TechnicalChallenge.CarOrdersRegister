using TechnicalChallenge.CarOrdersRegister.Interfaces;

namespace TechnicalChallenge.CarOrdersRegister.Model;

public class RepairCustomerOrderResponse : ICustomerOrderResponse
{
    public OrderStatus OrderStatus { get; set; }
}
