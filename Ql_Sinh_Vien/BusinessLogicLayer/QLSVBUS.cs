using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class QLSVBUS
    {
       
        SINHVIEN_DOC sv = new SINHVIEN_DOC();      
        public List<Sinhvien> docfile()
        {
            return sv.Docfile();
        }
        public bool ktratrung(string x)
        {
            List<Sinhvien> a = sv.Docfile();
            for(int i = 0; i < a.Count; i++)
            {
                if (a[i].MASV == x)
                {
                    return true;
                }
            }
            return false;
        }
        public void them(Sinhvien a)
        {
            sv.them(a);
        }
        public void sua(string ma, List<object> tentruong)
        {
            sv.sua(ma, tentruong);
        }
        public void xoa(string x)
        {
            sv.xoa(x);
        }
        public List<string>timkiem(string x)
        {
            return sv.timkiem(x);
        }
        public bool KiemTraTen(string input)
        {
            if (input.Length < 3 || input.Length > 50)
            {
                return false;
            }
            if (input.Trim() == "")
            {
                return false;
            }
            if (input.Contains("  ") == true)
            {
                return false;
            }
            Regex regex = new Regex("[!-@[-`{-~]");
            string[] arr = new string[input.Length];
            for (int i = 0; i <= input.Length - 1; i++)
            {
                arr[i] = input.Substring(i, 1);
                if (regex.IsMatch(arr[i]) == true)
                {
                    return false;
                }
            }
            if (arr[0] == " " || arr[arr.Length - 1] == " ")
            {
                return false;
            }
            return true;
        }
        public bool ktrachuaso(string pText)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(pText);
            }
            catch (Exception ex)
            {
                return regex.IsMatch(pText);
            }
        }
        public bool ktraxhdau(string x)
        {
            Regex regex = null;
            try
            {
                regex = new Regex("^0");
                return regex.IsMatch(x);
            }
            catch (Exception ex)
            {
                return regex.IsMatch(x);
            }
        }
        
    }
}
