using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefBookMS
{
    class Program
    {
        static string RefBookName = "refbook.dat";
        static string RefIndex = "index.dat";

        static Repository repository = new Repository();

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.DisplayInfo();

            int key = -1;
            do
            {
                processTask(menu.getTask(menu.MAIN_MENU));
            } while (true);
        }

        private static void processTask(int taskID)
        {
            switch (taskID)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    createReferenceBook(RefBookName);
                    break;
                case 2:
                    displayRecords();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Write("Введите год открытия вклада (ГГГГ): ");
                    int year = int.Parse(Console.ReadLine());
                    //displayRecords(year);
                    break;
                case 4:
                    //createRecord();
                    break;
                case 5:
                    Console.Write("Введите номера депозитов: ");
                    string numbers = Console.ReadLine();
                    //deleteRecords(numbers);
                    break;
                case 6:
                    //updateRecord();
                    break;
            }
        }

        private static void displayRecords()
        {
            List<string> indexes = new List<string>();
            if (!File.Exists(RefIndex))
            {
                // Message: You need to create database!
                return;
            }

            indexes = File.ReadAllLines(RefIndex).ToList();
            Deposit deposit = new Deposit();

            Console.WriteLine(GetReportHeader());

            foreach (string item in indexes)
            {
                string[] points = item.Split(';');
                deposit = (Deposit)repository.GetRecord(RefBookName, long.Parse(points[1]), int.Parse(points[2]));
                Console.WriteLine(GetReportRec(deposit));
            }

            Console.WriteLine(new string('-', 106));
        }

        private static string GetReportRec(Deposit deposit)
        {
            return $"| {deposit.GetDepositNumber(), 10} " +
                $"| {deposit.GetFirstName(), 25} " +
                $"| {deposit.GetLastName(), 25} " +
                $"| {deposit.GetOpeningDate(), 12} " +
                $"| {deposit.GetBalance(), 18} |";
        }

        private static string GetReportHeader()
        {
            return $"| {"Account #", 10} " +
                $"| {"First Name", 25} " +
                $"| {"Last Name", 25} " +
                $"| {"Opened At", 12} " +
                $"| {"Balance", 18} |";
        }

        private static void createReferenceBook(string dbName)
        {
            repository.CreateDB(dbName);
        }
    }
}
