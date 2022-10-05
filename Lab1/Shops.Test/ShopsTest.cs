using Shops.Entities;
using Shops.Models;
using Shops.Services;
using Xunit;

namespace Shops.Tests;
public class ShopsTests
{
    private ShopService shopService;

    public ShopsTests()
    {
        shopService = new ShopService();
    }

    [Fact]
    public void BuyProductWorks()
    {
        var person = new Person("leo", 123);

        var product1 = new ProductInfo("product1");
        var product2 = new ProductInfo("product2");

        Shop shop = shopService.CreateShop("shop1", "spb ..4i0", product1, product2);

        shop.AddProducts(new Supply(product1, 10, 3.2m), new Supply(product2, 5, 10m));
        shop.BuyProducts(person, new Purchase(product2, 3), new Purchase(product1, 7));

        Assert.Equal(123 - (3 * 10m) - (7 * 3.2m), person.GetMoney());
        Assert.Equal(3, shop.GetProduct(product1).GetCount());
    }

    [Fact]
    public void ShopFindWorks()
    {
        var product1 = new ProductInfo("product1");
        var product2 = new ProductInfo("product2");

        Shop shop1 = shopService.CreateShop("shop1", "spb ..4i0", product1, product2);
        Shop shop2 = shopService.CreateShop("shop1", "spb ..4i0", product1, product2);
        Shop shop3 = shopService.CreateShop("shop1", "spb ..4i0", product1, product2);

        shop1.AddProducts(new Supply(product1, 10, 3.2m), new Supply(product2, 5, 10m));
        shop2.AddProducts(new Supply(product1, 10, 3m), new Supply(product2, 5, 10m));
        shop3.AddProducts(new Supply(product1, 10, 3.5m), new Supply(product2, 5, 10m));

        Assert.Equal(shop2, shopService.FindShopWithBestPrice(new Purchase(product1, 5), new Purchase(product2, 5)));
        Assert.Null(shopService.FindShopWithBestPrice(new Purchase(product1, 5), new Purchase(product2, 10)));
    }
}
