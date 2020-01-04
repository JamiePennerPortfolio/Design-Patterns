﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SingletonDll;
using System.Diagnostics;

namespace ThreadingDemo
{
    public class ExerciseThreads
    { 
        public static void ThreadLogger()
        {
            for (int nIter = 0; nIter < 100; nIter++)
                {
                    SingletonLogger.Instance.LogMsg(string.Format("Writing Message {0}", nIter));
                }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<Thread> threadlist = new List<Thread>();

            for (int nThread = 0; nThread < 5; nThread++)
            {
                threadlist.Add(new Thread(ExerciseThreads.ThreadLogger));
                threadlist[nThread].Start();
            }

            foreach (Thread t in threadlist)
            {                
                t.Join();                
            }
            SingletonLogger.Instance.Close();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
