using Shops.Exceptions;
using Shops.Models;
namespace Shops.Entities;
public class Shop
{
    private Dictionary<Product, ShopProduct> products;
    public Shop(string name, string address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        products = new Dictionary<Product, ShopProduct>();
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Address { get; }

    public string GetName() { return Name; }
    public string GetAddress() { return Address; }
    public Guid GetId() { return Id; }

    public void AddProducts(params Supply[] supplies)
    {
        foreach (Supply supply in supplies)
        {
            if (!products.ContainsKey(supply.Product))
                throw new ProductNotRegisteredException();
        }

        foreach (Supply supply in supplies)
        {
            ShopProduct product = products[supply.Product];
            product.UpdatePrice(supply.Price);
            product.IncreaseCount(supply.Count);
        }
    }

    public void RegisterProduct(ShopProduct shopProduct)
    {
        Product? product = shopProduct.Product;
        if (products.ContainsKey(product))
            throw new ProductAlreadyRegisteredException();

        products[product] = shopProduct;
    }

    public void ChangePrice(Product product, decimal newPrice)
    {
        if (!products.ContainsKey(product))
            throw new ProductNotRegisteredException();

        products[product].UpdatePrice(newPrice);
    }

    public void BuyProducts(Person person, params Purchase[] purchases)
    {
        decimal total = 0m;
        foreach (Purchase purchase in purchases)
        {
            Product? product = purchase.Product;
            int amount = purchase.Amount;

            if (!products.ContainsKey(product))
                throw new ProductNotRegisteredException();

            ShopProduct shopProduct = products[product];

            if (shopProduct.Count < amount)
                throw new NotEnoughProductsException();

            total += shopProduct.Price * amount;
        }

        if (total > person.Money)
            throw new NotEnoughMoneyException();

        foreach (Purchase purchase in purchases)
        {
            Product? product = purchase.Product;
            ShopProduct shopProduct = products[product];
            int amount = purchase.Amount;

            shopProduct.DecreaseCount(amount);
        }

        person.DecreaseMoney(total);
    }

    public ShopProduct GetProduct(Product product)
    {
        if (!products.ContainsKey(product))
            throw new ProductDoesNotExistException();

        return products[product];
    }

    public bool HasProduct(Product product)
    {
        return products.ContainsKey(product);
    }

    public List<ShopProduct> GetShopProducts()
    {
        return new List<ShopProduct>(products.Values);
    }

    public List<Product> GetProducts() { return new List<Product>(products.Keys); }
}
