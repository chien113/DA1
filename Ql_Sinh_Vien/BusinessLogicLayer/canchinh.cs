using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class canchinh
    {
        public canchinh(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }
        public void Write(string s, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetWindowSize(120, 50);
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
    }
}
