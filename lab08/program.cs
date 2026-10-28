using System;
using System.Collections.Generic;

class Client
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Client(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Order
{
    public int Number { get; set; }
    public int ClientId { get; set; }
    public int Sum { get; set; }

    public Order(int number, int clientId, int sum)
    {
        Number = number;
        ClientId = clientId;
        Sum = sum;
    }
}

class Program
{
    static void Main()
    {
        List<Client> clients = new List<Client>
        {
            new Client(101, "Коваленко"),
            new Client(102, "Мельник"),
            new Client(103, "Шевчук"),
            new Client(104, "Бондар"),
            new Client(105, "Ткачук"),
            new Client(106, "Гриценко")
        };

        List<Order> orders = new List<Order>
        {
            new Order(1, 103, 450),
            new Order(2, 101, 120),
            new Order(3, 105, 980),
            new Order(4, 103, 300),
            new Order(5, 102, 75),
            new Order(6, 106, 1500),
            new Order(7, 101, 220),
            new Order(8, 103, 60)
        };

        List<int> blocked = new List<int> { 102, 104 };

        Console.WriteLine("=== Фрагмент 1 ===");
        Dictionary<int, string> clientsById = new Dictionary<int, string>();
        foreach (var client in clients)
        {
            clientsById[client.Id] = client.Name;
        }
        foreach (var order in orders)
        {
            Console.WriteLine("Замовлення " + order.Number + " " + clientsById[order.ClientId]);
        }

        Console.WriteLine("\n=== Фрагмент 2 ===");
        HashSet<int> blockedSet = new HashSet<int>(blocked);
        int total = 0;
        foreach (var order in orders)
        {
            if (!blockedSet.Contains(order.ClientId))
            {
                total += order.Sum;
            }
        }
        Console.WriteLine("Сума прийнятих замовлень: " + total);

        Console.WriteLine("\n=== Фрагмент 3 ===");
        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (var order in orders)
        {
            if (!counts.ContainsKey(order.ClientId))
                counts[order.ClientId] = 0;
            counts[order.ClientId]++;
        }
        HashSet<int> printed = new HashSet<int>();
        foreach (var order in orders)
        {
            if (!printed.Contains(order.ClientId))
            {
                Console.WriteLine(order.ClientId + ":" + counts[order.ClientId]);
                printed.Add(order.ClientId);
            }
        }

        Console.WriteLine("\n=== Фрагмент 4 ===");
        Order best = orders[0];
        foreach (var order in orders)
        {
            if (order.Sum > best.Sum)
            {
                best = order;
            }
        }
        Console.WriteLine("Найбільше замовлення: " + best.Sum);

        Console.WriteLine("\n=== Фрагмент 5 ===");
        Dictionary<int, Client> byId = new Dictionary<int, Client>();
        foreach (var client in clients)
        {
            byId[client.Id] = client;
        }
        foreach (var order in orders)
        {
            Console.WriteLine("Замовлення " + order.Number + " " + byId[order.ClientId].Name);
        }
    }
}