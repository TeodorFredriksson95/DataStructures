using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Repetition.BinaryTree
{
    public class BinarySearchTree : BinaryTree<int>
    {
        public virtual void Add(int value)
        {
            Root = Insert(Root, value);
        }

        protected virtual Node Insert(Node node, int value)
        {
            if (node == null) 
                return new Node { Value = value };

            if (value < node.Value)
                node.Left = Insert(node.Left, value);

            else if (value > node.Value)
                node.Right = Insert(node.Right, value);

            return node;
        }

        public static Node Invert(Node node)
        {
            if (node == null) return node;

            Node temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;

            Invert(node.Left);
            Invert(node.Right);

            return node;
        }
    }

    public class RunBinarySearchTree
    {
        public static void Main()
        {

            // Create binary search tree
            BinarySearchTree bst = new();
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                bst.Add(rnd.Next(0, 50));
            }

            BinarySearchTree.Invert(bst.Root);
        }
    }

}
