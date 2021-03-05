using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public static class ValletUsers
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789";
        private static Random random = new Random();
        public static string GetRangomUser
        {
            get
            {
                return new string(Enumerable.Repeat(chars, random.Next(3, 10))
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }
}
