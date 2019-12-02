using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ql_Sinh_Vien.DataAccessLayer;

namespace Ql_Sinh_Vien.BusinessLogicLayer
{
    class QLLOPBUS
    {
        LopDoc l = new LopDoc();
        public List<LOP> docfile()
        {
            return l.docfile();
        }
        public void them(LOP k)
        {
            l.them(k);
        }
        public void sua(string x, List<object> tentruong)
        {
            l.Sua(x, tentruong);
        }
        public List<string> timkiem(string x)
        {
            return l.timkiem(x);
        }
        public void xoa(string x)
        {
            l.xoa(x);
        }
        public bool ktra(string x)
        {
            List<LOP> l = docfile();
            for(int i = 0; i < l.Count; i++)
            {
                if (l[i].Malop == x)
                {
                    return true;
                }
            }
            return false;
        }
        
       
    }
}
