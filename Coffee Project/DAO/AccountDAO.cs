using Coffee_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Project.DAO
{
	public class AccountDAO
	{
		private static AccountDAO instance;
		public static AccountDAO Instance
		{
			get { if (instance == null) instance = new AccountDAO(); return instance; }
			private set  => instance = value; 
		}

		private AccountDAO(){}
		public bool Login(string userName, string passWord)
		{
			string query = "USP_Login @userName , @passWord";
			DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName, passWord });
			return result.Rows.Count>0;
		}
		public Account GetAccountByUserName(string userName)
		{
			DataTable data= DataProvider.Instance.ExecuteQuery("SELECT* FROM dbo.Account WHERE UserName='"+userName+"'");
			foreach(DataRow item in data.Rows)
			{
				return new Account(item);
			}
			return null;
		}
		public bool UpdateAccount(string userName, string displayName, string passWord, string newPass)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName , @displayName , @passWord , @newPassword", new object[] {userName, displayName, passWord, newPass });
			return result > 0;
		}
		public DataTable GetListAccount()
		{
			return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type  FROM dbo.Account");
		}
	}
}
