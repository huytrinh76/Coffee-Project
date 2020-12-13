using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Project.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set => instance = value; 
        }

        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            return DataProvider.Instance.ExecuteScalar("");
        }
    }
}
