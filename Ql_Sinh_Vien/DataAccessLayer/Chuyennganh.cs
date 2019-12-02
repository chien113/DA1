using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    class Chuyennganh
    {
        private string _Machuyennganh;
        private string _Tenchuyennganh;
        private string _Diachi;

        public string Machuyennganh { get => _Machuyennganh; set => _Machuyennganh = value; }
        public string Tenchuyennganh { get => _Tenchuyennganh; set => _Tenchuyennganh = value; }
        public string Diachi { get => _Diachi; set => _Diachi = value; }
    }
}
