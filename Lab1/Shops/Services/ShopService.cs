using Shops.Entities;
using Shops.Models;
namespace Shops.Services;

public class ShopService
{
    private Dictionary<int, Shop> shops = new Dictionary<int, Shop>();
    private int nextId = 0;
    public ShopService() { }

    public Shop CreateShop(string name, string address, params ProductInfo[] productInfos)
    {
        var shop = new Shop(nextId, name, address, productInfos);
        shops[nextId] = shop;
        nextId++;
        return shop;
    }

    public Shop? FindShopWithBestPrice(params Purchase[] purchases)
    {
        var shopsList = new List<Shop>(shops.Values);

        if (shopsList.Count() == 0)
        {
            return null;
        }

        decimal minPrice = decimal.MaxValue;
        Shop? minShop = null;

        foreach (Shop shop in shopsList)
        {
            decimal sm = 0;
            bool found = true;
            foreach (Purchase purchase in purchases)
            {
                decimal amount = purchase.GetAmount();
                ProductInfo productInfo = purchase.GetProductInfo();
                if (!shop.HasProduct(productInfo))
                {
                    found = false;
                    break;
                }

                Product product = shop.GetProduct(productInfo);

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
