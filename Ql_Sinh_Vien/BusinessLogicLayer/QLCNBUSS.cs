using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class QLCNBUSS
    {
        ChuyenNganhDOC l = new ChuyenNganhDOC();
        public List<Chuyennganh> docfile()
        {
            return l.docfile();
        }
        public void them(Chuyennganh k)
        {
            l.them(k);
        }
        public void xoa(string x)
        {
            l.xoa(x);
        }
        public void sua(string x, List<object> tentruong)
        {
            l.Sua(x, tentruong);
        }
        public List<string>timkiem(string x)
        {
            return l.timkiem(x);
        }
        public bool ktra(string x)
        {
            List<Chuyennganh> l = docfile();
            for(int i = 0; i < l.Count; i++)
            {
                if (l[i].Machuyennganh == x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
