using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    class thongkechuyennganh
    {
        thongkechuyennganh1 cn = new thongkechuyennganh1();
        public void kiemtrasv()
        {
            int i = 1;
        a:
            Console.Write("nhập mã chuyên ngành để lấy về sinh viên:");
            string x = Console.ReadLine();
            if (cn.ktra(x) == false)
            {
                Console.WriteLine("mã chuyên ngành không tồn tại mời nhập lại");
                goto a;
            }
            Console.Write("\t\tthông tin sinh viên chuyên ngành:");cn.kiemtra(x);Console.WriteLine("\t có mã chuyên ngành:{0}", x);
            Console.WriteLine();
            foreach(string s in cn.thongke(x))
            {
                Console.Write(i);
                Console.WriteLine(s);
                i++;
            }
        }
        public void timkiemsv()
        {
            int i = 1;
            a:
            Console.Write("nhập mã xinh viên cần kiếm:");
            string x = Console.ReadLine();
            if (cn.ktra2(x) == false)
            {
                Console.WriteLine("mã sinh viên không có trong chuyên ngành mời nhập lại");
                goto a;
            }
            Console.WriteLine("\t\t\tthông tin sinh viên có trong chuyên ngành");
            foreach(string s in cn.dssv(x))
            {
                Console.Write(i);
                Console.WriteLine("\t" + s);
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
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC THỐNG CHUYÊN NGÀNH        ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Thống Kê SV Theo Mã CN   ║ ║ 2 ║                             ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Tìm Thông Tin SV CN      ║ ║ 4 ║                          ║               ║█║");
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
                    case "1": Console.ForegroundColor = ConsoleColor.Red; kiemtrasv(); break;
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
