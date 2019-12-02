using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    class thongkelopview
    {
        tkelopbuss l = new tkelopbuss();
        public void hienthisv()
        {
           
        a:
            int i = 1;
            Console.Write("nhập mã lớp cần kiếm thông tin sinh viên:");
            string x = Console.ReadLine();
            if (l.ktra(x) == true)
            {
                Console.WriteLine("mã lớp không tồn tại mời nhập lại");
                goto a;
            }
            Console.WriteLine();
            Console.Write("\t\tdanh sách sinh viên trong lớp có tên :"); l.hientenlop(x); Console.Write("\t có ma lớp:{0}",x);
           
            Console.WriteLine();
            Console.WriteLine("stt\tmã lớp\t mã sv\t tên sinh viên\t   giới tính\t quê quán\tngày sinh\t       số điện thoại");
            foreach (string a in l.ds(x))
            {
                Console.Write(i);
                Console.WriteLine(a);
                i++;
            }
        }
        public void timkiemsv()
        {
            int i = 1;
        b:
            Console.Write("nhập mã sinh viên cần kiếm trong khoa:");
            string x = Console.ReadLine();
            if (l.ktra1(x) == false)
            {
                Console.WriteLine("mã sinh viên không tồn tại mời bạn nhập lại");
                goto b;
            }
            Console.WriteLine("\t\t\t\tthông tin sinh viên cần tìm có trong khoa");
            foreach (string s in l.ds(x))
            {
                Console.WriteLine(i + "\t" + s);
            }
        }
        public void menu()
        {
            Console.SetWindowSize(145, 44);
            bool end = false;
            while (!end)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n");
                Console.WriteLine("\t\t\t╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t║█╔════════════════════════════════════════════════════════════════════════════════════════════╗█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC THỐNG KÊ SINH VIÊN LOP    ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Thống Kê SV Theo Mã Lớp  ║ ║ 2 ║                             ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Tìm Thông Tin Sinh Vien  ║ ║ 4 ║                          ║               ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝══════════════════════════╝               ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 5 ║                          ║                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ╚═══╝══════════════════════════╝                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 6 ║ Quay Lại Menu Chính      ║                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ╚═══╝══════════════════════════╝                                 ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█╚════════════════════════════════════════════════════════════════════════════════════════════╝█║");
                Console.WriteLine("\t\t\t╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.Write("chọn bài:");
                string x = Console.ReadLine();
                switch (x)
                {
                    case "1": Console.ForegroundColor = ConsoleColor.Red; hienthisv(); break;
                    //case "2": Console.ForegroundColor = ConsoleColor.Blue; demsosv(); break;
                    case "3": Console.ForegroundColor = ConsoleColor.Cyan; timkiemsv(); break;
                    //case "4": Console.ForegroundColor = ConsoleColor.Green; timkiem(); break;
                    //case "5": Console.ForegroundColor = ConsoleColor.Yellow; sua(); break;
                    case "6": end = true; break;
                }
                Console.ReadKey();
            }

        }
    }
}
