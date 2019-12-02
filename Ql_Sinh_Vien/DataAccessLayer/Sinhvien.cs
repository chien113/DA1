using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    public class Sinhvien
    {
        string _MASV;
        string _TenSV;
        string _Gioitinh;
        string _Quequan;
        DateTime _Ngaysinh;
        string _SDT;
        string _Malop;

        public string MASV { get => _MASV; set => _MASV = value; }
        public string TenSV { get => _TenSV; set => _TenSV = value; }
        public string Quequan { get => _Quequan; set => _Quequan = value; }
        public DateTime Ngaysinh { get => _Ngaysinh; set => _Ngaysinh = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Gioitinh { get => _Gioitinh; set => _Gioitinh = value; }
        public string Malop { get => _Malop; set => _Malop = value; }
    }
}
