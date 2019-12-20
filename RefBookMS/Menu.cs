using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefBookMS
{
    class Menu
    {
        public readonly string[] MAIN_MENU = {
            "(1) Create a new Reference Book",
            "(2) Display all records",
            "(3) Display records up to <Year>",
            "(4) Create a new record",
            "(5) Delete record",
            "(6) Update record",
            "(0) Exit the program"
        };

        public readonly string[] ABOUT = {
            "Reference Book Management System",
            "(the system is based on a binary file)",
            "Created at 2019" 
        };

        public void DisplayInfo()
        {
            Console.WriteLine();

            foreach (string str in ABOUT)
            {
                PrintToConsole(
                    getCenteredString(str, Console.WindowWidth, '\0'),
                    ConsoleColor.Green);
            }

            System.Threading.Thread.Sleep(5000);
        }

        private void PrintToConsole(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{str}");
            Console.ResetColor();
        }

        private string getCenteredString(string str, int windowWidht, char ch)
        {
            return str
                    .PadLeft((windowWidht - str.Length) / 2 + str.Length, ch)
                    .PadRight(windowWidht, ch);
        }

        public int getTask(string[] taskList)
        {
            Console.WriteLine();
            PrintMenu(taskList);

            return Convert.ToInt32(Console.ReadLine());
        }

        private void PrintMenu(string[] menu)
        {
            Console.Clear();
            Console.WriteLine();

            foreach (string item in menu)
            {
                Console.WriteLine($"{new string(' ', 4)}{item}");
            }

            Console.WriteLine($"{new string(' ', 4)}{new string('-', 25)}");
            Console.Write($"{new string(' ', 4)}Print command number: ");
        }

    }
}
