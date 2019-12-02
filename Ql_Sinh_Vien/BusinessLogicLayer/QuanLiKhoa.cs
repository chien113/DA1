using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
   public class QuanLiKhoa
    {
        KHOA_DOC l = new KHOA_DOC();
        public bool kiemtra(string MK)
        {
            List<KHOA> a = l.Docds();
            bool ktra = false;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Get_Ma_Khoa == MK)
                {
                    return true;
                }
            }
            return ktra;
        }      
        public List<KHOA> DocFile()
        {
            return l.Docds();
        }
        public void Them(KHOA k)
        {
            l.Addkhoa(k);
        }
        public void SuaTTKhoa(string x, List<object> tentruong_GiaTri)
        {
            l.Sua(x, tentruong_GiaTri);
        }
        public void xoakhoa(string x)
        {
            l.xoakhoa(x);
        }
        public List<string> timkiem(string x)
        {
            return l.timkiem(x);
        }
        public bool TestString(string input)
        {            
           
            if (input.Contains("  ") == true)
            {
                return false;
            }
            Regex regex = new Regex("[!-@[-`{-~]");
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
        public bool IsNumber(string pText)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(pText);
            }
            catch (Exception ptext)
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
        public bool ktragmail(string x)
        {
            Regex regex = null;
            try
            {
                regex = new Regex("@gmail.com$");
                return regex.IsMatch(x);
            }
            catch (Exception ex)
            {
                return regex.IsMatch(x);
            }
        }
    }
}
