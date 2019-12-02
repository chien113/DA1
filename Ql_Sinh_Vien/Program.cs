using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.view;
using Ql_Sinh_Vien.DataAccessLayer;


namespace Ql_Sinh_Vien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
           
            menustart l = new menustart();
            l.Start();
            Console.ReadKey();
            Console.Clear();
            l.Menu();
            Console.ReadKey();

        }
    }
}
