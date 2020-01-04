using System;
using System.IO;
using System.Threading;

namespace SingletonDll
{
    public class SingletonLogger
    {
        private static SingletonLogger _instance = null;
        private static object MyLock = new object();
        const string LogFile = "log.txt";
        private StreamWriter streamwriter;
        private static SingletonLogger _Instance = null;
        private object _streamsync = new object();
        private SingletonLogger(string LogFile)
        {
            streamwriter = new StreamWriter(File.Create(LogFile));
        }
        public void LogMsg(string message)
        {
            if (_Instance == null)
            {
                lock (_streamsync)
                {
                    if (_Instance == null)
                    {
                        streamwriter.WriteLine("{0} - {1}", DateTime.Now, message);
                        Thread.Sleep(10);
                    }
                }
            }
            
        }
        public void Close()
        {
            streamwriter.Close();
        }
        public static SingletonLogger Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (MyLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonLogger(LogFile);      
                        }
                    }   
                }
                return _instance;
            }        
        }
    }
}
