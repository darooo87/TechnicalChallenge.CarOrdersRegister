namespace TechnicalChallenge.CarOrdersRegister.Interfaces;

public interface IOrderParser
{
    ICustomerOrder ParseOrder(IList<string>? orderData);
}
