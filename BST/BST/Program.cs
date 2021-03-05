using System;

namespace BST
{
    class Program
    {
        private static Random random = new Random();
        private static void Main(string[] args)
        {
            Console.WriteLine("Binary Top: (grn,dollar,euro,name)");
            string[] keys = Console.ReadLine().ToUpper().Split(',');
            Vallet treeVallet = new Vallet(float.Parse(keys[0]), float.Parse(keys[1]), float.Parse(keys[2]), keys[3]);
            BinaryTree<Vallet> tree = new BinaryTree<Vallet>(treeVallet, null);

            for(int i = 4; i < 100; i++)
                tree.Add(new Vallet(random.Next(3, i * 10), random.Next(0, i), random.Next(0, i), ValletUsers.GetRangomUser));

            tree.CrismasTree();

            Console.WriteLine(tree.ToString('\n'));
        }
    }
}
