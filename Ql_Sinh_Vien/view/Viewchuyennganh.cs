using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    class Viewchuyennganh
    {
        Chuyennganh l = new Chuyennganh();
        QLCNBUSS ql = new QLCNBUSS();
        public void nhap()
        {
            do
            {
            chech:
                Console.Write("nhập mã chuyên ngành:");
                l.Machuyennganh = Console.ReadLine();
                for (int i = 0; i < l.Machuyennganh.Length; i++)
                {
                    var kytu = l.Machuyennganh.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                      || kytu == "*")
                    {
                        Console.WriteLine("bạn nhập sai có kí tự đặc biệt " + kytu + "mời nhập lại");
                        goto chech;
                    }
                }

            } while (l.Machuyennganh.Trim() == "");
            do
            {
            chech:
                Console.Write("nhập tên chuyên ngành:");
                l.Tenchuyennganh = Console.ReadLine();
                for (int i = 0; i < l.Tenchuyennganh.Length; i++)
                {
                    var kytu = l.Tenchuyennganh.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                      || kytu == "*")
                    {
                        Console.WriteLine("bạn nhập sai có kí tự đặc biệt " + kytu + "mời nhập lại");
                        goto chech;
                    }
                }
            } while (l.Tenchuyennganh.Trim() == "");
            do
            {
            chech:
                Console.Write("nhập địa chỉ chuyên ngành:");
                l.Diachi = Console.ReadLine();
                for (int i = 0; i < l.Diachi.Length; i++)
                {
                    var kytu = l.Diachi.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                      || kytu == "*")
                    {
                        Console.WriteLine("bạn nhập sai có kí tự đặc biệt " + kytu + "mời nhập lại");
                        goto chech;
                    }
                }
            } while (l.Diachi.Trim() == "");
        }
        public void hien()
        {
            int i = 1;
            Console.WriteLine("stt\tmã CN\t tên chuyên ngành\t địa chỉ");
            foreach(Chuyennganh l in ql.docfile())
            {
                Console.WriteLine("{0}", i+"\t"+l.Machuyennganh + "\t   " + l.Tenchuyennganh + "\t\t" + l.Diachi);

                i++;
            }
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
        public void xoa()
        {
            Console.Write("nhập mã cần xóa");
            string x = Console.ReadLine();
            ql.xoa(x);
            Console.WriteLine("đã xóa!");
        }
        public void timkiem()
        {
            Console.Write("nhập mã cần tìm:");
            string x = Console.ReadLine();
            foreach(string l in ql.timkiem(x))
            {
                Console.WriteLine(l);
            }
        }
        public void sua()
        {
           
            Console.Write("nhập mã cần sửa:");
            string ma = Console.ReadLine();
            List<object> l = new List<object>();
            while (true)
            {
                Console.Write("nhập tên  cần sửa:");
                object cu = Console.ReadLine();
                a:
                Console.Write("nhập tên mới:");
                string moi = Console.ReadLine();
                if (ql.ktra(moi))
                {
                    Console.WriteLine("trường mới này đã tồn tại mời nhập lại");
                    goto a;
                }
                l.Add(cu);
                l.Add(moi);
                Console.WriteLine("có sửa tiếp không c/k");
                string a = Console.ReadLine();
                if (a != "c" || a != "C") break;
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
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC NĂNG QUẢN LÍ CHUYÊN NGÀNH ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Hiện Thông Tin CN        ║ ║ 2 ║ Thêm Thông Tin CN           ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Xóa Thông Tin CN         ║ ║ 4 ║ Tìm Kiếm CN              ║               ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝══════════════════════════╝               ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 5 ║ Sửa Thông Tin CN         ║                                 ║█║");
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
                    case "1": Console.ForegroundColor = ConsoleColor.Red; hien(); break;
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
