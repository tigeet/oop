using Shops.Exceptions;

namespace Shops.Models;
public class ShopProduct
{
    public ShopProduct(Product product)
    {
        Product = product;
        Count = 0;
        Price = 0m;
    }

    public Product Product { get; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public void IncreaseCount(int amount)
    {
        if (amount < 0)
            throw new InvalidAmountException();
        Count += amount;
    }

    public void DecreaseCount(int amount)
    {
        if (amount < 0)
            throw new InvalidAmountException();

        if (Count - amount < 0)
            throw new InvalidAmountException();

        Count -= amount;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new InvalidPriceException();

        Price = newPrice;
    }
}
