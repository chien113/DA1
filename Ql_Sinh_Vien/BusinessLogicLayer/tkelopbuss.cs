using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class tkelopbuss
    {
        thongkelop a = new thongkelop();
        QLLOPBUS b = new QLLOPBUS();
        public List<string>ds(string x)
        {
            return a.timsinhvien(x);
        }
        public bool ktra(string x)
        {
            for(int i = 0; i < b.docfile().Count; i++)
            {
                if (b.docfile()[i].Malop.ToLower() == x)
                {
                    return false;
                }
            }
            return true;
        }
        public void hientenlop(string x)
        {
            for (int i = 0; i < b.docfile().Count; i++)
            {
                if (ktra(x) == false)
                {
                    Console.Write(b.docfile()[i].Tenlop);
                    
                }
            }

        }
        public List<string> dssv(string x)
        {
            return a.dssv(x);
        }
        public bool ktra1(string x)
        {
            StreamReader a = new StreamReader("thongKelop.txt");
            string s;
            while ((s = a.ReadLine()) != null)
            {
                string[] tach = s.Split('\t');
                if (tach[1] != x)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
