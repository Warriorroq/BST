using System;

namespace BST
{
    class Program
    {
        private static Random random = new Random();
        private static void Main(string[] args)
        {
            Console.WriteLine("Binary Top: (name)");
            BinaryTree<Vallet> tree = new BinaryTree<Vallet>(new Vallet(random.Next(30, 40), random.Next(1, 4), random.Next(0, 5), Console.ReadLine()), null);

            for(int i = 4; i < 10; i++)
            {
                tree.Add(new Vallet(random.Next(3, i * 10), random.Next(0, i), random.Next(0, i), ValletUsers.GetRangomUser));
            }

            Console.WriteLine(tree.ToString());
        }
    }
}
