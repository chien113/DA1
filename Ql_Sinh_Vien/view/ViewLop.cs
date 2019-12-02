using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    class ViewLop
    {
        QLLOPBUS ql = new QLLOPBUS();
        LOP l = new LOP();
        canchinh can = new canchinh(120,50);
        public void nhap()
        {
            do
            {
            chech:
                Console.Write("nhập mã lớp:");
                l.Malop = Console.ReadLine();
                for (int i = 0; i < l.Malop.Length; i++)
                {
                    var kytu = l.Malop.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                       || kytu == "*")
                    {
                        Console.WriteLine("bạn nhập sai kí tự {0}", kytu + "\t" + "mời nhập lại!");
                        goto chech;
                    }
                }
                if (ql.ktra(l.Malop))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("mã đã tồn tại mời nhập lại!");
                    goto chech;

                }
            } while (l.Malop.Trim() == "");
            do
            {
                nhap:
                Console.Write("nhập tên lớp:");
                l.Tenlop = Console.ReadLine();
                for(int i = 0; i < l.Tenlop.Length; i++)
                {
                    var kytu = l.Tenlop.Substring(i, 1);
                     if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                        || kytu == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("bạn nhập sai kí tự {0}", kytu + "\t" + "mời nhập lại!");
                        goto nhap;
                    }
                }
            } while (l.Tenlop.Trim() == "");
            do
            {
                Console.Write("nhập sĩ số:");
                l.Siso = int.Parse(Console.ReadLine());
            } while (l.Siso < 0);
            do
            {
                chech:
                Console.Write("nhập liên khóa của lớp:");
                l.LienKhoa = Console.ReadLine();
                for (int i = 0; i < l.LienKhoa.Length; i++)
                {
                    var kytu = l.LienKhoa.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                       || kytu == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("bạn nhập sai kí tự {0}", kytu + "\t" + "mời nhập lại!");
                        goto chech;
                    }
                }
            } while (l.LienKhoa.Trim()=="");
            do
            {
                Console.Write("nhập mã khoa:");
                l.Makhoa = Console.ReadLine();
            } while (l.Makhoa.Trim() == "");
            do
            {
                Console.Write("nhập mã chuyên ngành:");
                l.Macn = Console.ReadLine();
            } while (l.Makhoa.Trim() == "");
        }
        public void them()
        {
            while (true)
            {
                nhap();
                ql.them(l);
                Console.WriteLine("đã thêm!");
                Console.Write("có muốn nhập thêm nữa không C/K:");
                string x = Console.ReadLine();
                if (x == "K" || x == "k") break;
            }
        }
        public void hienthi()
        {
            int i = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t        THÔNG TIN LỚP  ");

            Console.WriteLine("\t\t\t\t\t  ╔═════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t  ║  STT | MaLop  |      TenLop      |   SiSo  |  LienKhoa   MA KHOA  |  MaCN   ║");
            Console.WriteLine("\t\t\t\t\t  ║═════════════════════════════════════════════════════════════════════════════║");
            foreach (LOP s in ql.docfile())
            {
                Console.WriteLine("\t\t\t\t\t     {0}\t    {1}\t {2}\t\t {3}\t  {4}   {5} \t {6}", i, s.Malop, s.Tenlop,  s.Siso, s.LienKhoa,s.Makhoa,s.Macn);
                Console.WriteLine("\t\t\t\t\t  ║-----------------------------------------------------------------------------║");
                Console.WriteLine("\t\t\t\t\t  ╚═════════════════════════════════════════════════════════════════════════════╝");
                can.Write("╔══════════════════════════════════════════════════════════╗", 31, 1, ConsoleColor.Yellow);
                can.Write("╚══════════════════════════════════════════════════════════╝", 31, 6, ConsoleColor.Yellow);
                i++;
            }
           
        }      
        public void xoa()
        {
            Console.Write("nhập mã cần xóa:");
            string x = Console.ReadLine();
            ql.xoa(x);
            Console.WriteLine("đã xóa");
        }
        public void timkiem()
        {
            string s;
            Console.Write("nhập mã cần tìm kiếm:");
            s = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("hiện thị thông tin lớp vừa tìm");
            foreach(string x in ql.timkiem(s))
            {
                Console.WriteLine(x);

            }
        }
        public void sua()
        {
            Console.Write("nhập mã cần sửa:");
            string ma = Console.ReadLine();

            List<object> l = new List<object>();
            while (true)
            {
                Console.Write("nhập trường cũ cần sửa:");
                object tencu = Console.ReadLine();
                a:
                Console.Write("nhập tên trường mới:");
                string truongmoi = Console.ReadLine();
                if (ql.ktra(truongmoi))
                {
                    Console.WriteLine("trường mới đã tồn tại mời nhập lại:");
                    goto a;
                }
                l.Add(tencu);
                l.Add(truongmoi);
                Console.Write("có sửa tiếp hay không C/K:");
                string a = Console.ReadLine();
                if (a != "C" || a != "c") break;
            }
            ql.sua(ma, l);
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
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC NĂNG QUẢN LÍ LỚP          ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Hiện Thông Tin Lớp       ║ ║ 2 ║ Thêm Thông Tin Lớp          ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Xóa Thông Tin Lớp        ║ ║ 4 ║ Tìm Kiếm Lớp             ║               ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝══════════════════════════╝               ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 5 ║ Sửa Thông Tin Lớp        ║                                 ║█║");
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
                    case "1": Console.ForegroundColor = ConsoleColor.Red; hienthi(); break;
                    case "2": Console.ForegroundColor = ConsoleColor.Blue; them(); break;
                    case "3": Console.ForegroundColor = ConsoleColor.Cyan; xoa(); break;
                    case "4": Console.ForegroundColor = ConsoleColor.Green; timkiem(); break;
                    case "5": Console.ForegroundColor = ConsoleColor.Yellow; sua(); break;                 
                    case "6": end = true; break;
                }
                Console.ReadKey();
            }

        }
    }
}
