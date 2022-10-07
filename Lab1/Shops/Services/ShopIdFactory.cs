namespace Shops.Services;

public class ShopIdFactory
{
    private int nextId = 0;
    public ShopIdFactory() { }
    public int GetNextId()
    {
        return nextId++;
    }
}
