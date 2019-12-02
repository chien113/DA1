using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class thongkecn
    {
        ChuyenNganhDOC cn = new ChuyenNganhDOC();
        LopDoc l = new LopDoc();
        SINHVIEN_DOC sv = new SINHVIEN_DOC();
        public List<string>kiemsvcn(string x)
        {
            List<string> ds = new List<string>();
            StreamWriter sw = new StreamWriter("thống kê chuyên ngành.txt");
            for(int i = 0; i < cn.docfile().Count; i++)
            {
                if (cn.docfile()[i].Machuyennganh == x)
                {
                    for(int j = 0; j < l.docfile().Count; j++)
                    {
                        if (l.docfile()[j].Macn == cn.docfile()[i].Machuyennganh)
                        {
                            for(int c = 0; c < sv.Docfile().Count; c++)
                            {
                                if (sv.Docfile()[c].Malop == l.docfile()[j].Malop)
                                {
                                    string s = "\t" + sv.Docfile()[c].Malop + "\t" + sv.Docfile()[c].MASV + "\t" + sv.Docfile()[c].TenSV + "\t" + sv.Docfile()[c].Gioitinh + "\t" + sv.Docfile()[c].Quequan + "\t" + sv.Docfile()[c].Ngaysinh + "\t" + sv.Docfile()[c].SDT;
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
            StreamReader l = new StreamReader("thống kê chuyên ngành.txt");
            List<string> ds = new List<string>();
            if (File.Exists("thống kê chuyên ngành.txt") == false)
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
