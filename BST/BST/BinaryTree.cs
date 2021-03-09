using System;
using System.Collections;
using System.Collections.Generic;

namespace BST
{
    class BinaryTree<T> : IEnumerable
        where T : IComparable
    {
        private BinaryTree<T> parent;
        private BinaryTree<T> left;
        private BinaryTree<T> right;
        public Cell<T> cell;

        public BinaryTree(T item, BinaryTree<T> parent)
        {
            this.cell = new Cell<T>(item);
            this.parent = parent;
        }

        #region Create or Add BinaryTree

        public void Add(T item)
        {
            if (item.CompareTo(this.cell.GetItem()) < 0)
                AddToTree(ref left, item);
            else
                AddToTree(ref right, item);
        }

        private void AddToTree(ref BinaryTree<T> tree, T item)
        {
            if (tree is null)
                CreateBinaryTree(ref tree, item);
            else if (!(tree is null))
                tree.Add(item);
        }

        private void CreateBinaryTree(ref BinaryTree<T> binaryTree, T item)
        {
            binaryTree = new BinaryTree<T>(item, this);
        }

        #endregion

        #region Find BinaryTree

        public BinaryTree<T> Find(T item)
        {
            return Find(this, new Cell<T>(item));
        }

        public bool Contains(T item)
        {
            return !(Find(this, new Cell<T>(item)) is null);
        }

        private BinaryTree<T> Find(BinaryTree<T> tree, Cell<T> item)
        {
            if (tree is null) 
                return null;

            if(item.CompareTo(tree.cell) == 1)
                return Find(tree.right, item);
            else if (item.CompareTo(tree.cell) == -1)
                return Find(tree.left, item);
            else
                return tree;
        }

        #endregion

        #region Remove Tree

        public BinaryTree<T> Remove(T val)
        {
            BinaryTree<T> removeTree = Find(this, new Cell<T>(val));

            if(!(removeTree is null))
                return RemoveTree(removeTree);
            
            return null;
        }

        private BinaryTree<T> RemoveTree(BinaryTree<T> removeTree)
        {
            removeTree.right.parent = removeTree.parent;
            removeTree.right.parent.right = removeTree.right;

            if (!(removeTree.left is null))
            {
                BinaryTree<T> leftTree = PreOrderLastLeftTree(removeTree.right);
                removeTree.left.parent = leftTree;
                leftTree.left = removeTree.left;
            }
            
            return removeTree;
        }

        #endregion

        #region Iterator of BinaryTree
        private BinaryTree<T> PreOrderLastLeftTree(BinaryTree<T> tree)
        {
            if (!(tree.left is null))
                return PreOrderLastLeftTree(tree.left);
            else
                return tree;
        }

        public IEnumerator GetEnumerator()
        {
            yield return cell.GetItem();

            if (!(right is null))
                foreach (var treeValue in right)
                    yield return treeValue;

            if (!(left is null))
                foreach (var TreeValue in left)
                    yield return TreeValue;
        }

        #endregion

        #region string functions region

        public string ToStringAndSplitByChar(char join)
        {
            var items = new List<T>();
            foreach (T a in this)
                items.Add(a);
            return $"Tree: {string.Join(',', items)}";
        }

        public override string ToString()
        {
            var items = new List<T>();
            foreach (T a in this)
                items.Add(a);
            return $"Tree: {string.Join(',', items)}";
        }

        #endregion
    }
}
