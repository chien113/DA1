using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class thongkechuyennganh1
    {
        thongkecn l = new thongkecn();
        QLCNBUSS a = new QLCNBUSS();
        public List<string>thongke(string x)
        {
            return l.kiemsvcn(x);
        }
        public bool ktra(string x)
        {
            for(int i = 0; i < a.docfile().Count; i++)
            {
                if (a.docfile()[i].Machuyennganh == x)
                {
                    return true;
                }
            }
            return false;
        }
        public void kiemtra(string x)
        {
            for (int i = 0; i < a.docfile().Count; i++)
            {
                if (a.docfile()[i].Machuyennganh == x)
                {
                    Console.Write(a.docfile()[i].Tenchuyennganh);
                    break;
                }
            }
           
        }
        public List<string> dssv(string x)
        {
            return l.dssv(x);
        }
        public bool ktra2(string x)
        {
            StreamReader a = new StreamReader("thống kê chuyên ngành.txt");
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
