namespace TechnicalChallenge.CarOrdersRegister.Interfaces;

public interface IApplicationInterface
{
    public void DisplayWelcomeMessage();

    public IList<string>? GetOrderData();

    public void DisplayResult(ICustomerOrderResponse response);
}
