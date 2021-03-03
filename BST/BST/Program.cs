using System;

namespace BST
{
    class Program
    {
        private static Random random = new Random();
        private static void Main(string[] args)
        {
            Console.WriteLine("Binary Top:");
            BinaryTree<int> tree = new BinaryTree<int>(int.Parse(Console.ReadLine()), null);
            for(int i = 10; i < 90; i++)
            {
                tree.Add(random.Next(-i, i));
            }
            Console.WriteLine(tree.ToString());
            tree.CrismasTree();
            Console.WriteLine(tree.ToString());
        }
    }
}
