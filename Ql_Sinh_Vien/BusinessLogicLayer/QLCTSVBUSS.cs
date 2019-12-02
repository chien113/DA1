using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class QLCTSVBUSS
    {
        QLCTSV l = new QLCTSV();
        public List<CongTacsv> docfile()
        {
            return l.docfile();
        }
        public void them(CongTacsv k)
        {
            l.them(k);
        }
        public void sua(string x, List<object> ten)
        {
            l.sua(x, ten);
        }
        public void xoa(string x)
        {
            l.xoa(x);
        }
        public List<string>timkiem(string x)
        {
            return l.timkiem(x);
        }
        public bool ktra(string x)
        {
            List<CongTacsv> l = docfile();
            for (int i = 0; i<l.Count; i++)
            {
                if (l[i].Masv.ToLower() == x.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public bool ktraten(string input)
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
            Regex regex = new Regex("[a-zA-Z ]");
            string[] arr = new string[input.Length];
            for (int i = 0; i < input.Length - 1; i++)
            {
                arr[i] = input.Substring(i, 1);
                if (regex.IsMatch(arr[i]) == false)
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
    }
}
