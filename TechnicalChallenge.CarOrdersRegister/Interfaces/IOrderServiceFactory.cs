namespace TechnicalChallenge.CarOrdersRegister.Interfaces;

public interface IOrderServiceFactory
{
    IOrderService GetService(ICustomerOrder order);
}
