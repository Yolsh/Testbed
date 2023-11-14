using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading_Practice
{
    internal class Program
    {
        public static void CountDown() //Count down from 10
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine("Timer #1: " + i + " seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Timer one complete");
        }

        public static void CountUp(string Name) //Count up to 10
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(Name + ": " + i + " seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Timer two complete");
        }

        static void Main(string[] args)
        {
            // Threading allows to run multiple Code paths in conjunction
            // when a program is created it starts on the "main" Thread
            // need System.Threading at the top of program in order to multi thread

            // traditionally this would only run one after the other
            //CountDown();
            //CountUp();

            //but this will run both timer simultaneously
            Thread Main_thread = Thread.CurrentThread; //assigns the current thread that is running to a variable
            Main_thread.Name = "Main Thread"; // can assign each thread a name

            // can create more threads
            Thread thread1 = new Thread(CountDown); // invoke new threads and tell them what subroutine they are incharge of
            Thread thread2 = new Thread(() => CountUp("Timer #2")); //you can pass variables into the procedures like this

            // then we have to start the thread
            thread1.Start();
            thread2.Start(); // and we see the timers run at the same time.

        }
    }
}
