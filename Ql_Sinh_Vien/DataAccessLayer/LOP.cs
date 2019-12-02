using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class LOP
    {
        private string _Malop;
        private string _Tenlop;
        private int _Siso;
        private string _LienKhoa;
        string _Makhoa;
        string _Macn;

        public string Malop { get => _Malop; set => _Malop = value; }
        public string Tenlop { get => _Tenlop; set => _Tenlop = value; }
        public int Siso { get => _Siso; set => _Siso = value; }
        public string LienKhoa { get => _LienKhoa; set => _LienKhoa = value; }
        public string Makhoa { get => _Makhoa; set => _Makhoa = value; }
        public string Macn { get => _Macn; set => _Macn = value; }
    }
}
