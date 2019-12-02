using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    public class thongkekhoaview
    {
       
        thongkekhoa1 a = new thongkekhoa1();
        string x;
        public void thongke()
        {
            a:
            Console.Write("nhập mã khoa cần thống kê sinh viên:");
           x = Console.ReadLine();
            if (a.ktratt(x) == true)
            {
                Console.WriteLine("không có mã khoa đó tồn tại mời nhập lại");
                goto a;
            }
            int i = 1;
            Console.Write("danh sách sinh viên thuộc khoa:");a.hientenkhoa(x);Console.WriteLine("\t có mã khoa là:{0}", x);           
            Console.WriteLine("stt\tmã lớp\t mã sv\t tên sinh viên\t   giới tính\t quê quán\tngày sinh\t       số điện thoại");
            foreach (string s in a.thongke(x))
            {
                Console.Write(i);
                Console.WriteLine(s);
            }
        }
      
        public void timkiemsv()
        {
            int i = 1;
            a:
            Console.Write("nhập mã sinh viên cần kiếm trong khoa:");
            string x = Console.ReadLine();
            if (a.ktra1(x) == false)
            {
                Console.WriteLine("mã sinh viên không tồn tại mời bạn nhập lại");
                goto a;
            }
            Console.WriteLine("\t\t\t\tthông tin sinh viên cần tìm có trong khoa");
            foreach(string s in a.timkiem(x))
            {
                Console.WriteLine(i+"\t"+s);
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
                    Console.WriteLine("\t\t\t║█║                            ▐   CHỨC THỐNG KÊ SINH VIÊN KHOA   ▌                            ║█║");
                    Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                    Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                    Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                    Console.WriteLine("\t\t\t║█║            ║ 1 ║ Thống Kê SV Theo Mã Khoa ║ ║ 2 ║                             ║            ║█║");
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
                        case "1": Console.ForegroundColor = ConsoleColor.Red;thongke (); break;
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
   

