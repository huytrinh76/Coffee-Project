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
	public partial class TableManager : Form
	{
		public TableManager()
		{
			InitializeComponent();
			LoadTable();
		}
		#region Method
		void LoadTable()
		{
			List<Table> tableList=TableDAO.Instance.LoadTableList();
			foreach(Table item in tableList)
			{
				Button btn = new Button() {Width=TableDAO.TableWidth, Height=TableDAO.TableHeight };
				btn.Text = item.Name+Environment.NewLine+item.Status;
                btn.Click += Btn_Click;
				btn.Tag = item;

				switch (item.Status)
				{
					case "Trống":
						btn.BackColor = Color.White;
						break;
					default:
						btn.BackColor = Color.Green;
							break;
				}
				flpTable.Controls.Add(btn);
			}
		}

		void ShowBill(int id)
        {

        }
		#endregion

		#region Events
		private void Btn_Click(object sender, EventArgs e)
		{
			int tableID=(sender as Table).ID;
			ShowBill(tableID);
		}

		private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AccountProfile f = new AccountProfile();
			f.ShowDialog();
		}

		private void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin f = new Admin();
			f.ShowDialog();
		}
		#endregion
	}
}
