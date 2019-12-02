using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    class ViewSinhvien
    {
        Sinhvien l = new Sinhvien();
        QLSVBUS ql = new QLSVBUS();
        QLSVBUS k = new QLSVBUS();
        public void nhap()
        {
            bool kt = false;      
            do
            {
                chech:
                Console.Write("nhập mã sinh viên:");
                l.MASV = Console.ReadLine();
                for(int i = 0; i < l.MASV.Length; i++)
                {
                    var kytu = l.MASV.Substring(i,1);
                    if(kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                          || kytu == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("bạn đã nhập mã kí tự đặc biệt " + kytu + "ở chỗ " + i);
                        Console.WriteLine("mời nhập lại");
                        goto chech;
                    }
                }
                if (k.ktratrung(l.MASV))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("đã trung mã sinh viên!");
                    goto chech;
                }
            } while (kt);
            do
            {
                check:
                Console.Write("nhập tên sinh viên:");
                l.TenSV = Console.ReadLine();
                if (ql.KiemTraTen(l.TenSV) == false)
                {
                    Console.WriteLine("tên không chứa kí tự số,không chứa 2 dấu cách liên tiếp bạn nhập sai mời nhập lại");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto check;
                }
                for (int i = 0; i < l.MASV.Length; i++)
                {
                    var kytu = l.TenSV.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                          || kytu == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("bạn đã nhập mã kí tự đặc biệt " + kytu + "ở chỗ " + i);
                        Console.WriteLine("mời nhập lại");
                        goto check;
                    }
                }
            } while (kt&&l.TenSV.Trim()=="");
            do
            {
            a:
                Console.WriteLine("giới tính sinh viên");
                Console.WriteLine("1:nam");
                Console.WriteLine("2:nữ");
                var a = Console.ReadLine();
                if (a == "1")
                {
                    l.Gioitinh = "NAM";
                }
                else if (a == "2")
                {
                    l.Gioitinh = "NU";
                }
                else
                {
                    Console.WriteLine("bạn nhập sai mời nhaaoj lại");
                    goto a;
                }
            } while (l.Gioitinh.Trim() == "");
            do
            {
            check:
                Console.Write("nhập quê quán sinh viên:");
                l.Quequan = Console.ReadLine();
                if (ql.KiemTraTen(l.Quequan) == false)
                {
                    Console.WriteLine("quê không chứa kí tự số,không chứa 2 dấu cách liên tiếp bạn nhập sai mời nhập lại");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto check;
                }
                for (int i = 0; i < l.MASV.Length; i++)
                {
                    var kytu = l.TenSV.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                          || kytu == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("bạn đã nhập mã kí tự đặc biệt " + kytu + "ở chỗ " + i);
                        Console.WriteLine("mời nhập lại");
                        goto check;
                    }
                }
            } while (l.Quequan.Trim() == "");
            do
            {
            check:
                Console.Write("nhập ngày sinh sinh viên:");
                l.Ngaysinh =Convert.ToDateTime( Console.ReadLine());
                if (l.Ngaysinh.Year > 2008)
                {
                    Console.WriteLine("bạn nhập sai năm sinh của sinh viên");
                    goto check;
                }
            } while (l.Ngaysinh.Year <1880);
            do
            {
            check:
                Console.Write("nhập số điện thoại sinh viên:");
                l.SDT = Console.ReadLine();
                if (l.SDT.Length < 10)
                {
                    Console.WriteLine("số điện thoại không quá 10 số bạn nhập sai mời nhập lại");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto check;
                }
                if (ql.ktraxhdau(l.SDT) == false)
                {
                    Console.WriteLine("số điện thoại số đầu phải là số 0 bạn nhập sai mời nhập lại");
                    goto check;
                }
                for (int i = 0; i < l.SDT.Length; i++)
                {
                    var kytu = l.TenSV.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                          || kytu == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("bạn đã nhập mã kí tự đặc biệt " + kytu + "ở chỗ " + i);
                        Console.WriteLine("mời nhập lại");
                        goto check;
                    }
                }
            } while (l.SDT.Trim() == ""&&l.SDT.Length>10);
            do
            {
                Console.Write("nhập mã lớp:");
                l.Malop = Console.ReadLine();
            } while (l.Malop.Trim() == "");
        }
        public void hien()
        {
            int i = 1;
            //Console.WriteLine();
            //Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t              THÔNG TIN SINH VIÊN  ");

            Console.WriteLine("\t\t  ╔══════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t  ║ STT | MaSV  |      TenSV         |   Gtinh  |  Diachi  |   Ngay Sinh          |   SDT       MALOP║");
            Console.WriteLine("\t\t  ║══════════════════════════════════════════════════════════════════════════════════════════════════║");
            foreach (Sinhvien s in ql.docfile())
            {
                Console.WriteLine("\t    \t    {0}", i + "  \t  " + s.MASV + "\t   " + s.TenSV + "\t " +s.Gioitinh+"\t  "+ s.Quequan +"   "+s.Ngaysinh+ "   " + s.SDT+"\t"+s.Malop);
                Console.WriteLine("\t\t  ║--------------------------------------------------------------------------------------------------║");
                Console.WriteLine("\t\t  ╚══════════════════════════════════════════════════════════════════════════════════════════════════╝");
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
        public void sua()
        {
            List<object> c = new List<object>();
            Console.Write("nhập mã sinh viên cần sửa:");
            string ma = Console.ReadLine();
            while (true)
            {
                Console.Write("nhập tên trường cũ cần sửa:");
                object a = Console.ReadLine();
                a:
                Console.Write("nhập tên trường :");
                string b = Console.ReadLine();
                if (ql.ktratrung(b))
                {
                    Console.WriteLine("trường mới đã có mời nhập lại");
                    goto a;
                }
                c.Add(a);
                c.Add(b);
                Console.Write("có muốn sửa nữa hay không C/K:");
                string s = Console.ReadLine();
                if (s != "c" || s != "C") break;
            }
            ql.sua(ma, c);
        }
        public void xoa()
        {
            Console.Write("nhập mã cần xóa:");
            string x = Console.ReadLine();
            ql.xoa(x);
            Console.WriteLine("đã xóa!");

        }
        public void timkiem()
        {
            string x;
            do
            {
                Console.Write("nhập mã khoa cần tìm:");
                x = Console.ReadLine();
            } while (x.Trim() == "");
            Console.WriteLine("thông tin khoa");
            foreach (string s in k.timkiem(x))
            {
                Console.WriteLine(s);
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
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC NĂNG QUẢN LÍ SINH VIÊN    ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Hiện Thông Tin Sinh Viên ║ ║ 2 ║ Thêm Thông Tin Sinh Viên    ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Xóa Thông Tin Sinh Viên  ║ ║ 4 ║ Tìm Kiếm Sinh Viên       ║               ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝══════════════════════════╝               ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 5 ║ Sửa Thông Tin Sinh Viên  ║                                 ║█║");
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
