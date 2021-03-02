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
            a.Add(1);
            foreach(var b in a)
            {
                Console.WriteLine(b);
            }
        }
    }
}
