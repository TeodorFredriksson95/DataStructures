using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinaryTree
{
    public class TreeExample
    {
        public Tree<int> myTree;
        public List<Tree<int>.Node> traversedNodes = new();

        public void Main()
        {
            CreateRandomTree();
        }
        private void CreateRandomTree()
        {
            myTree = new Tree<int>();
            myTree.Root = CreateRandomNode(0, 4, 4);
        }

        private Tree<int>.Node CreateRandomNode(int iDepth, int iMaxDepth, int iMaxChildren)
        {
            // Create new node
            Random rnd = new Random();
            Tree<int>.Node node = new Tree<int>.Node
            {
                Value = rnd.Next(0, 100)
            };

            // Create children
            if (iDepth < iMaxDepth) // given our callers current parameters, depth will be at max 4.
            {
                int iNumChildren = rnd.Next(0, iMaxChildren);
                if (iNumChildren > 0) // These two lines are from the teachers example. Imo, this is a bit strange at first sight.
                                      // We Since it's a binary tree, we only want at max 2 children. The RND func, same as unity's version,'
                                      // will exclude the max range, and include the min range as possible return values. I dont see the need for
                                      // this if statement. If we change the min param to 1 instead of 0, we know we will always get the values 1 or 2.
                                      // Is there some kind of reasoning here where we want to do some calcs in case we return 0 children, that im missing?

                                      // UPDATE: Well ok i now realize that by allowing the RND to return a value of 0, we allow for leaf nodes above the specified max depth.
                                      // If we force the values to be between 1 and 2 always, then every node until max depth is reached would have 2 children. Maybe thats good though,
                                      // depending on use case?

                // UPDATE 2: I tried setting the iNumchildren to be between 2 and 3. Given a certain insertion order (need to research)
                // It does give a pretty balanced tree. A very balanced tree, in fact. But, upon scratching the surface, this balance depends
                // on insertion order. I must investigate further.
                {
                    node.nodeChildren = new Tree<int>.Node[iMaxChildren];
                    for (global::System.Int32 i = 0; i < iMaxChildren; i++)
                    {
                        node.nodeChildren[i] = CreateRandomNode(iDepth + 1, iMaxDepth, iMaxChildren);
                    }
                }
            }

            return node;
        }
    }
}
