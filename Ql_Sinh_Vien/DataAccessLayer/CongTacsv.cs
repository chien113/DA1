using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ql_Sinh_Vien.DataAccessLayer
{
    public class CongTacsv
    {
        private string _Masv;
        private string _Tensv;
        private string _tinhtrang;

        public string Masv { get => _Masv; set => _Masv = value; }
        public string Tensv { get => _Tensv; set => _Tensv = value; }
        public string Tinhtrang { get => _tinhtrang; set => _tinhtrang = value; }
    }
}
