
using System;
public interface IDamageCalculator
{
    int CalculateDamage(int baseDamage, int targetArmor);
}
public class PhysicalDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        return Math.Max(1, baseDamage - targetArmor / 2);
    }
}
public class MagicDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        if (targetArmor == 0)
        {
            return baseDamage * 2;
        }
        return Math.Max(1, baseDamage - targetArmor / 4);
    }
}
public class FireDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        int damage = baseDamage - targetArmor / 10;
        if (baseDamage > 50)
        {
            damage += 10;
        }
        return Math.Max(1, damage);
    }
}
public class Unit
{
    public string Name { get; }
    public int HP { get; set; }
    public int Armor { get; }
    public Unit(string name, int hp, int armor)
    {
        Name = name;
        HP = hp;
        Armor = armor;
    }
}
public class DamageSystem
{
    private IDamageCalculator _calculator;
    public DamageSystem(IDamageCalculator calculator)
    {
        _calculator = calculator;
    }
    public void ApplyDamage(Unit target, int baseDamage)
    {
        int damage = _calculator.CalculateDamage(baseDamage, target.Armor);
        target.HP = Math.Max(0, target.HP - damage);
        Console.WriteLine(
            $"{target.Name} получил {damage} урона. Осталось HP: {target.HP}"
        );
    }
}
public class IceDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int targetArmor)
    {
        return Math.Max(1, baseDamage - targetArmor / 5);
    }
}
public class Program
{
    public static void Main()
    {
        Unit unit = new Unit("Артур", 200, 20);
        DamageSystem physicalSystem =
            new DamageSystem(new PhysicalDamageCalculator());
        DamageSystem magicSystem =
            new DamageSystem(new MagicDamageCalculator());
        DamageSystem fireSystem =
            new DamageSystem(new FireDamageCalculator());
        DamageSystem iceSystem =
            new DamageSystem(new IceDamageCalculator());
        Console.WriteLine("Начальные характеристики:");
        Console.WriteLine($"Имя: {unit.Name}");
        Console.WriteLine($"HP: {unit.HP}");
        Console.WriteLine($"Броня: {unit.Armor}");
        Console.WriteLine();
        Console.WriteLine("Физический урон:");
        physicalSystem.ApplyDamage(unit, 40);
        Console.WriteLine("Магический урон:");
        magicSystem.ApplyDamage(unit, 40);
        Console.WriteLine("Огненный урон:");
        fireSystem.ApplyDamage(unit, 60);
        Console.WriteLine("Ледяной урон:");
        iceSystem.ApplyDamage(unit, 40);
    }
}
