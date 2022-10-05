namespace Shops.Models;
public class Supply
{
    private ProductInfo productInfo;
    private int count;
    private decimal price;

    public Supply(ProductInfo productInfo, int count, decimal price)
    {
        this.productInfo = productInfo;
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

    public ProductInfo GetProductInfo()
    {
        return productInfo;
    }
}
