using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;
using Ql_Sinh_Vien.BusinessLogicLayer;

namespace Ql_Sinh_Vien.view
{
    public class Viewkhoa
    {
        
        QuanLiKhoa k = new QuanLiKhoa();
        KHOA l = new KHOA();
        public void SuaKhoa()
        {
            System.Console.Write("Nhập vào mã khoa cần sửa:");
            string makhoa = Console.ReadLine();
            
            List<object> o = new List<object>();
            while(true)
            {
                Console.Write("Nhập tên trường cần sửa:");
                Object ten = Console.ReadLine();
                a:
                Console.Write("Nhập tên giá trị mới:");
                string giatri= Console.ReadLine();
                if (k.kiemtra(giatri))
                {
                    Console.WriteLine("mã này đã có");
                    goto a;
                }
                o.Add(ten);
                o.Add(giatri);

                Console.WriteLine("Ban có nhập tiếp không? Nhấn Y để tiếp, nhấn phím bất kỳ để thoát " + o.Count);
                string tiep = Console.ReadLine();
                if (tiep != "Y") break;
            }

            k.SuaTTKhoa(makhoa, o);
            
        }
        public void nhap()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            bool kt = false;
            do
            {
               nhaplai:
                Console.Write("nhập mã khoa:");
                l.Get_Ma_Khoa = Console.ReadLine();
                for (int i = 0; i < l.Get_Ma_Khoa.Length; i++)
                {

                    var kytu = l.Get_Ma_Khoa.Substring(i, 1);
                    if (kytu == "!" || kytu == "\\" || kytu == "@" || kytu == "#" || kytu == "$" || kytu == "%" || kytu == "&"
                      || kytu == "*" || kytu == "")
                    {
                        Console.WriteLine("bạn nhập sai có kí tự đặc biệt " + kytu + "mời nhập lại");
                        goto nhaplai;
                    }
                }
                if (k.kiemtra(l.Get_Ma_Khoa))
                {
                    Console.WriteLine("mã đã tồn tại");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    goto nhaplai;
                }
                if(l.Get_Ma_Khoa.Trim() == "")
                {
                    Console.WriteLine("không được để trống mã khoa");
                    goto nhaplai;
                }
               


            } while (kt&& l.Get_Ma_Khoa.Trim()=="");

            do
            {
                Check:
                Console.Write("nhập tên khoa:");
                l.Get_Ten_Khoa = Console.ReadLine();
                if (k.TestString(l.Get_Ten_Khoa) == false)
                {
                    Console.WriteLine("tên không chưa kí tự khác ngoài chữ và không chứa 2 dấu cách liên tục bạn nhập sai mời nhập lại");
                    goto Check;
                }
                for (int i = 0; i < l.Get_Ma_Khoa.Length; i++)
                {
                    var kytuXuatXu = l.Get_Ten_Khoa.Substring(i, 1);
                    
                    if (kytuXuatXu == "!" || kytuXuatXu == "\\" || kytuXuatXu == "@" || kytuXuatXu == "#" || kytuXuatXu == "$" || kytuXuatXu == "%" || kytuXuatXu == "&"
                          || kytuXuatXu == "*")
                    {
                        Console.WriteLine("Bạn nhập sai,ký tự đặc biệt " + kytuXuatXu + " vui lòng nhập lại");
                        goto Check;
                    }
                }
            } while (l.Get_Ten_Khoa.Trim() == "");
            do
            {
                a:
                Console.Write("nhập số điện thoại khoa:");
                l.Get_SDT = Console.ReadLine();
                if (l.Get_SDT.Length  <10)
                {
                    Console.WriteLine("số điện thoại không quá 10 số bạn nhập sai mời nhập lại");
                    goto a;
                }
                if (k.ktraxhdau(l.Get_SDT) == false)
                {
                    Console.WriteLine("số điện thoại phải bắt đầu bằng số 0 bạn nhập sai mời nhập lại");
                    goto a;
                }
              
                if (k.IsNumber(l.Get_SDT)==false)
                {
                    Console.WriteLine("số điện thoại không đúng,số điện thoại chỉ chứa số bạn nhập sai mời nhập lại");
                    goto a;
                }
              
            } while (l.Get_SDT.Trim() == "");
            do
            {
                a:
                Console.Write("nhập địa chỉ email khoa:");
                l.Get_Dia_Chi_Email = Console.ReadLine();  
                if (k.ktragmail(l.Get_Dia_Chi_Email) == false)
                {
                    Console.WriteLine("gmail phải kết thúc bằng @gmail.com bạn nhập sai định dạng mời nhập lại");
                    goto a;
                }
            } while (l.Get_Dia_Chi_Email.Trim() == "");
        }
        public void them()
        {
            while (true)
            {
                nhap();
                k.Them(l);
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
            Console.WriteLine("\t\t\t\t\t              THÔNG TIN CỦA KHOA  ");

            Console.WriteLine("\t\t\t  ╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t  ║ STT | MaKHOA  |      TenKHOA      |        SDT          |     ĐCEMAIL        ║");
            Console.WriteLine("\t\t\t  ║══════════════════════════════════════════════════════════════════════════════║");
            foreach (KHOA s in k.DocFile())
            {
                Console.WriteLine("\t\t\t     {0}",i+"\t    "+s.Get_Ma_Khoa+"\t\t   "+s.Get_Ten_Khoa+"\t\t    "+s.Get_SDT+"\t\t"+s.Get_Dia_Chi_Email);
                i++;
                Console.WriteLine("\t\t\t  ║------------------------------------------------------------------------------║");
                Console.WriteLine("\t\t\t  ╚══════════════════════════════════════════════════════════════════════════════╝");
            }
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("\t\t\t\t\t              THÔNG TIN NHÂN VIÊN  ");

            //Console.WriteLine("\t\t  ╔═══════════════════════════════════════════════════════════════════════════════════════╗");
            //Console.WriteLine("\t\t  ║  MaNV  |      TenNV      |   Gtinh  |  NSinh  |   ChucVu  |   Dchi    |      SDT      ║");
            //Console.WriteLine("\t\t  ║═══════════════════════════════════════════════════════════════════════════════════════║");
            //foreach (Nhanvien a in dsnhanvien)
            //{
            //    a.Show();
            //    Console.WriteLine("\t\t  ║---------------------------------------------------------------------------------------║");
            //}
            //Console.WriteLine("\t\t  ╚═══════════════════════════════════════════════════════════════════════════════════════╝");
        }
        public void xoakhoa()
        {
            
            do
            {
                Console.Write("Nhap mã cần xóa khoa: ");
                l.Get_Ma_Khoa = Console.ReadLine();
            } while (l.Get_Ma_Khoa.Trim()=="");
            k.xoakhoa(l.Get_Ma_Khoa);
            Console.WriteLine("Da xoa thanh cong!");
        }
        public void timkiem1()
        {
            string x;
            do
            {
                Console.Write("nhập mã khoa cần tìm:");
                x = Console.ReadLine();
            } while (x.Trim() == "");
            Console.WriteLine("thông tin khoa");
            foreach(string s in k.timkiem(x))
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
                Console.WriteLine("\t\t\t║█║                            ▐   CHỨC NĂNG QUẢN LÍ KHOA         ▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                            ║█║");
                Console.WriteLine("\t\t\t║█║                                                                                            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗═════════════════════════════╗            ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 1 ║ Hiện Thông Tin Khoa      ║ ║ 2 ║ Thêm Thông Tin Khoa         ║            ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝═════════════════════════════╝            ║█║");
                Console.WriteLine("\t\t\t║█║            ╔═══╗══════════════════════════╗ ╔═══╗══════════════════════════╗               ║█║");
                Console.WriteLine("\t\t\t║█║            ║ 3 ║ Xóa Thông Tin Khoan      ║ ║ 4 ║ Tìm Kiếm Khoa            ║               ║█║");
                Console.WriteLine("\t\t\t║█║            ╚═══╝══════════════════════════╝ ╚═══╝══════════════════════════╝               ║█║");
                Console.WriteLine("\t\t\t║█║                           ╔═══╗══════════════════════════╗                                 ║█║");
                Console.WriteLine("\t\t\t║█║                           ║ 5 ║ Sửa Thông Tin Khoa       ║                                 ║█║");
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
                    case "1":Console.ForegroundColor = ConsoleColor.Red;  hien();break;
                    case "2": Console.ForegroundColor = ConsoleColor.Blue; them();break;
                    case "3": Console.ForegroundColor = ConsoleColor.Cyan; xoakhoa();break;
                    case "4": Console.ForegroundColor = ConsoleColor.Green; timkiem1();break;
                    case "5": Console.ForegroundColor = ConsoleColor.Yellow; SuaKhoa();break;
                    case "6":end = true;break;
                }
                Console.ReadKey();
            }
          
        }
    }
}
