using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinaryTree
{

    public class TreeRepetition
    {
        public void Main()
        {
            Node<int> inteNode = new(5);
            //inteNode.DepthFirstTraversal(inteNode);
        }
    }
    public class Node<T>
    {
        T value;
        Node<T> left;
        Node<T> right;
        Node<T> root;

        public Node(T val)
        {
            value = val;
            left = null;
            right = null;
        }

        public void Main()
        {
            Node<int> intNode = new Node<int>(5); // Root
            Node<int> intNodeA = new Node<int>(33); // A
            Node<int> intNodeB = new Node<int>(52); // B
            Node<int> intNodeC = new Node<int>(20); // C
            Node<int> intNodeD = new Node<int>(100); // D
            Node<int> intNodeE = new Node<int>(2); // E
            Node<int> intNodeF = new Node<int>(36); // F

            // Manual connection between nodes
            intNode.left = intNodeA;
            intNode.right = intNodeB;

            intNodeA.left = intNodeC;
            intNodeA.right = intNodeD;

            intNodeB.left = intNodeE;
            intNodeB.right = intNodeF;

            Console.WriteLine("Manual");
            Node<int>[] nodeArray = intNode.ManualDepthTraversal(intNode);
            Console.WriteLine();

            Console.WriteLine("Recursion");
            intNode.RecursiveDepthTraversal(intNode);

            Node<string> sNodeRoot = new Node<string>("Root");
            Node<string> sNodeA = new Node<string>("A");
            Node<string> sNodeB = new Node<string>("B");
            Node<string> sNodeC = new Node<string>("C");
            Node<string> sNodeD = new Node<string>("D");
            Node<string> sNodeE = new Node<string>("E");
            Node<string> sNodeF = new Node<string>("F");

            sNodeRoot.left = sNodeA;
            sNodeRoot.right = sNodeB;

            sNodeA.left = sNodeC;
            sNodeA.right = sNodeD;

            sNodeB.left = sNodeE;
            sNodeB.right = sNodeF;

            Console.WriteLine();
            Console.WriteLine("Manual Breadth First");
            sNodeRoot.ManualBreadthFirstTraversal(sNodeRoot);

            //NOTE: Breadth-First binary trees DONT mix well with recursion. Recursion leans on stack structures, and Queues work pretty much
            // "the opposite" of that. You'll be clawing your eyes out trying to implement a recursive func on a queue structure. Just use
            // iterative logic.
        }

        void ManualBreadthFirstTraversal(Node<T> root)
        {
            if (root == null) return;

            Queue<Node<T>> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                Console.WriteLine("Node value: " + node.value);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);

            }
        }

        void RecursiveDepthTraversal(Node<T> root)
        {
            if (root == null) return;

            Stack<Node<T>> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();
                Console.WriteLine("Node value: " + current.value);

                // Recurse into left stack
                if (current.left != null) RecursiveDepthTraversal(current.left);

                //Recurse into right stack
                if (current.right != null) RecursiveDepthTraversal(current.right);
            }

        }

        // Manual Depth Traversal
        // For the fun of it, we treat this like an interview case where we are expected to return the depth-first values as part of an array
        // I disallow myself to use a List. This will not be efficient, but fuck it. Probably O(n^2)?
        Node<T>[] ManualDepthTraversal(Node<T> root)
        {
            if (root == null) return [];

            Node<T>[] result = new Node<T>[0];
            Node<T> tempNode;

            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();
                Console.WriteLine("Node value: " + current.value);
                tempNode = current;
                Node<T>[] tempArray = new Node<T>[result.Length + 1];
                for (int i = 0; i < result.Length; i++)
                {
                    tempArray[i] = result[i];
                }
                tempArray[tempArray.Length - 1] = tempNode;
                result = tempArray;

                if (current.right != null) stack.Push(current.right);
                if (current.left != null) stack.Push(current.left);
            }

            return result;
        }
    }
}
