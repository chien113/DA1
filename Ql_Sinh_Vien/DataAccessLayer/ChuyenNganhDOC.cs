using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class ChuyenNganhDOC
    {
        string file = "Chuyennganh.txt";      
        public void ghifile(List<Chuyennganh> ds)
        {
            StreamWriter sw = new StreamWriter(file, false);
            foreach(Chuyennganh l in ds)
            {
                sw.WriteLine(l.Machuyennganh + "#" + l.Tenchuyennganh + "#" + l.Diachi);
            }
            sw.Close();
        }
        public List<Chuyennganh> docfile()
        {
            StreamReader l = new StreamReader(file);
            List<Chuyennganh> cn = new List<Chuyennganh>();
            if (File.Exists(file) == false)
            {
                l = null;
            }
            else
            {
                string s;
                while ((s = l.ReadLine()) != null)
                {
                    string[] tach = s.Split('#');
                    Chuyennganh a = new Chuyennganh();
                    a.Machuyennganh = tach[0];
                    a.Tenchuyennganh = tach[1];
                    a.Diachi = tach[2];
                    cn.Add(a);
                }
            }
            l.Close();
            return cn;
        }
        public void them(Chuyennganh k)
        {
            StreamWriter l = new StreamWriter(file, true);
            l.WriteLine(k.Machuyennganh + "#" + k.Tenchuyennganh + "#" + k.Diachi);
            l.Close();
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
            while ((s = l.ReadLine()) != null)
            {
                string[] tach = s.Split('#');
                if (tach[0] != x)
                {
                    dem += s;
                }
            }
            l.Close();
            StreamWriter a = new StreamWriter(file);
            a.Write(dem);
            a.Close();
        }
        public List<string>timkiem(string x)
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
                    string[] tach = s.Split('#');
                    if (tach[0] == x)
                    {
                        string a = tach[0] + "\t" + tach[1] + "\t" + tach[2];
                        ds.Add(a);
                    }
                }
            }
            l.Close();
            return ds;

        }
        public void Sua(string Ma, List<object> TenTruong_GiaTri)
        {

            List<Chuyennganh> l = docfile();
            foreach (Chuyennganh k in l)
            {
                if (k.Machuyennganh.ToLower() == Ma.ToLower())
                {

                    for (int j = 0; j < TenTruong_GiaTri.Count - 1; j += 2)
                    {

                        if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "MA CHUYEN NGANH")
                        {
                            k.Machuyennganh = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "TEN CHUYEN NGANH")
                        {
                            k.Tenchuyennganh = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                        else if (Convert.ToString(TenTruong_GiaTri[j]).ToUpper() == "DIA CHI")
                        {
                            k.Diachi = Convert.ToString(TenTruong_GiaTri[j + 1]);
                        }
                       
                    }
                }

            }
            ghifile(l);
        }
    }
}
