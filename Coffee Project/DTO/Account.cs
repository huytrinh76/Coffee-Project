using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Project.DTO
{
	public class Account
	{
		public Account(string userName, string displayName, int type, string passWord = null)
		{
			this.UserName = userName;
			this.DisplayName = displayName;
			this.PassWord = passWord;
			this.Type = type;
		}
		public Account(DataRow row)
		{
			this.UserName = row["userName"].ToString();
			this.DisplayName = row["displayName"].ToString();
			this.PassWord = row["passWord"].ToString();
			this.Type = (int)row["type"];
		}

		private int type;
		private string passWord;
		private string displayName;
		private string userName;

		public string UserName { get => userName; set => userName = value; }
		public string DisplayName { get => displayName; set => displayName = value; }
		public string PassWord { get => passWord; set => passWord = value; }
		public int Type { get => type; set => type = value; }
	}
}
