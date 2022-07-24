using TechnicalChallenge.CarOrdersRegister.Model;

namespace TechnicalChallenge.CarOrdersRegister.Interfaces;

public interface ICustomerOrder
{
    public bool IsRushOrder { get; set; }

    public OrderType OrderType { get; set; }

    public bool IsNewCustomer { get; set; }

    public bool IsLargeOrder { get; set; }
}
