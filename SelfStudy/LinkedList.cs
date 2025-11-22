using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SelfStudy
{

    public class LinkedListPractice
    {
        public static void Main()
        {
            System.Collections.Generic.LinkedList<int> list = new();
            list.AddLast(5);
            list.AddFirst(2);

            LinkedList<int> linkedList = new LinkedList<int>();
            //linkedList.AddFirst(5);
            //linkedList.AddLast(2);
            //linkedList.InsertAt(1, 10);


            linkedList.Add(2);
            LLNode<int> node = linkedList.Find(2);
            linkedList.AddAfter(node, 20);
            node = linkedList.Find(20);
            linkedList.AddBefore(node, 10);
        }
    }

    public class LLNode<T>
    {
        public LinkedList<T> list;
        public LLNode<T> next;
        public LLNode<T> prev;
        public T item;
        //public int Count => next == null ? 1 : next.Count + 1; // Recursive

        public LLNode(T value)
        {
            item = value;
        }

        public LLNode(LinkedList<T> list, T value)
        {
            this.list = list;
            item = value;
        }

        public LinkedList<T>? List
        {
            get { return list; }
        }

        public LLNode<T>? Next
        {
            get { return next == null || next == list.head ? null : next; }
        }

        public LLNode<T>? Previous
        {
            get { return prev == null || this == list.head ? null : prev; }
        }

        public T Value
        {
            get { return item; }
            set { item = value; }
        }
    }

    public class LinkedList<T>
    {

        public LLNode<T> head;

        #region Properties
        //public int Count => head.Count;
        public int Count = 0;
        public LLNode<T> First
        {
            get { return head; }
        }
        public LLNode<T> Last
        {
            get { return head.prev; }
        }

        public void Add(T value)
        {
            AddLast(value);
        }
        public LLNode<T> AddLast(T value)
        {
            LLNode<T> result = new LLNode<T>(this, value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(head, result);
            }
            return result;
        }

        public void RemoveLast()
        {
            head.prev = head.prev.prev;
            head.prev.next = head;
        }

        private void InternalInsertNodeToEmptyList(LLNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            Count++;
            // Do i really need to add count++ here if i'm doing recursive count checks in LLnode?
        }

        private void InternalInsertNodeBefore(LLNode<T> node, LLNode<T> newNode)
        {
            newNode.next = node; // This makes it circular. We set the last nodes Next value to the head, making it circular.
            newNode.prev = node.prev; // Until we set this, the the head is still going to reference the "next to last" node as the last element. We are effectively moving the pointer here, to the newly added (at the end) node.
            node.prev.next = newNode; // when node is head, this is like doing
            node.prev = newNode;
            Count++;
        }

        public LLNode<T> AddAfter(LLNode<T> node, T value)
        {
            // TODO: Validations on Node before insertion

            LLNode<T> result = new LLNode<T>(node.list, value);

            InternalInsertNodeBefore(node.next, result);
            return result;

            // Need to create Find method in order to supply the proper LLnode<T> node param in caller
        }

        public LLNode<T> AddBefore(LLNode<T> node, T value)
        {
            LLNode<T> result = new LLNode<T>(node.list, value);
            InternalInsertNodeBefore(node, result);
            return result;
        }

        public LLNode<T> Find(T value)
        {
            LLNode<T> node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.item, value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
                // This part has gotta be here in order to handle nullable types
                // Because there is 100% a scenario where we use a linked list with, say, strings, but some
                // nodes might contain null values, but still hold references to neighbouring nodes
                else
                {
                    do
                    {
                        if (node.item == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
            }
            return null;
        }

        #endregion

        //Indexer
        public T this[int index]
        {
            get
            {
                int iCount = 0;
                LLNode<T> e = head;
                while (e != null)
                {
                    if (iCount == index)
                    {
                        return e.item;
                    }
                    iCount++;
                    e = e.next;
                }
                throw new IndexOutOfRangeException();
            }
        }


        //        public void AddFirst(T value)
        //        {
        //            head = new Element { elementValue = value, next = head, previous = null };
        //            first = head;
        //        }

        //        public void InsertAt(int index, T value)
        //        {

        //            // LinkedLists are a chain of lists. Each element knows about the element before and after its own position - nothing else
        //            // therefore, when we want to insert an element at a certain position, we cut the ties from the original element
        //            // at that position, change the "next" reference from the original elements previous elements to the new one, 
        //            // and reference the original element as the new elements next reference. 

        //            int iCounter = 0;
        //            Element e = head; // start iteration at head
        //            Element newElement = new Element { elementValue = value }; // element to be added
        //            Element tempElement; // temporary storage of the element that needs to shift a position
        //            while (e != null)
        //            {
        //                if (iCounter == index -1) // Stop one index from the original element that is to be cut
        //                {
        //                    tempElement = e.next; // Store the original elements value
        //                    newElement.previous = e;
        //                    e.next = newElement; // This is why we stop one index before the position where we are actually inserting the element.
        //                                         // Because now we link the previous element to this new element.

        //                    tempElement.previous = newElement;
        //                    e.next.next = tempElement; // Because we're techically one position behind in the order of elements, we need to assign
        //                                               // the next elements next reference to the original element.


        //                    // TODO: Implement "previous" capabilites.
        //                    // LinkedLists should implement previous capabilites. It is here that we would assign the new elements previous reference,
        //                    // and update the original elements previous reference to the new element.
        //                }
        //                e = e.next;
        //                iCounter++;
        //            }
        //        }

        //        public void AddLast(T value)    
        //        {
        //            Element e = head;
        //            while (e.next != null)
        //            {
        //                e = e.next;
        //            }
        //            if (e.next == null)
        //            {
        //                e.next = new Element { elementValue = value };
        //                e.previous = e;
        //            }

        //        }

        //        public void RemoveFirst()
        //        {
        //            head = head != null ? head.next : null;
        //        }

        //        public void RemoveAt(int index)
        //        {
        //            int iCount = 0;
        //            Element e = head;
        //            while (e != null)
        //            {
        //                if (iCount == index - 1)
        //                {
        //                    e.next = e.next != null ? e.next.next : null;

        //                    break;
        //                }
        //                iCount++;
        //                e = e.next;
        //            }
        //        }
    }
}
