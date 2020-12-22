using Coffee_Project.DAO;
using Coffee_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Project
{
	public partial class AccountProfile : Form
	{
		private Account loginAccount;

		public Account LoginAccount { get => loginAccount; set => loginAccount = value; }
		public AccountProfile(Account acc)
		{
			InitializeComponent();
			LoginAccount = acc;
			ChangeAccount(loginAccount);
		}
		void ChangeAccount(Account acc)
		{
			txbUserName.Text = LoginAccount.UserName;
			txbDisplayName.Text = LoginAccount.DisplayName;
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UpdateAccountInfor();
		}
		void UpdateAccountInfor()
		{
			string displayName = txbDisplayName.Text;
			string passWord = txbPassWord.Text;
			string newPass = txbNewPass.Text;
			string ReEnter = txbReEnterPass.Text;
			string userName = txbUserName.Text;
			if (!newPass.Equals(ReEnter))
			{
				MessageBox.Show("Mật khẩu không trùng với mật khẩu mới!");
			}
			else
			{
				if (AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPass))
				{
					MessageBox.Show("Cập nhật thành công");
					if (updateAccount != null)
					{
						updateAccount(this, new AccountEvent (AccountDAO.Instance.GetAccountByUserName(userName)));
					}
				}
				else
				{
					MessageBox.Show("Vui lòng điền đúng mật khẩu!");
				}
			}
		}
		private event EventHandler<AccountEvent> updateAccount;
		public event EventHandler<AccountEvent> UpdateAccount
		{
			add { updateAccount += value; }
			remove { updateAccount-=value; }
		}
		public class AccountEvent : EventArgs
		{
			private Account acc;

			public Account Acc { get => acc; set => acc = value; }

			public AccountEvent(Account acc)
			{
				this.Acc = acc;
			}
		}
	}
}
