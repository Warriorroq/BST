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
            return !(Find(this, item) is null);
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
        private void PreOrder(BinaryTree<T> tree, Queue<T> values)
        {
            if (tree is null) 
                return;

            values.Enqueue(tree.item);
            PreOrder(tree.left, values);
            PreOrder(tree.right, values);
        }
        private Queue<T> PreOrder(BinaryTree<T> tree)
        {
            Queue<T> values = new Queue<T>();
            if (tree is null)
                return null;

            values.Enqueue(tree.item);
            PreOrder(tree.left, values);
            PreOrder(tree.right, values);
            return values;
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
        #region Balance Tree
        public void CrismasTree()
        {
            //Ne beite ia tolko eto pridumal
            List<T> numsList = new List<T>(PreOrder(this));
            numsList.Sort();
            item = numsList[(int)((float)numsList.Count / 2 + 0.5f)];
            numsList.Remove(item);
            left = null;
            right = null;
            foreach (var a in numsList)
                Add(a);
        }
        #endregion
        public override string ToString()
        {
            return $"Tree: {string.Join(',', PreOrder(this))}";
        }
    }
}
