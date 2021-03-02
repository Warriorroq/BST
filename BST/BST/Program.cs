using System;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> a = new BinaryTree<int>(7, null);
            a.Add(2);
            a.Add(9);
            a.Add(-5);
            a.Add(3);
            Console.WriteLine(a.Remove(1));
            a.Add(1);
            Console.WriteLine(a.Find(2));
        }
    }
}
