using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefBookMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.DisplayInfo();

            int key = -1;
            do
            {
                key = menu.getTask(menu.MAIN_MENU);
            } while (key != 0);
            
        }
    }
}
