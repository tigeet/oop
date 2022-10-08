using Shops.Entities;
using Shops.Exceptions;
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
    public void RegisterProductWorks()
    {
        Product productId1 = shopService.RegisterProduct("prod1");

        Product productId2 = shopService.RegisterProduct("prod2");
        Shop shop = shopService.CreateShop("shop1", "spb ..4i0", productId1, productId2);

        Assert.Contains(productId1, shop.GetProducts());
        Assert.Contains(productId2, shop.GetProducts());
    }

    [Fact]
    public void ChangePriceWorks()
    {
        Product productId1 = shopService.RegisterProduct("prod1");
        Shop shop = shopService.CreateShop("shop1", "spb ..4i0", productId1);
        ShopProduct product = shop.GetProduct(productId1);

        Assert.Equal(0m, shop.GetProduct(productId1).Price);

        product.UpdatePrice(123m);
        Assert.Equal(123m, product.Price);

        shop.AddProducts(new Supply(productId1, 1, 1234m));
        Assert.Equal(1234m, product.Price);
    }

    [Fact]
    public void BuyProductsWorks()
    {
        var person = new Person("leo", 123);

        Product productId1 = shopService.RegisterProduct("prod1");
        Product productId2 = shopService.RegisterProduct("prod2");
        Product productId3 = shopService.RegisterProduct("prod3");

        Shop shop = shopService.CreateShop("shop1", "spb ..4i0", productId1, productId2, productId3);
        shop.AddProducts(new Supply(productId1, 10, 3.2m), new Supply(productId2, 5, 10m), new Supply(productId3, 10000, 1000m));

        shop.BuyProducts(person, new Purchase(productId2, 3), new Purchase(productId1, 7));

        Assert.Equal(123 - (3 * 10m) - (7 * 3.2m), person.Money);
        Assert.Equal(3, shop.GetProduct(productId1).Count);
        Assert.Throws<NotEnoughMoneyException>(() => shop.BuyProducts(person, new Purchase(productId3, 5)));
        Assert.Throws<NotEnoughProductsException>(() => shop.BuyProducts(person, new Purchase(productId1, 20)));
    }

    [Fact]
    public void FindShopWorks()
    {
        Product productId1 = shopService.RegisterProduct("prod1");
        Product productId2 = shopService.RegisterProduct("prod2");

        Shop shop1 = shopService.CreateShop("shop1", "spb ..4i0", productId1, productId2);
        Shop shop2 = shopService.CreateShop("shop1", "spb ..4i0", productId1, productId2);
        Shop shop3 = shopService.CreateShop("shop1", "spb ..4i0", productId1, productId2);

        shop1.AddProducts(new Supply(productId1, 10, 3.2m), new Supply(productId2, 5, 10m));
        shop2.AddProducts(new Supply(productId1, 10, 3m), new Supply(productId2, 5, 10m));
        shop3.AddProducts(new Supply(productId1, 10, 3.5m), new Supply(productId2, 5, 10m));

        Assert.Equal(shop2, shopService.FindShopWithBestPrice(new Purchase(productId1, 5), new Purchase(productId2, 5)));
        Assert.Null(shopService.FindShopWithBestPrice(new Purchase(productId1, 5), new Purchase(productId2, 10)));
    }
}
