using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class thongkekhoa1
    {
        Thongkekhoa l = new Thongkekhoa();
        QuanLiKhoa k = new QuanLiKhoa();
        KHOA a = new KHOA();
        public List<string>thongke(string x)
        {
            return l.thongke(x);
        }
       
        public bool ktratt(string x)
        {
            for(int i = 0; i < k.DocFile().Count; i++)
            {
                if (k.DocFile()[i].Get_Ma_Khoa != x)
                {
                    return false;
                }
            }
            return true;
        }
        public void hientenkhoa(string x)
        {
            for (int i = 0; i < k.DocFile().Count; i++)
            {
               
                if (ktratt(x) == false)
                {
                    Console.Write(k.DocFile()[i].Get_Ten_Khoa);
                   
                }
            }
        }
        public List<string>timkiem(string x)
        {
            return l.dssv(x);
        }
        public bool ktra1(string x)
        {
            StreamReader a = new StreamReader("thongkekhoa.txt");
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
