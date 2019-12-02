using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    class ViewCTSV
    {
       
        QLCTSVBUSS ql = new QLCTSVBUSS();
        CongTacsv l = new CongTacsv();
        public void nhap()
        {
            do
            {
            chech:
                Console.Write("nhập mã sinh viên:");
                l.Masv = Console.ReadLine();
                if (ql.ktra(l.Masv))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("mã đã tồn tại mời  nhập lại!");
                    goto chech;
                }
                for (int i = 0; i < l.Masv.Length; i++)
                {
                    var kytu = l.Masv.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                          || kytu == "*")
                    {
                        Console.WriteLine("bạn nhập sai có kí tự đặc biệt " + kytu + "mời nhập lại");
                        goto chech;
                    }
                }
            } while (l.Masv.Trim() == "");
            do
            {
            chech:
                Console.Write("nhập tên sinh viên:");
                l.Tensv = Console.ReadLine();
                if (ql.ktraten(l.Tensv) == false)
                {
                    Console.WriteLine("tên sinh viên không chứa số và không cách nhau bở 2 dấu cách liên tục");
                    goto chech;
                }
                for (int i = 0; i < l.Tensv.Length; i++)
                {
                    var kytu = l.Tensv.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                          || kytu == "*")
                    {
                        Console.WriteLine("bạn nhập sai có kí tự đặc biệt " + kytu + "mời nhập lại");
                        goto chech;
                    }
                }
            } while (l.Tensv.Trim() == "");
            do
            {
            chech:
                Console.WriteLine("nhập tình trạng sinh viên");
                Console.WriteLine("1:lên lớp");
                Console.WriteLine("2:lưu ban");
                var a = Console.ReadLine();
                if (Convert.ToInt32(a) == 1)
                {
                    l.Tinhtrang = "len lop";
                }
                else if (Convert.ToInt32(a) == 2)
                {
                    l.Tinhtrang = "luu ban";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("bạn nhập sai mời nhập lại");
                    goto chech;
                }
            } while (l.Tensv.Trim() == "");
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
        public void hien()
        {
            int i = 1;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\tTHÔNG TIN CÔNG TÁC SINH VIÊN  ");
            Console.WriteLine("\t\t  ╔════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t  ║ STT | MaSV  |      TenSV        |   tình trạng ║");
            Console.WriteLine("\t\t  ║════════════════════════════════════════════════║");
            foreach (CongTacsv l in ql.docfile())
            {
                Console.WriteLine("\t\t     {0}", i + "\t   " + l.Masv + "\t    " + l.Tensv + "\t" + l.Tinhtrang);
                Console.WriteLine("\t\t  ║------------------------------------------------║");
                Console.WriteLine("\t\t  ╚════════════════════════════════════════════════╝");
                i++;
            }
        }
        public void timkiem()
        {
            Console.Write("nhập mã cần tìm:");
            string x = Console.ReadLine();
            foreach(string s in ql.timkiem(x))
            {
                Console.WriteLine(s);
            }
        }
        public void xoa()
        {
            Console.Write("nhập mã cần xóa:");
            string x = Console.ReadLine();
            ql.xoa(x);
            Console.WriteLine("đã xóa!");
        }
        public void sua()
        {
            Console.Write("nhập mã cần sửa:");
            string x = Console.ReadLine();
            List<object> l = new List<object>();
            while (true)
            {
                Console.Write("nhập tên cũ muốn sửa:");
                object cu = Console.ReadLine();
            a:
                Console.Write("nhập tên mới:");             
                string moi = Console.ReadLine();
                if (ql.ktra(moi))
                {
                    Console.WriteLine("mã đã tồn tại mời nhập lại");
                    goto a;
                }
                l.Add(cu);
                l.Add(moi);
                Console.Write("có muốn sửa nữa không C/K:");
                string a = Console.ReadLine();
                if (a != "C" || a != "c") break;
            }
            ql.sua(x, l);
            Console.WriteLine("đa sửa!");

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
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC NĂNG QUẢN LÍ CTSV         ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Hiện Thông Tin CTSV      ║ ║ 2 ║ Thêm Thông Tin CTSV         ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Xóa Thông Tin CTSV       ║ ║ 4 ║ Tìm Kiếm CTSV            ║               ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝══════════════════════════╝               ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 5 ║ Sửa Thông Tin CTSV       ║                                 ║█║");
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
