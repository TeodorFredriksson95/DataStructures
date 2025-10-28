using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SelfStudy
{
    internal class Events
    {
        // Let's play around a bit with Events.
        // Event is a special type of delegate


        public delegate void EventLikeDelegate(object sender, EventArgs e); // We define the delegate to take 2 args, one of typ object, the other of type EventArgs.

        //What do EventArgs look like? What do they do?
        public static void Main()
        {
            Counter c = new Counter();
            c.ThresholdReached += c_ThresholdReached;

        }

        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached");
        }


    }

    public class Counter
    {
        // Eventhandler is a delegate that matches the signature of the delegate above name EventLLikeDelegate
        public event EventHandler ThresholdReached;

        // Lets declare a string variable and see if we can access its contents are part of the event invocation
        public string myName = "Teo";

        protected virtual void OnThresholdReached(EventArgs e)
        {
            // 'this' represents the sender object which is the source of the event, and e represents the 
            ThresholdReached?.Invoke(this, e);
        }

    }

    // Here we define data that belongs to a certain event being raised. We follow the naming patterns by using the EventArgs suffix on our Event data class
    public class ThresholdReachedEventArgs: EventArgs // EventArgs is the base class of all events.
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }

    }
}
    