using TechnicalChallenge.CarOrdersRegister.Interfaces;

namespace TechnicalChallenge.CarOrdersRegister.Model;

public class HireCustomerOrderResponse : ICustomerOrderResponse
{
    public OrderStatus OrderStatus { get; set; }
}
