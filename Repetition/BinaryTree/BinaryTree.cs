using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Repetition.BinaryTree
{

    public class BinaryTree<T>
    {
        public class Node
        {
            public T Value;
            public Node Left;
            public Node Right;
            public override string ToString()
            {
                return "Node: " + Value;
            }
        }

        public Node Root;

        public int Depth => CalculateDepth(Root, 0);

        public static int CalculateDepth(Node node, int depth)
        {
            if (node == null)
                return depth;

            return Math.Max(CalculateDepth(node.Left, depth + 1), CalculateDepth(node.Right, depth +1));
        }

        public void CreateBinaryTree()
        {

        }

        public void TraverseTree_LevelOrder(Node node, ref List<T> valueList)
        {
            if (node == null) return;

            Queue<Node> queue = new();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                valueList.Add(current.Value);

                if (node.Left != null) queue.Enqueue(current.Left);
                if (node.Right != null) queue.Enqueue(current.Right);

            }
        }
    }
}
