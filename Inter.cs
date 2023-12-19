using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwork9_dispetcher
{
    internal class Inter
    {
        public static void proc()
        {
            Console.Clear();
            Console.SetCursorPosition(34, 0);
            Console.WriteLine("Диспетчер задач");
            Console.WriteLine(" Процесс");
            Console.SetCursorPosition(40, 1);
            Console.WriteLine("Опер. Память");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Физ. Память");
            Process[] pross = Process.GetProcesses();
            int max = 1;
            foreach (Process p1 in pross)
            {
                Console.WriteLine(" " + p1.ProcessName);
                max++;
                Console.SetCursorPosition(40, max);
                Console.WriteLine(Math.Round(Convert.ToDouble(p1.PagedSystemMemorySize64) / 1048576, 2) + " Мб");
                Console.SetCursorPosition(60, max);
                Console.WriteLine(Math.Round(Convert.ToDouble(p1.WorkingSet64) / 1048576, 2) + " Мб");

            }
            int pos = str.strel(max);
            try
            {
                podr(pos, pross);
            }
            catch
            {
                erorr();
                proc();
            }
        }
        private static void podr(int pos, Process[] pross)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(pross[pos - 2].ProcessName + "\r\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Класс приоритета потока:\t" + pross[pos - 2].PriorityClass);
                Console.WriteLine("Оперативная память:     \t" + Math.Round(Convert.ToDouble(pross[pos - 2].PagedSystemMemorySize64) / 1048576, 2) + " Мб");
                Console.WriteLine("Физичиская память:      \t" + Math.Round(Convert.ToDouble(pross[pos - 2].WorkingSet64) / 1048576, 2) + " Мб");
                Console.WriteLine("Время старта:           \t" + pross[pos - 2].StartTime);
                Console.WriteLine("Время работы:           \t" + pross[pos - 2].TotalProcessorTime);
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    if (key.Key == ConsoleKey.D)
                    {
                        pross[pos - 2].Kill();
                        proc();
                    }
                    if (key.Key == ConsoleKey.Delete)
                    {
                        pross[pos - 2].Kill(entireProcessTree: true);
                        proc();
                    }
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        proc();
                    }
                }

                catch
                {
                    erorr();
                }
            }
        }
        private static void erorr()
        {
            Console.Clear();
            Console.WriteLine("ошибка: нет доступа, для продолжения нажмите любую клавишу.");
            ConsoleKeyInfo key = Console.ReadKey();
        }
    }
    internal enum klaw
    {
        d,
        delete,
        backspace // мне было лень заморачиваться с enum, извиняюсь
    }
    internal class str
    {
        public static int pos = 2;
        public static int strel(int max)
        {
            while (true)
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(">");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(" ");
                if (key.Key == ConsoleKey.UpArrow && pos != 2)
                {
                    pos--;
                }
                if (key.Key == ConsoleKey.DownArrow && pos != max)
                {
                    pos++;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }
            }
            return pos;
        }
    }
}
