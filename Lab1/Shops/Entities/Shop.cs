using Shops.Models;

namespace Shops.Entities;
public class Shop
{
    private Dictionary<ProductInfo, Product> products;
    private int id;
    private string name;
    private string address;

    public Shop(int id, string name, string address, params ProductInfo[] productInfos)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        products = new Dictionary<ProductInfo, Product>();

        RegisterProducts(productInfos);
    }

    public string GetName() { return name; }
    public string GetAddress() { return address; }
    public int GetId() { return id; }

    public void AddProducts(params Supply[] supplies)
    {
        foreach (Supply supply in supplies)
        {
            if (!products.ContainsKey(supply.GetProductInfo()))
                throw new Exception(); // TODO: Product not registered exception
        }

        foreach (Supply supply in supplies)
        {
            Product product = products[supply.GetProductInfo()];
            product.UpdatePrice(supply.GetPrice());
            product.IncreaseCount(supply.GetCount());
        }
    }

    public void RegisterProducts(params ProductInfo[] productInfos)
    {
        foreach (ProductInfo productInfo in productInfos)
        {
            if (products.ContainsKey(productInfo))
                throw new Exception("Product is already registered"); // TODO: Product is already registered
        }

        foreach (ProductInfo productInfo in productInfos)
        {
            var product = new Product(productInfo, 0, 0m);
            products[productInfo] = product;
        }
    }

    public void BuyProducts(Person person, params Purchase[] purchases)
    {
        decimal total = 0m;
        foreach (Purchase purchase in purchases)
        {
            ProductInfo productInfo = purchase.GetProductInfo();
            int amount = purchase.GetAmount();

            if (!products.ContainsKey(productInfo))
                throw new Exception("product not registered"); // TODO: Product not registered

            Product product = products[productInfo];

            if (product.GetCount() < amount)
                throw new Exception("Not enough products"); // TODO: Not enough products

            total += product.GetPrice() * amount;
        }

        if (total > person.GetMoney())
            throw new Exception("Not enough money"); // TODO: Not enough money

        foreach (Purchase purchase in purchases)
        {
            ProductInfo productInfo = purchase.GetProductInfo();
            Product product = products[productInfo];
            int amount = purchase.GetAmount();

            product.DecreaseCount(amount);
        }

        person.DecreaseMoney(total);
    }

    public Product GetProduct(ProductInfo productInfo)
    {
        if (!products.ContainsKey(productInfo))
            throw new Exception("Product does not exist"); // TODO: Product does not exist

        return products[productInfo];
    }

    public bool HasProduct(ProductInfo productInfo)
    {
        return products.ContainsKey(productInfo);
    }
}
