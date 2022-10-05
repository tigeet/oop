namespace Shops.Models;

public class ProductInfo
{
    private string name;

    public ProductInfo(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}
