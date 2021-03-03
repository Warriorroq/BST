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

            tree.Add(7);
            tree.Add(5);
            tree.Add(6);
            tree.Add(4);
            tree.Add(10);
            tree.Add(9);
            tree.Add(8);
            tree.Remove(7);
            /*for(int i = 10; i < 90; i++)
            {
                tree.Add(random.Next(-i, i));
            }*/
            tree.Add(-1);
            Console.WriteLine(tree.ToString());
        }
    }
}
