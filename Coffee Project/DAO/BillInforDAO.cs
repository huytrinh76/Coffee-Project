using Coffee_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Project.DAO
{
	public class BillInforDAO
	{
		private static BillInforDAO instance;

		public static BillInforDAO Instance {
			get { if (instance == null) instance = new BillInforDAO(); return BillInforDAO.instance; }
			private set => instance = value; 
		}
		private BillInforDAO() { }
		public List<BillInfor>GetListBillInfor(int id)
		{
			List<BillInfor> listBillInfor = new List<BillInfor>();
			DataTable data = DataProvider.Instance.ExecuteQuery("SELECT*FROM dbo.BillInfor WHERE idBill="+id);
			foreach (DataRow item in data.Rows)
			{
				BillInfor infor = new BillInfor(item);
				listBillInfor.Add(infor);
			}
			return listBillInfor;
		}
		public void InsertBillInfor(int idBill, int idFood, int count)
		{
			DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfor @idBill , @idFood , @count", new object[] { idBill, idFood, count });
		}
	}
}
