using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    public class KHOA_DOC
    {
        private static string file = "KHOA.txt";//tạo đường dẫn cho file 
        public void Ghifile(List<KHOA>ds)//tạo list ds chứa thông tin của khoa
        {
            StreamWriter l = new StreamWriter(file,false);//hàm để ghi file vào tệp dữ liệu
          

            foreach (KHOA k in ds)//tạo biến k chứa thông tin khoa ở trong danh sách
            {
              
                l.WriteLine(k.Get_Ma_Khoa + "#" + k.Get_Ten_Khoa + "#" + k.Get_SDT + "#" + k.Get_Dia_Chi_Email);//ghi tất cả các thuộc tính của lhoa vào file txt và cách nhau bởi dấu #
            
            }
            l.Close();//đóng file lại
        }
        public List<KHOA> Docds()//tạo ra một danh sách khoa
        {
            StreamReader sw = new StreamReader(file);//hàm để đọc file có tróng file text
            List<KHOA> l = new List<KHOA>();//tạo danh sách khoa
            if (File.Exists(file) == false)//hàm kiểm tra file đó có tồn tại hay không
            {
                l = null;//nếu không tồn tại trả về giá trị null
            }
            else//nếu tồn tại 
            {                
                string st;//tạo 1 chuỗi st 
                while ((st = sw.ReadLine() )!= null)//st sẽ chứa thông tin của danh sách có trong file
                {
                    string []t = st.Split('#');//tách mảng st chưa thông tin file thành từng hàng cách nhau bởi dấu cách
                    KHOA k = new KHOA();//tạo biến k chứa thông tin của khoa
                    k.Get_Ma_Khoa = t[0];//đọc phần tử đầu tiên của file là mã khoa
                    k.Get_Ten_Khoa = t[1];//đọc phần tử thứ hai của file  tên khoa
                    k.Get_SDT = t[2];//đọc phần tử thứ ba của file là số điện thoại
                    k.Get_Dia_Chi_Email = t[3];//đọc phần tử thứ tư của file là địa chỉ email
                    l.Add(k);//thêm tất cả các thuộc tính đó vào danh sách 
                }              
            }
            sw.Close();//đóng file lại
            return l;//trả về danh sách l
        }       
        public void Addkhoa(KHOA st)//tạo biến st chứa thông tin của khoa
        {
            StreamWriter l = new StreamWriter(file, true);//ghi thêm thông tin vào file text      
            string s = st.Get_Ma_Khoa + "#" + st.Get_Ten_Khoa + "#" + st.Get_SDT + "#" + st.Get_Dia_Chi_Email;//tạo biến s chứa tất cả thông tin của khoa
            l.WriteLine(s);//ghi file s đó vào file text
            l.Close();//đóng file
        }       
        public void Sua(string Ma, List<object> TenTruong_GiaTri)//tạo tham số Mã,là list object(object là kiểu dữ liệu cha cho tất cả các kiểu dữ liệu)tên trường gt cần sửa
        {
        
            List<KHOA> l = Docds();//tạo l chưa toàn bộ thông tin của file
            foreach(KHOA k in l)//tạo biến k chứa toàn bộ trong tin khoa cu=ó trong f
            {
                if (k.Get_Ma_Khoa.ToLower()==Ma.ToLower())//kiểm tra nếu mã khoa giống mã nhập vào
                {
                 
                    for (int j=0;j<TenTruong_GiaTri.Count-1;j+=2)//dùng vong lặp để th
                    {
                       
                        if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "MA KHOA")//nếu trường giá trị mình muốn sửa là mã khoa thì trường đó sẽ thay đổi khi mã đúng
                        {
                            k.Get_Ma_Khoa = Convert.ToString(TenTruong_GiaTri[j + 1]);//còn lại như nhau
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "TEN KHOA")
                        {
                            k.Get_Ten_Khoa = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "SDT")
                        {
                            k.Get_SDT = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "DIA CHI EMAIL")
                        {
                            k.Get_Dia_Chi_Email = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                    }
                }

            }
            Ghifile(l);//sửa xong ta sẽ lưu lại vào file

          

        }
        public void xoakhoa(string x)//tạo tham số x
        {
            StreamReader l = new StreamReader(file);//đọc file text
            string s;//tạo biến s
            string dem = "";//tạo biến dem k tham số
            if (File.Exists(file) == false)//kiểm tra sự tồn tại của file
            {
                l = null;
            }
            else
                while ((s = l.ReadLine()) != null)//lưu file vào s
                {
                    string[] tm = s.Split('#');//tách s ra thành hàng cách nhau bởi dấu #
                    if (tm[0] != x)//kiểm tra các mã k giống với x thì lưu xuống hàm đếm
                    {
                        dem += s + "\n";//lưu trữ các mã kp mã cần xóa
                    }
                }
            l.Close();//đóng file
            StreamWriter b = new StreamWriter(file);//tạo biến ghi file
            b.Write(dem);//lưu biến đếm lại
            b.Close();//đóng file
        }
        public List<string> timkiem(string x)//tạo 1 danh sách string và tham số x
        {
            StreamReader l = new StreamReader(file);//đọc file
            List<string> ds = new List<string>();//tạo 1 danh sách
            string s;
            
            if (File.Exists(file) == false)//kiểm tra file
            {
                l = null;
            }
            else
            {
                while ((s = l.ReadLine()) != null)//đọc file vào s
                {
                    string[]tmp=s.Split('#');//tách mảng thành hàng cách nhau bởi dấu #
                    if (tmp[0] == x)//nếu mã nhập vào đúng 
                    {
                        string a = tmp[0] + "\t" + tmp[1] + "\t" + tmp[2]+"\t"+tmp[3] ;//ghi thông tin của khoa đó ra
                        ds.Add(a);    //lưu vào danh sách                
                    }                  
                }
            }
            l.Close();//đống file
            return ds;//trả về gt cần tìm           
        }
    }
}
