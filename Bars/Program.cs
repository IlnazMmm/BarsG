using System;

namespace Bars
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task();
            task.OnKeyPressed += (sender, symbol) => Console.WriteLine($"\nсимвол - {symbol}");
            task.Run();
        }
    }
    class Task
    {
        public EventHandler<char> OnKeyPressed; 
        public void Run()
        {
            var symbol = Console.ReadKey();
            OnKeyPressed?.Invoke(this, symbol.KeyChar);
            while (symbol.KeyChar != 'c')
            {
                symbol = Console.ReadKey();
                OnKeyPressed?.Invoke(this, symbol.KeyChar);
            }
        }
    }

}
