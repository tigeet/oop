using Shops.Exceptions;

namespace Shops.Models;
public class Supply
{
    private int id;
    private int count;
    private decimal price;

    public Supply(int id, int count, decimal price)
    {
        if (count < 0)
            throw new InvalidAmountException();

        if (price < 0)
            throw new InvalidPriceException();

        this.id = id;
        this.count = count;
        this.price = price;
    }

    public int GetCount()
    {
        return count;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public int GetId() { return id; }
}
