using System;
using System.Collections.Generic;

class Node
{
    public string Title { get; set; }
    public List<Node> Children { get; set; }

    public Node(string title, List<Node> children = null)
    {
        Title = title;
        Children = children ?? new List<Node>();
    }
}

class Program
{
    public static int callCount = 0;

    public static void PrintMenu(Node node, int level = 0)
    {
        Console.WriteLine(new string(' ', level * 2) + node.Title);
        foreach (var child in node.Children)
        {
            PrintMenu(child, level + 1);
        }
    }

    public static int CountItems(Node node)
    {
        callCount++;
        int count = 1;
        foreach (var child in node.Children)
        {
            count += CountItems(child);
        }
        return count;
    }

    public static bool Find(Node node, string name)
    {
        if (node.Title == name)
            return true;

        foreach (var child in node.Children)
        {
            if (Find(child, name))
                return true;
        }

        return false;
    }

    static void Main()
    {
        Node menu = new Node("Головне меню", new List<Node>
        {
            new Node("Файл", new List<Node>
            {
                new Node("Новий"),
                new Node("Зберегти")
            }),
            new Node("Правка", new List<Node>
            {
                new Node("Копіювати")
            }),
            new Node("Вигляд", new List<Node>
            {
                new Node("Масштаб", new List<Node>
                {
                    new Node("Збільшити"),
                    new Node("Зменшити")
                })
            }),
            new Node("Довідка")
        });

        PrintMenu(menu);
        Console.WriteLine(CountItems(menu));
        Console.WriteLine(Find(menu, "Зберегти"));
        Console.WriteLine(Find(menu, "Масштаб"));
        Console.WriteLine(Find(menu, "Довідка"));
        Console.WriteLine(Find(menu, "Експорт"));
        Console.WriteLine(callCount);
    }
}