using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    public class KHOA
    {
        string Ma_Khoa;
        string Ten_Khoa;
        string SDT;
        string Dia_Chi_Email;

        public string Get_Ma_Khoa { get => Ma_Khoa; set => Ma_Khoa = value; }
        public string Get_Ten_Khoa { get => Ten_Khoa; set => Ten_Khoa = value; }
        public string Get_SDT { get => SDT; set => SDT = value; }
        public string Get_Dia_Chi_Email { get => Dia_Chi_Email; set => Dia_Chi_Email = value; }
    }
}
