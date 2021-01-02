using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree
{
    public class BinareTreeNode<T>
        where T:IComparable<double>
    {
        public BinareTreeNode(double value)
        {
            Value = value;
        }
        public BinareTreeNode<T> Left { get; set; }
        public BinareTreeNode<T> ParentNode { get; set; }
        public BinareTreeNode<T> Right { get; set; }
        public double Value { get; set; }
        public double CompareTo(double other)
        {
            return Value.CompareTo(other);
        }
    }
}
