using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinaryTree
{
    public class Tree<T>
    {
        public Node Root;
        public class Node
        {
            public T Value;
            public Node[] nodeChildren;

            public IEnumerable<Node> Children
            {
                get
                {
                    if (nodeChildren != null)
                    {
                        foreach (Node child in nodeChildren)
                        {
                            if (child != null) yield return child;
                        }
                    }
                }
            }
        }
    }
}
