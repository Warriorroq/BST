using System;

namespace BST
{
    class Program
    {
        private static Random random = new Random();
        private static void Main(string[] args)
        {
            BinaryTree<Vallet> tree = new BinaryTree<Vallet>(CreateMyVallet(), null);

            for (int i = 4; i < 100; i++)
                tree.Add(new Vallet(random.Next(3, i * 10), random.Next(0, i), random.Next(0, i), ValletUsers.GetRangomUser));

            tree.CrismasTree();

            Console.WriteLine(tree.ToString('\n'));
        }
        private static Vallet CreateMyVallet()
        {

            Console.WriteLine("Binary Top: (grn,dollar,euro,name)");
            string[] keys = Console.ReadLine().ToUpper().Split(',');
            Vallet vallet;
            try
            {
                vallet = new Vallet(float.Parse(keys[0]), float.Parse(keys[1]), float.Parse(keys[2]), keys[3]);
            }
            catch
            {
                vallet = new Vallet(0, 0, 0, ValletUsers.GetRangomUser);
            }
            return vallet;
        }
    }
}
