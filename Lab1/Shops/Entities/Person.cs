namespace Shops.Entities;
public class Person
{
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
    }

    public string Name { get; }
    public decimal Money { get; set; }

    public void DecreaseMoney(decimal amount)
    {
        Money = Money - amount;
    }
}
