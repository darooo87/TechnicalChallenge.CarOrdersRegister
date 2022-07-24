namespace TechnicalChallenge.CarOrdersRegister.Interfaces;

public interface IOrderService
{
    ICustomerOrderResponse ProcessOrder(ICustomerOrder order);
}
