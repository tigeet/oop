using Shops.Exceptions;

namespace Shops.Models;
public class Purchase
{
    public Purchase(Product product, int amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException();
        Product = product;
        Amount = amount;
    }

    public Product Product { get; }
    public int Amount { get; }
}
