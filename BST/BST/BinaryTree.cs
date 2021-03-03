using System;
using System.Collections;
using System.Collections.Generic;

namespace BST
{
    class BinaryTree<T> : IEnumerable
        where T : IComparable<T>
    {
        private BinaryTree<T> parent;
        private BinaryTree<T> left;
        private BinaryTree<T> right;
        public T item;

        public BinaryTree(T item, BinaryTree<T> parent)
        {
            this.item = item;
            this.parent = parent;
        }
        #region Create or Add BinaryTree
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
            return Find(this, item);
        }
        public bool Contains(T item)
        {
            if (!(Find(this, item) is null))
                return true;

            return false;
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
        #region Remove Tree
        public BinaryTree<T> Remove(T val)
        {
            BinaryTree<T> removeTree = Find(this, val);

            if(!(removeTree is null))
                return RemoveTree(removeTree);
            
            return null;
        }
        public BinaryTree<T> RemoveTree(BinaryTree<T> removeTree)
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
        private void PreOrder(BinaryTree<T> tree, Queue<T> values)
        {
            if (tree is null) 
                return;

            values.Enqueue(tree.item);
            PreOrder(tree.left, values);
            PreOrder(tree.right, values);
        }
        private BinaryTree<T> PreOrderLastLeftTree(BinaryTree<T> tree)
        {
            if (!(tree.left is null))
                return PreOrderLastLeftTree(tree.left);
            else
                return tree;
        }
        public IEnumerator GetEnumerator()
        {
            Queue<T> nums = new Queue<T>();
            PreOrder(this, nums); 

            while(nums.Count != 0)
                yield return nums.Dequeue();
        }
        #endregion
        public override string ToString()
        {
            Queue<T> nums = new Queue<T>();
            PreOrder(this, nums);

            return $"Tree: {string.Join(',', nums)}";
        }
    }
}
