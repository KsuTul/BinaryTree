using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_Tree
{
    public class BinaryTree<T>
        where T : IComparable<double>
    {
        public BinareTreeNode<T> Head;
        public int Count;

        public BinaryTree()
        {
            Count = 0;
        }
        public void Insert(double item)
        {
            if (Count == 0)
            {
                Head = new BinareTreeNode<T>(item);
            }
            else
            {
                AddNode(Head, item);
            }

            Count++;
        }

        public void RemoveElement(double item)
        {
            var foundItem = Contains(item);

            if (foundItem == null)
            {
                throw new Exception("Такого элемента нет");
            }
            if(foundItem.Left == null && foundItem.Right == null)
            {
                if (foundItem.Value.CompareTo(foundItem.ParentNode.Value) < 0)
                {
                    foundItem.ParentNode.Left = null;
                }
                else if (foundItem.Value.CompareTo(foundItem.ParentNode.Value) > 0)
                {
                    foundItem.ParentNode.Right = null;
                }
            }

            if(foundItem.Right == null && foundItem.Left !=null)
            {
                foundItem.Left.ParentNode = foundItem.ParentNode;
                if (foundItem.Left.Value.CompareTo(foundItem.ParentNode.Value) < 0)
                {
                    foundItem.ParentNode.Left = foundItem.Left;
                }
                else if(foundItem.Left.Value.CompareTo(foundItem.ParentNode.Value) > 0)
                {
                    foundItem.ParentNode.Right = foundItem.Right;
                }
            }
            if (foundItem.Left == null && foundItem.Right != null)
            {
                foundItem.Right.ParentNode = foundItem.ParentNode;
                if (foundItem.Right.Value.CompareTo(foundItem.ParentNode.Value) < 0)
                {
                    foundItem.ParentNode.Left = foundItem.Right;
                }
                else if (foundItem.Right.Value.CompareTo(foundItem.ParentNode.Value) > 0)
                {
                    foundItem.ParentNode.Right = foundItem.Right;
                }
            }
            if (foundItem.Left != null && foundItem.Right!=null)
            {
                if (foundItem.Right.Left != null || foundItem.Left != null)
                {
                    var currTree = foundItem.Right;

                    while (currTree.Left != null)
                    {
                        currTree = currTree.Left;
                    }

                    if (foundItem.Value.CompareTo(foundItem.ParentNode.Value) < 0)
                    {
                        foundItem.ParentNode.Left = currTree;
                        if (currTree.Value.CompareTo(currTree.ParentNode.Value) < 0)
                        {
                            currTree.ParentNode.Left = null;
                        }
                    }
                    else if (foundItem.Right.Value.CompareTo(foundItem.ParentNode.Value) > 0)
                    {
                        foundItem.ParentNode.Right = currTree;
                        if (currTree.Value.CompareTo(currTree.ParentNode.Value) > 0)
                        {
                            currTree.ParentNode.Right = null;
                        }
                    }

                    currTree.Left = foundItem.Left;
                    currTree.Right = foundItem.Right;
                    currTree.ParentNode = foundItem.ParentNode;
                    foundItem.Left = currTree;
                }
            }

            Count--;
        }

        public BinareTreeNode<T> Contains(double item)
        {
            var current = Head;
            while (current != null)
            {
                var result = item.CompareTo( current.Value);
                BinareTreeNode<T> parent;
                if (result < 0)
                {
                    parent = current;
                    current = parent.Left;
                }
                else  if (result > 0)
                {
                    parent = current;
                    current = parent.Right;
                }
                else
                {
                    break;
                }
               
            }
            return current;
        }

        public int GetSize()
        {
            return Count;
        }

        public void Clear()
        {
            ClearOneByOne(Head);
            Head = null;
            Count = 0;
        }
        private void ClearOneByOne(BinareTreeNode<T> node)
        {
            var current = node;
            if (current.Left != null)
            {
                ClearOneByOne(current.Left);
            }
            if (current.Right != null)
            {
                ClearOneByOne(current.Left);
            }
            node.Left = null;
            node.Right = null;
            node.ParentNode = null;
            node.Value = default;
        }

        public void PrintList()
        {
            var result = new List<double>();
            GetRoundTree(Head, result);
            var orderedEnumerable = result.OrderBy(x => x);
            foreach (var res in orderedEnumerable)
            {
                Console.WriteLine(res);
            }
        }

        public void PrintListDesc()
        {
            var result = new List<double>();
            GetRoundTree(Head, result);
            var orderedEnumerable = result.OrderByDescending(x => x);
            foreach (var res in orderedEnumerable)
            {
                Console.WriteLine(res);
            }
        }

        private static void GetRoundTree(BinareTreeNode<T> node, IList<double> list)
        {
            var current = node;
            list.Add(current.Value);
            if (current.Left !=null)
            {
                GetRoundTree(current.Left, list);
            }
            if (current.Right != null)
            {
                GetRoundTree(current.Right, list);
            }
        }

        public bool IsEmpty()
        {
            return Head == null && Count == 0;
        }

        public void GetBalance()
        {
            var result = new List<double>();
            GetRoundTree(Head, result);
            var min = GetMin(Head);
            var max = GetMax(Head);
            var middle = min + (max-min) / 2;
            Head = new BinareTreeNode<T>(middle);
            Count = 1;
            foreach (var res in result)
            {
              Insert(res);
            }
        }

        private double GetMin(BinareTreeNode<T> node)
        {
            var current = node;
            while (current.Left!=null)
            {
                current = current.Left;
            }
            return current.Value;
        }
        private double GetMax(BinareTreeNode<T> node)
        {
            var current = node;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Value;
        }
        private static void AddNode(BinareTreeNode<T>  node, double item)
        {
            if (item.CompareTo(node.Value) == -1)
            {
                if(node.Left == null)
                {
                    node.Left = new BinareTreeNode<T>(item) {ParentNode = node};
                }
                else
                {
                    AddNode(node.Left, item);
                }
            }

            if (item.CompareTo(node.Value) != 1) return;
            if (node.Right == null)
            {
                node.Right = new BinareTreeNode<T>(item) {ParentNode = node};
            }
            else
            {
                AddNode(node.Right, item);
            }
        }
    }
}
