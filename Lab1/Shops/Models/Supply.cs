using Shops.Exceptions;

namespace Shops.Models;
public class Supply
{
    public Supply(Product product, int count, decimal price)
    {
        if (count < 0)
            throw new InvalidAmountException();

        if (price < 0)
            throw new InvalidPriceException();
        Product = product;
        Count = count;
        Price = price;
    }

    public Product Product { get; }
    public int Count { get; }
    public decimal Price { get; }
}
