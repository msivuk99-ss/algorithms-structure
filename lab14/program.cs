using System;
using System.Collections.Generic;

class Program
{
    static HashSet<string> visitAll(Dictionary<string, List<string>> graph, string start)
    {
        var visited = new HashSet<string>();
        if (!graph.ContainsKey(start))
            return visited;

        var queue = new Queue<string>();
        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();
            foreach (string neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return visited;
    }

    static bool reachable(Dictionary<string, List<string>> graph, string from, string to)
    {
        return visitAll(graph, from).Contains(to);
    }

    static List<string> findPath(Dictionary<string, List<string>> graph, string from, string to)
    {
        var path = new List<string>();
        if (!graph.ContainsKey(from) || !graph.ContainsKey(to))
            return path;

        var visited = new HashSet<string>();
        var parent = new Dictionary<string, string>();
        var queue = new Queue<string>();

        visited.Add(from);
        queue.Enqueue(from);

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();
            if (current == to)
                break;

            foreach (string neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        if (!visited.Contains(to))
            return path;

        string step = to;
        while (step != null)
        {
            path.Add(step);
            parent.TryGetValue(step, out step);
        }

        path.Reverse();
        return path;
    }

    static void Main()
    {
        var graph = new Dictionary<string, List<string>>();

        graph["Центр"]   = new List<string> { "Парк", "Ринок" };
        graph["Парк"]    = new List<string> { "Центр", "Вокзал" };
        graph["Ринок"]   = new List<string> { "Центр", "Вокзал", "Стадіон" };
        graph["Вокзал"]  = new List<string> { "Парк", "Ринок", "Озеро" };
        graph["Стадіон"] = new List<string> { "Ринок" };
        graph["Озеро"]   = new List<string> { "Вокзал" };
        graph["Гай"]     = new List<string> { "Міст" };
        graph["Міст"]    = new List<string> { "Гай" };

        Console.WriteLine(visitAll(graph, "Центр").Count);
        Console.WriteLine(reachable(graph, "Центр", "Озеро"));
        Console.WriteLine(reachable(graph, "Центр", "Гай"));
        Console.WriteLine(reachable(graph, "Гай", "Міст"));
        Console.WriteLine(string.Join(" -> ", findPath(graph, "Центр", "Озеро")));
        Console.WriteLine(string.Join(" -> ", findPath(graph, "Центр", "Стадіон")));
        Console.WriteLine(string.Join(" -> ", findPath(graph, "Центр", "Міст")));
        Console.WriteLine(graph.Count - visitAll(graph, "Центр").Count);
    }
}