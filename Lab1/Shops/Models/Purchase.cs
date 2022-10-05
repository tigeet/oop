namespace Shops.Models;

public class Purchase
{
    private ProductInfo productInfo;
    private int amount;

    public Purchase(ProductInfo productInfo, int amount)
    {
        if (amount <= 0)
            throw new Exception(); // TODO: Invalid purchase amount

        this.productInfo = productInfo;
        this.amount = amount;
    }

    public int GetAmount() { return amount; }

    public ProductInfo GetProductInfo() { return productInfo; }
}
