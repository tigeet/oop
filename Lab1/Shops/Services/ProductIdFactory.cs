namespace Shops.Services;

public class ProductIdFactory
{
    private int nextId = 0;
    public ProductIdFactory() { }
    public int GetNextId()
    {
        return nextId++;
    }
}
