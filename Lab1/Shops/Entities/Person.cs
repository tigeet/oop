namespace Shops.Entities;
public class Person
{
    private string name;
    private decimal money;

    public Person(string name, decimal money)
    {
        this.name = name;
        this.money = money;
    }

    public string GetName()
    {
        return name;
    }

    public decimal GetMoney()
    {
        return money;
    }

    public void DecreaseMoney(decimal amount)
    {
        money = money - amount;
    }
}
