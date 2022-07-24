using TechnicalChallenge.CarOrdersRegister.Interfaces;

namespace TechnicalChallenge.CarOrdersRegister.Model;

public class CustomerOrder : ICustomerOrder
{
    public bool IsRushOrder { get; set; }

    public OrderType OrderType { get; set; }

    public bool IsNewCustomer { get; set; }

    public bool IsLargeOrder { get; set; }
}
