using System;
using System.IO;

namespace Bars
{
    class Program
    {
        static void Main()
        {  
            LocalFileLogger<int> t = new LocalFileLogger<int>("text.txt");
            t.LogInfo("hello");
            t.LogWarning("world");
            t.LogError("ACHTUNG!!", new Exception());

            LocalFileLogger<string> st = new LocalFileLogger<string>("text.txt");
            st.LogInfo("hello");
            st.LogWarning("ACHTUNG!!");
            st.LogError("world", new Exception());

            LocalFileLogger<Example> example = new LocalFileLogger<Example>("text.txt");
            example.LogInfo("hello");
            example.LogWarning("ACHTUNG!!");
            example.LogError("world", new Exception());
        }
    }
    internal interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }
    internal class LocalFileLogger<T> : ILogger
    {
        private string path;
        public LocalFileLogger(string path)
        {
            this.path = path;
        }
        public void LogInfo(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"[Info]: [{typeof(T).Name}] : {message}");
            };
        }
        public void LogWarning(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"[Warning] : [{typeof(T).Name}] : {message}");
            };
        }
        public void LogError(string message, Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
            };
        }
    }
    class Example
    {
        public string Message 
        { 
            get 
            { 
                return Message; 
            }
            private set
            {
                Message = value;
            }
        }
        public void Print()
        {
            Message = "Hello World";
            Console.WriteLine("Message");
        }
    }
}
