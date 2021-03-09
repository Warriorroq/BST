using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    public class Cell<T> : IComparable
        where T : IComparable
    {
        private T item;
        public Cell(T item)
            =>this.item = item;

        public int CompareTo(object obj)
        {
            var compareCell = obj as Cell<T>;

            if (compareCell is null)
                return -1;

            return compareCell.GetItem().CompareTo(item);
        }

        public T GetItem()
            => item;
    }
}
