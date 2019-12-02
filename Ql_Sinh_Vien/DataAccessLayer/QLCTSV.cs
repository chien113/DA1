using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    public class QLCTSV
    {

        private string file = "CONGTACSV.txt";
        public void ghifile(List<CongTacsv> ds)
        {
            StreamWriter l = new StreamWriter(file, false);
            foreach(CongTacsv c in ds)
            {
                l.WriteLine(c.Masv + "#" + c.Tensv + "#" + c.Tinhtrang);
            }
            l.Close();
        }
        public List<CongTacsv> docfile()
        {
            StreamReader l = new StreamReader(file);
            List<CongTacsv> ds = new List<CongTacsv>();
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
                    CongTacsv ct = new CongTacsv();
                    ct.Masv = tach[0];
                    ct.Tensv = tach[1];
                    ct.Tinhtrang = tach[2];
                    ds.Add(ct);
                }
            }
            l.Close();
            return ds;
        }
        public void them(CongTacsv l)
        {
            StreamWriter a = new StreamWriter(file, true);
            a.WriteLine(l.Masv + "#" + l.Tensv + "#" + l.Tinhtrang);
            a.Close();
        }
        public void xoa(string x)
        {
            StreamReader l = new StreamReader(file);
            string dem = "";
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
                    if (tach[0] != x)
                    {
                        dem += s+"\n";
                    }
                }
            }
            l.Close();
            StreamWriter sw = new StreamWriter(file);
            sw.Write(dem);
            sw.Close();
        }
        public List<string>timkiem(string x)
        {
            StreamReader l = new StreamReader(file);
            List<string> sw = new List<string>();
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
                    if (tach[0] == x)
                    {
                        string a = tach[0] + "\t" + tach[1] + "\t" + tach[2];
                        sw.Add(a);
                    }
                }
            }
            l.Close();
            return sw;
        }
        public void sua(string ma, List<object> tentruong)
        {
            List<CongTacsv> l = docfile();
            foreach(CongTacsv a in l)
            {
                if (a.Masv.ToUpper() == ma.ToUpper())
                {
                    for(int j = 0; j < tentruong.Count - 1; j += 2)
                    {
                        if (Convert.ToString(tentruong[j]).ToUpper() == "MA SINH VIEN")
                        {
                            a.Masv = Convert.ToString(tentruong[j + 1]);
                        }
                        if (Convert.ToString(tentruong[j]).ToUpper() == "TEN SINH VIEN")
                        {
                            a.Tensv = Convert.ToString(tentruong[j + 1]);
                        }
                        if (Convert.ToString(tentruong[j]).ToUpper() == "TINH TRANG")
                        {
                            a.Tinhtrang = Convert.ToString(tentruong[j + 1]);
                        }
                    }
                    break;
                }
            }
            ghifile(l);
        }
    }
}
