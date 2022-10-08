using Shops.Entities;
using Shops.Models;
namespace Shops.Services;

public class ShopService
{
    private Dictionary<Guid, Shop> _shops = new Dictionary<Guid, Shop>();
    private Dictionary<Guid, Product> _products = new Dictionary<Guid, Product>();
    public ShopService() { }

    public Shop CreateShop(string name, string address, params Product[] productsList)
    {
        var shop = new Shop(name, address);
        Guid id = shop.GetId();
        foreach (Product product in productsList)
        {
            if (!shop.HasProduct(product))
                shop.RegisterProduct(new ShopProduct(product));
        }

        _shops[id] = shop;
        return shop;
    }

    public Product RegisterProduct(string name)
    {
        var product = new Product(name);
        Guid id = product.Id;
        _products[id] = product;
        return product;
    }

    public Shop? FindShopWithBestPrice(params Purchase[] purchases)
    {
        var shopsList = new List<Shop>(_shops.Values);

        if (shopsList.Count() == 0)
            return null;

        decimal minPrice = decimal.MaxValue;
        Shop? minShop = null;

        foreach (Shop shop in shopsList)
        {
            decimal sm = 0;
            bool found = true;
            foreach (Purchase purchase in purchases)
            {
                decimal amount = purchase.Amount;
                Product? product = purchase.Product;
                if (!shop.HasProduct(product))
                {
                    found = false;
                    break;
                }

                ShopProduct shopProduct = shop.GetProduct(product);

                if (shopProduct.Count < amount)
                {
                    found = false;
                    break;
                }

                sm += shopProduct.Price * amount;
            }

            if (found && sm < minPrice)
            {
                minPrice = sm;
                minShop = shop;
            }
        }

        return minShop;
    }
}
