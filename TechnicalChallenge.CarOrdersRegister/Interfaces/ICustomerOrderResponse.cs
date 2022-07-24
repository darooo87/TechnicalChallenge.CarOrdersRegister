using TechnicalChallenge.CarOrdersRegister.Model;

namespace TechnicalChallenge.CarOrdersRegister.Interfaces;

public interface ICustomerOrderResponse
{
    public OrderStatus OrderStatus { get; set; }

    public string? ToString()
    {
        return $"{OrderStatus}";
    }
}
