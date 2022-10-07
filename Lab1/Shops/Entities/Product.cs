using Shops.Exceptions;
namespace Shops.Entities;
public class Product
{
    private int id;
    private int count;
    private decimal price;
    private string name;
    public Product(int id, string name)
    {
        this.id = id;
        this.name = name;
        count = 0;
        price = 0m;
    }

    public int GetId() { return id; }
    public void IncreaseCount(int amount)
    {
        if (amount < 0)
            throw new InvalidAmountException();
        count += amount;
    }

    public void DecreaseCount(int amount)
    {
        if (amount < 0)
            throw new InvalidAmountException();

        if (count - amount < 0)
            throw new InvalidAmountException();

        count -= amount;
    }

    public int GetCount()
    {
        return count;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new InvalidPriceException();

        price = newPrice;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public string GetName() { return name; }
}
