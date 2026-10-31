using System;
using System.Collections.Generic;

public class Product
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Product(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public override bool Equals(object obj)
    {
        if (obj is Product other)
        {
            return this.Code == other.Code;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Code != null ? Code.GetHashCode() : 0;
    }
}

public class Program
{
    public static void Main()
    {
        List<Product> items = new List<Product>
        {
            new Product("A-100", "Кабель USB-C"),
            new Product("B-205", "Миша бездротова"),
            new Product("A-100", "Кабель USB-C"),
            new Product("C-310", "Клавіатура"),
            new Product("D-415", "Монітор 24 дюйми"),
            new Product("B-205", "Миша бездротова"),
            new Product("E-520", "Навушники"),
            new Product("F-630", "Вебкамера")
        };

        HashSet<Product> unique = new HashSet<Product>();
        foreach (var p in items)
        {
            unique.Add(p);
        }

        Dictionary<Product, int> stock = new Dictionary<Product, int>();
        stock[new Product("A-100", "Кабель USB-C")] = 17;
        stock[new Product("A-100", "Кабель USB-C")] = 25;

        Product a = new Product("A-100", "Кабель USB-C");
        Product b = new Product("A-100", "Кабель USB-C");

        Console.WriteLine(a.Equals(b));
        Console.WriteLine(unique.Count);
        Console.WriteLine(unique.Contains(a));
        Console.WriteLine(stock.Count);
        Console.WriteLine(stock.ContainsKey(a));
    }
}