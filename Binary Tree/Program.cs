using System;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<double>();
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(60);
            tree.Insert(25);
            tree.Insert(31);
            tree.Insert(29);
            tree.Insert(32);
            tree.GetBalance();
            Console.WriteLine(tree.Head.Value);
        }
    }
}
