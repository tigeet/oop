using Shops.Entities;
using Shops.Models;
namespace Shops.Services;

public class ShopService
{
    private Dictionary<int, Shop> shops = new Dictionary<int, Shop>();
    private Dictionary<int, string> products = new Dictionary<int, string>();
    private ShopIdFactory shopIdFactory = new ShopIdFactory();
    private ProductIdFactory productIdFactory = new ProductIdFactory();
    public ShopService() { }

    public Shop CreateShop(string name, string address)
    {
        int id = shopIdFactory.GetNextId();
        var shop = new Shop(id, name, address);

        foreach (int productId in new List<int>(products.Keys))
        {
            if (!shop.HasProduct(productId))
                shop.RegisterProduct(new Product(productId, products[productId]));
        }

        shops[id] = shop;
        return shop;
    }

    public int RegisterProduct(string name)
    {
        int id = productIdFactory.GetNextId();
        var shopsList = new List<Shop>(shops.Values);

        foreach (Shop shop in shopsList)
        {
            var product = new Product(id, name);
            shop.RegisterProduct(product);
        }

        products[id] = name;
        return id;
    }

    public Shop? FindShopWithBestPrice(params Purchase[] purchases)
    {
        var shopsList = new List<Shop>(shops.Values);

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
                decimal amount = purchase.GetAmount();
                int id = purchase.GetId();
                if (!shop.HasProduct(id))
                {
                    found = false;
                    break;
                }

                Product product = shop.GetProduct(id);

                if (product.GetCount() < amount)
                {
                    found = false;
                    break;
                }

                sm += product.GetPrice() * amount;
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
