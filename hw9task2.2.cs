
using System;
using System.Collections.Generic;
public enum Rarity
{
    Common,
    Rare,
    Legendary
}
public interface IUsableItem
{
    string Name { get; }
    string Description { get; }
    Rarity Rarity { get; }

    void Use(Player player);
}
public class Player
{
    public string Name { get; }
    public int HP { get; set; }
    public int Damage { get; set; }
    public Player(string name)
    {
        Name = name;
        HP = 100;
        Damage = 10;
    }
    public void Heal(int amount)
    {
        HP += amount;
    }
    public void IncreaseDamage(int amount)
    {
        Damage += amount;
    }
}
public class HealthPotion : IUsableItem
{
    public string Name { get; } = "Зелье здоровья";
    public string Description { get; } = "Восстанавливает 50 HP";
    public Rarity Rarity { get; } = Rarity.Common;
    public void Use(Player player)
    {
        player.Heal(50);
        Console.WriteLine($"{player.Name} использовал зелье здоровья!");
    }
}
public class Sword : IUsableItem
{
    public string Name { get; } = "Меч";
    public string Description { get; } = "Увеличивает урон на 10";
    public Rarity Rarity { get; } = Rarity.Rare;
    public void Use(Player player)
    {
        player.IncreaseDamage(10);
        Console.WriteLine($"{player.Name} использовал меч!");
    }
}
public class AncientScroll : IUsableItem
{
    public string Name { get; } = "Древний свиток";
    public string Description { get; } = "Наносит 20 урона и увеличивает урон на 30";
    public Rarity Rarity { get; } = Rarity.Legendary;
    public void Use(Player player)
    {
        player.HP -= 20;
        player.IncreaseDamage(30);
        Console.WriteLine($"{player.Name} использовал древний свиток!");
    }
}
public class Program
{
    public static void Main()
    {
        Player player = new Player("Артур");
        List<IUsableItem> items = new List<IUsableItem>
        {
            new HealthPotion(),
            new Sword(),
            new AncientScroll()
        };
        foreach (IUsableItem item in items)
        {
            item.Use(player);
        }
        Console.WriteLine("\nИтоговые характеристики игрока:");
        Console.WriteLine($"Имя: {player.Name}");
        Console.WriteLine($"HP: {player.HP}");
        Console.WriteLine($"Урон: {player.Damage}");
        if (player.HP > 0)
        {
            Console.WriteLine("Игрок жив!");
        }
        else
        {
            Console.WriteLine("Игрок погиб!");
        }
    }
}
