using Shops.Exceptions;
using Shops.Models;
namespace Shops.Entities;
public class Shop
{
    private Dictionary<int, Product> products;
    private int id;
    private string name;
    private string address;

    public Shop(int id, string name, string address)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        products = new Dictionary<int, Product>();
    }

    public string GetName() { return name; }
    public string GetAddress() { return address; }
    public int GetId() { return id; }

    public void AddProducts(params Supply[] supplies)
    {
        foreach (Supply supply in supplies)
        {
            if (!products.ContainsKey(supply.GetId()))
                throw new ProductNotRegisteredException();
        }

        foreach (Supply supply in supplies)
        {
            Product product = products[supply.GetId()];
            product.UpdatePrice(supply.GetPrice());
            product.IncreaseCount(supply.GetCount());
        }
    }

    public void RegisterProduct(Product product)
    {
        int id = product.GetId();
        if (products.ContainsKey(id))
            throw new ProductAlreadyRegisteredException();

        products[id] = product;
    }

    public void ChangePrice(int id, decimal newPrice)
    {
        if (!products.ContainsKey(id))
            throw new ProductNotRegisteredException();

        products[id].UpdatePrice(newPrice);
    }

    public void BuyProducts(Person person, params Purchase[] purchases)
    {
        decimal total = 0m;
        foreach (Purchase purchase in purchases)
        {
            int id = purchase.GetId();
            int amount = purchase.GetAmount();

            if (!products.ContainsKey(id))
                throw new ProductNotRegisteredException();

            Product product = products[id];

            if (product.GetCount() < amount)
                throw new NotEnoughProductsException();

            total += product.GetPrice() * amount;
        }

        if (total > person.GetMoney())
            throw new NotEnoughMoneyException();

        foreach (Purchase purchase in purchases)
        {
            int id = purchase.GetId();
            Product product = products[id];
            int amount = purchase.GetAmount();

            product.DecreaseCount(amount);
        }

        person.DecreaseMoney(total);
    }

    public Product GetProduct(int id)
    {
        if (!products.ContainsKey(id))
            throw new ProductDoesNotExistException();

        return products[id];
    }

    public bool HasProduct(int id)
    {
        return products.ContainsKey(id);
    }

    public List<Product> GetProducts()
    {
        return new List<Product>(products.Values);
    }

    public List<int> GetProductIds() { return new List<int>(products.Keys); }
}
