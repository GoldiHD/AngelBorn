using AngelBorn.World;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AngelBorn.Tools
{
    class CW
    {
        private static object Key = new object();

        public static void WriteLine(string text)
        {
            lock (Key)
            {
                Console.WriteLine(text);
            }
        }

        public static void WriteLine(string text, int x, int y)
        {
            lock (Key)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(text);
            }
        }

        public static void Write(string text)
        {
            lock (Key)
            {
                Console.Write(text);
            }
        }

        public static void Write(string text, int x, int y)
        {
            lock (Key)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(text);
            }
        }

        public static void Clear()
        {
            lock (Key)
            {
                Console.Clear();
            }
        }

        public static Cord GetPos()
        {
            lock (Key)
            {
                return new Cord { X = Console.CursorLeft, Y = Console.CursorTop };
            }
            
        }

        public static ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo temp;
            lock (Key)
            {
                temp = Console.ReadKey();
            }
            return temp;
        }

        public static void WriteSlowNL(string input, int delay)
        {
            lock (Key)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(input[i]);
                    Thread.Sleep(delay);
                }
                Console.WriteLine();
            }
        }

        public static void SetPos(int x, int y)
        {
            lock(Key)
            {
                Console.SetCursorPosition(x, y);
            }
        }

        public static void WriteSlow(string input, int delay)
        {
            lock (Key)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(input[i]);
                    Thread.Sleep(delay);
                }
            }
        }

        public static string Readline()
        {
            string input;
            lock (Key)
            {
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
