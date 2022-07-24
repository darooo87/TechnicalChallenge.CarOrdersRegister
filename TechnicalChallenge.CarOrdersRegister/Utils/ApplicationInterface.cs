using TechnicalChallenge.CarOrdersRegister.Interfaces;

namespace TechnicalChallenge.CarOrdersRegister.Utils;

public class ApplicationInterface : IApplicationInterface
{
    public void DisplayResult(ICustomerOrderResponse response)
    {
        Console.Clear();
        Console.WriteLine(response);
        Console.ReadLine();
    }

    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("Order register. Enter order details");
        Console.WriteLine("Type (Repair,Hire), IsRush (true, false), IsNewCustomer (true, false), IsLargeCustomer (true, false)");
        Console.WriteLine("Example: Hire true false true");
    }

    public IList<string>? GetOrderData()
    {
        return Console.ReadLine()?.Split(" ");
    }
}
