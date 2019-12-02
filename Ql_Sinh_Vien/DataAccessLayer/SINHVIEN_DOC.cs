using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class SINHVIEN_DOC
    {
         string file="SinhVien.txt";
        public void ghifile(List<Sinhvien> ds)
        {
            StreamWriter l = new StreamWriter(file, false);
            foreach(Sinhvien s in ds)
            {
                l.WriteLine(s.MASV + "#" + s.TenSV + "#" +s.Gioitinh+"#"+ s.Quequan + "#" + s.Ngaysinh + "#" + s.SDT+"\t"+s.Malop);
            }
            l.Close();
        }
        public List<Sinhvien> Docfile()
        {
            StreamReader l = new StreamReader(file);
            List<Sinhvien> sv = new List<Sinhvien>();
            if(File.Exists(file)==false)
            {
                l = null;
            }
            else
            {
                string st;
                while ((st = l.ReadLine()) != null)
                {                   
                    string[] tach = st.Split('#');
                    Sinhvien s = new Sinhvien();         
                    s.MASV = tach[0];
                    s.TenSV = tach[1];
                    s.Gioitinh = tach[2];
                    s.Ngaysinh =Convert.ToDateTime( tach[3]);
                    s.Quequan = tach[4];
                    s.SDT = tach[5];
                    s.Malop = tach[6];
                    sv.Add(s);
                }               
            }
            l.Close();
            return sv;
          
        }
        public void them(Sinhvien l)
        {
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(l.MASV + "#" + l.TenSV + "#"+l.Gioitinh+"#" + l.Ngaysinh + "#" + l.Quequan + "#" + l.SDT+"#"+l.Malop);
            sw.Close();
        }
        public void sua(string MaSV, List<object> TenTruong_GiaTri)
        {
            List<Sinhvien> l = Docfile();
            foreach(Sinhvien a in l)
            {
                if (a.MASV.ToUpper() == MaSV.ToUpper())
                {
                    for(int i=0; i < TenTruong_GiaTri.Count - 1; i += 2)
                    {
                        if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "MA SINH VIEN")
                        {
                            a.MASV = Convert.ToString(TenTruong_GiaTri[i + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "TEN SINH VIEN")
                        {
                            a.TenSV = Convert.ToString(TenTruong_GiaTri[i + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "GIOI TINH")
                        {
                            a.Gioitinh = Convert.ToString(TenTruong_GiaTri[i + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "QUE QUAN")
                        {
                            a.Quequan = Convert.ToString(TenTruong_GiaTri[i + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "NGAY SINH")
                        {
                            a.Ngaysinh = Convert.ToDateTime(TenTruong_GiaTri[i + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "SDT")
                        {
                            a.SDT = Convert.ToString(TenTruong_GiaTri[i + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[i]).ToUpper() == "MA LOP")
                        {
                            a.Malop = Convert.ToString(TenTruong_GiaTri[i + 1]);
                        }
                    }
                }
                ghifile(l);
            }
        }
        public void xoa(string x)
        {

            StreamReader l = new StreamReader(file);
            string s;
            string dem = "";
            if (File.Exists(file) == false)
            {
                l = null;
            }
            else
                while ((s = l.ReadLine()) != null)
                {
                    string[] tm = s.Split('#');
                    if (tm[0] != x)
                    {
                        dem += s + "\n";
                    }
                }
            l.Close();
            StreamWriter b = new StreamWriter(file);
            b.Write(dem);
            b.Close();
        }
        public List<string>timkiem(string x)
        {
            StreamReader l = new StreamReader(file);
            List<string> sv = new List<string>();
            string s;
            if (File.Exists(file) == false)
            {
                l = null;
            }
            else
            {
                while ((s = l.ReadLine()) != null)
                {
                    string[] tach = s.Split('#');
                    if (tach[0] == x)
                    {
                        string a = tach[0] + "\t" + tach[1] + "\t" + tach[2] + "\t" + tach[3] + "\t" + tach[4] + "\t" + tach[5]+"\t"+tach[6];
                        sv.Add(a);
                    }
                }
            }
            l.Close();
            return sv;          
        }
    }
}
