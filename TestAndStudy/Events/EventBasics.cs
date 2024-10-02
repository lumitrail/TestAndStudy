using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAndStudy.Events
{
    internal static class EventBasics
    {
        public class EventHost
        {
            public event EventHandler EmptyEvent;
            public event EventHandler<ExampleEventArgs> EventWithArgs;

            public void RaiseEmptyEvent()
            {
                EmptyEvent?.Invoke(this, EventArgs.Empty);
            }

            public void RaiseArgsEvent(ExampleEventArgs exampleArgs)
            {
                EventWithArgs?.Invoke(this, exampleArgs);
            }
        }

        public class ExampleEventArgs
        {

        }

        internal static class EventBodies
        {
            public static void EmptyEventFollower1(object sender, EventArgs e)
            {
                Console.WriteLine($"sender: {sender}, eventargs: {e}");
            }

            public static void EmptyEventFollower2(object sender, EventArgs e)
            {
                Console.WriteLine("Follower 2");
            }
        }


        public static void DoEmptyEvent()
        {
            var eh = new EventHost();
            eh.EmptyEvent += new EventHandler(EventBodies.EmptyEventFollower1);
            eh.EmptyEvent += new EventHandler(EventBodies.EmptyEventFollower2);

            Console.WriteLine("INPUT: exit, event, subs, unsubs");
            string? consoleInput = "start";
            while (consoleInput == null
                || !consoleInput.ToLower().StartsWith("exit"))
            {
                consoleInput = Console.ReadLine();

                if (consoleInput == null)
                {
                    continue;
                }

                string inputLower = consoleInput.ToLower();

                if (inputLower.StartsWith("event"))
                {
                    eh.RaiseEmptyEvent();
                }
                else if (inputLower.StartsWith("subs1"))
                {
                    eh.EmptyEvent += new EventHandler(EventBodies.EmptyEventFollower1);
                }
                else if (inputLower.StartsWith("unsubs1"))
                {
                    eh.EmptyEvent -= new EventHandler(EventBodies.EmptyEventFollower1);
                }
                else if (inputLower.StartsWith("subs2"))
                {
                    eh.EmptyEvent += new EventHandler(EventBodies.EmptyEventFollower2);
                }
                else if (inputLower.StartsWith("unsubs2"))
                {
                    eh.EmptyEvent -= new EventHandler(EventBodies.EmptyEventFollower2);
                }
            }
        }
    }
}
