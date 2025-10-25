namespace DataStructures.SelfStudy
{
    internal class Delegates
    {
        public class MethodsList
        {
            public void SimpleFunc()
            {
                Console.WriteLine("Very Simple func");
            }
            public void AnotherVerySimpleFunc()
            {
                Console.WriteLine("Another very simple func");
            }
        }
        // Delegate with no args and no return type
        private delegate void SimpleDelegate();
        private delegate void DelegateList();

        // Here we define a delegate that takes two paramenters - two integers. The parameters passed to the delegate
        // by the caller will be passed on to the method. 
        private delegate void DelegateWithArgs(int x, int y);
        private delegate string BoolDelegate(bool isDifficult);

        private Action<int, string> actionDelegate;

        public static void Main()
        {
            bool isHard = true;


            // Declare variable as type simpleDelegate and assign it the value of SimplePrint method
            SimpleDelegate m_simpleDelegate = SimplePrint;
            // Call SimplePrint through delegate
            m_simpleDelegate();

            // Add another method to the delegate stack. This is effectively adding another method to a sequential list of methods to be invoked. 
            m_simpleDelegate += SimplePrint2;

            // Invoke the delegate again
            m_simpleDelegate(); // This time, it will call both registered methods

            // We can unregister callbacks from the delegate instance
            m_simpleDelegate -= SimplePrint; // Removes SimplePrint from the m_SimpleDelegates invocation list.
            
            // We can also remove callbacks from the invocation list like so

            // Register callback
            DelegateWithArgs m_DelegateWithArgs = MultiplyAndWrite;
            // Invoke callback
            m_DelegateWithArgs(5, 2); // Pass args to delegate, which passes them on to the callback

            // One way of adding a list of methods to a delegate
            MethodsList m_MethodsList = new MethodsList();
            DelegateList m_Delegate1 = m_MethodsList.SimpleFunc;
            DelegateList m_Delegate2 = m_MethodsList.AnotherVerySimpleFunc;
            DelegateList m_AllDelegatesList = m_Delegate1 + m_Delegate2;
            m_AllDelegatesList();

            // We can even unregister callbacks like this
            DelegateList m_SingleDelegate = (m_AllDelegatesList - m_Delegate1)!;

            // We can simplify the assignment of delegates using anonymous functions and lambda expressions
            SimpleDelegate m_simpleDelegateAnonymous = () => Console.WriteLine("This msg is printed from an anonymous method registed to a delegate");
            BoolDelegate m_delegateWithArgsAnonymous = (isHard) =>
            {
                if (isHard)
                {
                    return "Sometimes programming can be difficult";
                }
                    return "Programming is so easy";
            };

            // Here, we use the delegate we defined above using an anonymous function, a lambda expression and a function body
            Console.WriteLine(m_delegateWithArgsAnonymous(false));



        }
        private static void WriteBoolean(bool isDifficult)
        {
            Console.WriteLine("The downside with registering anonymous functions to delegates is that they give you no option to unregister from them:");
        }
        public static void MultiplyAndWrite(int i, int x)
        {
            Console.WriteLine($"Multiplying {i} with {x} gives: {i * x}");
        }

        public static void SimplePrint()
        {
            Console.WriteLine("Hello from simple Delegate");
        }

        public static void SimplePrint2()
        {
            Console.WriteLine("Another method call from simple delegate");
        }


    }
}
