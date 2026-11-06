using System;

class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class Program
{
    public static int compareCount = 0;

    public static Node Insert(Node node, int key)
    {
        if (node == null)
        {
            return new Node(key);
        }

        if (key < node.Value)
        {
            node.Left = Insert(node.Left, key);
        }
        else if (key > node.Value)
        {
            node.Right = Insert(node.Right, key);
        }

        return node;
    }

    public static bool Search(Node node, int key)
    {
        if (node == null)
        {
            return false;
        }

        compareCount++;

        if (key == node.Value)
        {
            return true;
        }

        if (key < node.Value)
        {
            return Search(node.Left, key);
        }

        return Search(node.Right, key);
    }

    public static void InOrder(Node node)
    {
        if (node == null)
        {
            return;
        }

        InOrder(node.Left);
        Console.Write(node.Value + " ");
        InOrder(node.Right);
    }

    public static int CountNodes(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }

    static void Main()
    {
        int[] values = { 42, 18, 65, 9, 27, 55, 90, 33 };
        Node root = null;

        foreach (int val in values)
        {
            root = Insert(root, val);
        }

        Console.WriteLine(CountNodes(root));

        InOrder(root);
        Console.WriteLine();

        compareCount = 0;
        bool found55 = Search(root, 55);
        Console.WriteLine(found55 + " " + compareCount);

        compareCount = 0;
        bool found30 = Search(root, 30);
        Console.WriteLine(found30 + " " + compareCount);

        root = Insert(root, 27);
        Console.WriteLine(CountNodes(root));
    }
}