using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefBookMS
{
    class Menu
    {
        const string MAIN_MENU = "" +
            "(1) Create a new Reference Book\n" +
            "(2) Display all records\n" +
            "(3) Display records up to <Year>\n" +
            "(4) Create a new record\n" +
            "(5) Delete record\n" +
            "(6) Update record\n" +
            "(0) Exit the program";

        public int getTask()
        {
            Console.Write(MAIN_MENU);
            return Convert.ToInt32(Console.ReadLine());
        }

        public void processTask(int taskID)
        {
            switch (taskID)
            {
                case 0:
                    break;
                case 1:
                    createReferenceBook();
                    break;
                case 2:
                    displayReferenceBook();
                    break;
                case 3:
                    displayReferenceBook(/*year*/);
                    break;
                case 4:
                    createRecord();
                    break;
                case 5:
                    deleteRecord();
                    break;
                case 6:
                    updateRecord();
                    break;
            }

        }

        private void updateRecord()
        {
            throw new NotImplementedException();
        }

        private void deleteRecord()
        {
            throw new NotImplementedException();
        }

        private void createRecord()
        {
            throw new NotImplementedException();
        }

        private void displayReferenceBook()
        {
            throw new NotImplementedException();
        }

        private void createReferenceBook()
        {
            throw new NotImplementedException();
        }
    }
}
