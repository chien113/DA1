using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class thongkelop
    {
        public List<string> timsinhvien(string ma)
        {
            SINHVIEN_DOC l = new SINHVIEN_DOC();
            Sinhvien a = new Sinhvien();

            List<string> ds = new List<string>();
            StreamWriter sw = new StreamWriter("thongKelop.txt");
            string s;
            for (int i = 0; i < l.Docfile().Count; i++)
            {
                if (l.Docfile()[i].Malop.ToLower() == ma.ToLower())
                {
                    s ="\t"+ l.Docfile()[i].Malop + "\t" + l.Docfile()[i].MASV + "\t" + l.Docfile()[i].TenSV + "\t" + l.Docfile()[i].Gioitinh + "\t" + l.Docfile()[i].Quequan + "\t" + l.Docfile()[i].Ngaysinh + "\t" + l.Docfile()[i].SDT;
                    sw.WriteLine(l.Docfile()[i].MASV + "\t" + l.Docfile()[i].TenSV + "\t" + l.Docfile()[i].Gioitinh + "\t" + l.Docfile()[i].Quequan + "\t" + l.Docfile()[i].Ngaysinh + "\t" + l.Docfile()[i].SDT);
                    ds.Add(s);
                }
            }
            sw.Close();
            return ds;
        }
        public List<string> dssv(string x)
        {
            StreamReader l = new StreamReader("thongKelop.txt");
            List<string> ds = new List<string>();
            if (File.Exists("thongKelop.txt") == false)
            {
                l = null;
            }
            else
            {
                string s;
                while ((s = l.ReadLine()) != null)
                {
                    string[] tach = s.Split('\t');
                    if (tach[1].ToLower() == x.ToLower())
                    {
                        string a = tach[0] + "\t" + tach[1] + "\t" + tach[2] + "\t" + tach[3] + "\t" + tach[4] + "\t" + tach[5] + "\t" + tach[6];
                        ds.Add(a);
                    }
                }
            }
            return ds;
        }
    }
}
