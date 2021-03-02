using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    class BinaryTree<T> : IEnumerable
        where T : IComparable<T>
    {
        private BinaryTree<T> parent;
        private BinaryTree<T> left;
        private BinaryTree<T> right;
        public T item;

        public object Current => throw new NotImplementedException();

        public BinaryTree(T item, BinaryTree<T> parent)
        {
            this.item = item;
            this.parent = parent;
        }
        #region CreateBinary
        public void Add(T item)
        {
            if (item.CompareTo(this.item) < 0)
                AddToTree(ref left, item);
            else
                AddToTree(ref right, item);   
        }
        private void AddToTree(ref BinaryTree<T> tree, T item)
        {
            if (tree is null)
                CreateBinaryTree(ref tree,  item);
            else if (!(tree is null))
                tree.Add(item);
        }
        private void CreateBinaryTree(ref BinaryTree<T> binaryTree, T item)
        {
            binaryTree = new BinaryTree<T>(item, this);
        }
        #endregion
        #region FindBinary
        public BinaryTree<T> Find(T item)
        {
            return Find(this, item);
        }
        private BinaryTree<T> Find(BinaryTree<T> tree, T item)
        {
            if (tree is null) 
                return null;
            if(item.CompareTo(tree.item) == 1)
                return Find(tree.right, item);
            else if (item.CompareTo(tree.item) == -1)
                return Find(tree.left, item);
            else
                return tree;
        }
        #endregion
        #region Remove
        public BinaryTree<T> Remove(T val)
        {
            BinaryTree<T> removeTree = Find(this, val);
            if(!(removeTree is null))
            {
                return RemoveTree(removeTree);
            }
            return null;
        }
        public BinaryTree<T> RemoveTree(BinaryTree<T> removeTree)
        {
            removeTree.right.parent = removeTree.parent;
            removeTree.right.parent.right = removeTree.right;
            if (!(removeTree.left is null))
            {
                removeTree.left.parent = removeTree.right;
            }
            return removeTree;
        }
        #endregion
        #region Iterator
        public IEnumerator GetEnumerator()
        {
            BinaryTree<T> last = null;
            BinaryTree<T> current = this;

            while(current != null)
            {
                if(current.right == null && current.left == null)
                {
                    yield return current.item;
                }
            }//working
            last = current;
            current = current.right;
        }
        #endregion
    }
}
