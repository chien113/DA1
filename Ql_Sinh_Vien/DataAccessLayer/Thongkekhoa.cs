using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class Thongkekhoa
    {
        LopDoc l = new LopDoc();
        KHOA_DOC k = new KHOA_DOC();
        SINHVIEN_DOC sv = new SINHVIEN_DOC();
        List<string> ds = new List<string>();
        public List<string>thongke(string ma)
        {          
            StreamWriter sw = new StreamWriter("thongkekhoa.txt");
            for(int i = 0; i < k.Docds().Count; i++)
            {
                if (k.Docds()[i].Get_Ma_Khoa.ToLower() == ma.ToLower())
                {
                    for(int j = 0; j < l.docfile().Count; j++)
                    {
                        if (l.docfile()[j].Makhoa == k.Docds()[i].Get_Ma_Khoa)
                        {
                            for(int c = 0; c < sv.Docfile().Count; c++)
                            {
                                if (sv.Docfile()[c].Malop == l.docfile()[j].Malop)
                                {
                                    string s= "\t" + sv.Docfile()[c].Malop + "\t" + sv.Docfile()[c].MASV + "\t" + sv.Docfile()[c].TenSV + "\t" + sv.Docfile()[c].Gioitinh + "\t" + sv.Docfile()[c].Quequan + "\t" + sv.Docfile()[c].Ngaysinh + "\t" + sv.Docfile()[c].SDT;
                                    sw.WriteLine(sv.Docfile()[c].Malop + "\t" + sv.Docfile()[c].MASV + "\t" + sv.Docfile()[c].TenSV + "\t" + sv.Docfile()[c].Gioitinh + "\t" + sv.Docfile()[c].Quequan + "\t" + sv.Docfile()[c].Ngaysinh + "\t" + sv.Docfile()[c].SDT);
                                    ds.Add(s);
                                }
                            }
                        }
                    }
                }
               
            }
            sw.Close();
            return ds;
        }
      
        public List<string> dssv(string x)
        {
            StreamReader l = new StreamReader("thongkekhoa.txt");
            List<string> ds = new List<string>();
            if (File.Exists("thongkekhoa.txt") == false)
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
