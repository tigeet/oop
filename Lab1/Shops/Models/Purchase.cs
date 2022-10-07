using Shops.Exceptions;

namespace Shops.Models;
public class Purchase
{
    private int id;
    private int amount;

    public Purchase(int id, int amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException();
        this.id = id;
        this.amount = amount;
    }

    public int GetAmount() { return amount; }

    public int GetId() { return id; }
}
