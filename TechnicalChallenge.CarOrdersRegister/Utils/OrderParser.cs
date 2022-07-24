using TechnicalChallenge.CarOrdersRegister.Interfaces;
using TechnicalChallenge.CarOrdersRegister.Model;

namespace TechnicalChallenge.CarOrdersRegister.Utils;

public class OrderParser : IOrderParser
{
    public ICustomerOrder ParseOrder(IList<string>? orderArray)
    {
        if (orderArray == null)
            throw new ArgumentNullException(nameof(orderArray));

        try
        {
            return new CustomerOrder
            {
                OrderType = Enum.Parse<OrderType>(orderArray[0]),
                IsRushOrder = bool.Parse(orderArray[1]),
                IsNewCustomer = bool.Parse(orderArray[2]),
                IsLargeOrder = bool.Parse(orderArray[3]),
            };
        }
        catch
        {
            throw new ArgumentException($"Couldn't parse this order. ({string.Join(", ", orderArray)})");
        }
    }
}
