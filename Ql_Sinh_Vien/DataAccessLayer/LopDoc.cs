using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class LopDoc
    {
        private string file = "lop.txt";
        SINHVIEN_DOC l = new SINHVIEN_DOC();
        Sinhvien a = new Sinhvien();
        public void ghifile(List<LOP> ds)
        {
            StreamWriter l = new StreamWriter(file, false);
            foreach(LOP a in ds)
            {
                l.WriteLine(a.Malop + "#" + a.Tenlop + "#" +a.Siso + "#" + a.LienKhoa+"#"+a.Makhoa+"#"+a.Macn);
            }
            l.Close();
        }
        public List<LOP> docfile()
        {
            StreamReader sw = new StreamReader(file);
            List<LOP> l = new List<LOP>();
            string s;
            if (File.Exists(file) == false)
            {
                l = null;
            }
            else
            {
                while ((s = sw.ReadLine()) != null)
                {
                    string[] tach = s.Split('#');
                    LOP a = new LOP();
                    a.Malop = tach[0];
                    a.Tenlop = tach[1];
                    a.Siso = Convert.ToInt16(tach[2]);
                    a.LienKhoa = tach[3];
                    a.Makhoa = tach[4];
                    a.Macn = tach[5];
                    l.Add(a);
                }
            }
            sw.Close();
            return l;
        }
        public void them(LOP k)
        {
            StreamWriter l = new StreamWriter(file, true);
            l.WriteLine(k.Malop + "#" + k.Tenlop + "#" +k.Siso + "#" + k.LienKhoa+"#"+k.Makhoa+"#"+k.Macn);
            l.Close();
        }
        public List<string> timkiem(string x)
        {
            StreamReader l = new StreamReader(file);
            List<string> ds = new List<string>();
            string s;

            if (File.Exists(file) == false)
            {
                l = null;
            }
            else
            {
                while ((s = l.ReadLine()) != null)
                {
                    string[] tmp = s.Split('#');
                    if (tmp[0] == x)
                    {
                        string a = tmp[0] + "\t" + tmp[1] + "\t" + tmp[2] + "\t" + tmp[3]+"\t"+tmp[4]+"\t"+tmp[5];
                        ds.Add(a);
                    }
                }
            }
            l.Close();
            return ds;
        }
        public void xoa(string x)
        {
            StreamReader l = new StreamReader(file);
            string dem = "";
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
                    if (tach[0] != x)
                    {
                        dem += s ;
                    }
                }
            }
            l.Close();
            StreamWriter sw = new StreamWriter(file);
            sw.Write(dem);
            sw.Close();
        }
        public void Sua(string x, List<object> TenTruong_GiaTri)
        {

            List<LOP> l = docfile();

            foreach (LOP a in l)
            {

                if (a.Malop.ToLower() == x.ToLower())
                {

                    for (int j = 0; j < TenTruong_GiaTri.Count - 1; j += 2)
                    {
                        if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "MA LOP")
                        {
                           a.Malop = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "TEN LOP")
                        {
                            a.Tenlop = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() =="SI SO")
                        {
                            a.Siso = Convert.ToInt16(TenTruong_GiaTri[j + 1]);
                        }
                        else if(Convert.ToString(TenTruong_GiaTri[j]).ToUpper()=="LIEN KHOA")
                        {
                            a.LienKhoa = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "MA KHOA")
                        {
                            a.Makhoa = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "MA CHUYEN NGANH")
                        {
                            a.Macn = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                    }
                    break;
                }

            }
            ghifile(l);

        }
      
    }
}
