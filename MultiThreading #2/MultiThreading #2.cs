using System;
using System.Collections.Generic;
using System.Diagnostics; // for counting the number of threads
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //must add this for multiple threads

namespace MultiThreading__2
{
    internal class Program
    {
        // checked if the number is a prime number
        static void PrimeNumbers(int num, string ThreadName)
        {
            bool prime = true;
            for (int i =2; i < Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                Console.WriteLine(ThreadName + ": " + num);
            }
        }

        static void Main(string[] args)
        {
            Thread Main = Thread.CurrentThread;                            // <-- not neccessary for counting threads just good practice
            Console.WriteLine(Process.GetCurrentProcess().Threads.Count); //  prints the number of threads available (atm its 7)
                                                                         //   this means we can run up to 7 processes simultaneously although its a good idea not to run that many at the same time

            for (int i = 2; i < 999; i+=5)
            {
                Thread thread1 = new Thread(() => PrimeNumbers(i, "thread1")); thread1.Start(); // invoke the threads and start them
                Thread thread2 = new Thread(() => PrimeNumbers(i + 1, "thread2")); thread2.Start();
                Thread thread3 = new Thread(() => PrimeNumbers(i + 2, "thread3")); thread3.Start();
                Thread thread4 = new Thread(() => PrimeNumbers(i + 3, "thread4")); thread4.Start();
                Thread thread5 = new Thread(() => PrimeNumbers(i + 4, "thread5")); thread5.Start();
            }

            // this allows us to check 5 different numbers at a time and while it doesnt take 1/5th the amount of time (still have to load values to threads
           //  it is still significantly faster.

            Console.ReadKey();
        }
    }
}
