using Shops.Models;

namespace Shops.Entities;
public class Product
{
    private ProductInfo productInfo;
    private int count;
    private decimal price;
    public Product(ProductInfo productInfo, int count, decimal price)
    {
        this.productInfo = productInfo;
        this.count = count;
        this.price = price;
    }

    public void IncreaseCount(int amount)
    {
        // TODO: Check if amount > 0
        count += amount;
    }

    public void DecreaseCount(int amount)
    {
        // TODO: Check if amount > 0
        // TODO: Check if count - amount >= 0
        count -= amount;
    }

    public int GetCount()
    {
        return count;
    }

    public void UpdatePrice(decimal newPrice)
    {
        price = newPrice;
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
