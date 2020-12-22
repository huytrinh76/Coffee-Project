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
using static System.Windows.Forms.ListViewItem;
using Menu = Coffee_Project.DTO.Menu;
using System.Globalization;
using System.Threading;
using static Coffee_Project.AccountProfile;

namespace Coffee_Project
{
	public partial class TableManager : Form
	{
		private Account loginAccount;

		public Account LoginAccount { get => loginAccount; set => loginAccount = value; }

		public TableManager(Account acc)
		{
			InitializeComponent();
			this.LoginAccount = acc;
			LoadTable();
			LoadCategory();
			LoadComboboxTable(cbSwitchTable);
			ChangeAccount(loginAccount.Type);
		}
		#region Method
		void ChangeAccount(int type)
		{
			adminToolStripMenuItem.Enabled = type == 1;
			thôngTinTàiKhoảnToolStripMenuItem.Text += "[" + LoginAccount.DisplayName +"]";
		}
		void LoadCategory()
		{
			List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
			cbCategory.DataSource = listCategory;
			cbCategory.DisplayMember = "Name";
		}
		void LoadFoodListByCategoryID(int id)
		{
			List<Food> listFood = FoodDAO.Instance.GetFoodByCategory(id);
			cbFood.DataSource = listFood;
			cbFood.DisplayMember="Name";
		}
		void LoadTable()
		{
			flpTable.Controls.Clear();
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
			lsvBill.Items.Clear();
			List<Menu> listBillInfor = MenuDAO.Instance.GetListMenuByTable(id);
			int totalPrice = 0;
			foreach (Menu item in listBillInfor)
			{
				ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
				lsvItem.SubItems.Add(item.Count.ToString());
				lsvItem.SubItems.Add(item.Price.ToString());
				lsvItem.SubItems.Add(item.TotalPrice.ToString());
				totalPrice += item.TotalPrice;
				lsvBill.Items.Add(lsvItem);
			}
			CultureInfo cultture = new CultureInfo("vi-VN");
			Thread.CurrentThread.CurrentCulture = cultture;
			txbTotalPrice.Text = totalPrice.ToString("c", cultture);
        }
		void LoadComboboxTable(ComboBox cb)
		{
			cb.DataSource = TableDAO.Instance.LoadTableList();
			cb.DisplayMember = "Name";
		}
		#endregion

		#region Events
		private void Btn_Click(object sender, EventArgs e)
		{
			int tableID=((sender as Button).Tag as Table).ID;
			lsvBill.Tag = (sender as Button).Tag;
			ShowBill(tableID);
		}

		private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AccountProfile f = new AccountProfile(LoginAccount);
			f.UpdateAccount += F_UpdateAccount; ;
			f.ShowDialog();
		}

		private void F_UpdateAccount(object sender, AccountEvent e)
		{
			thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản ("+e.Acc.DisplayName+")";
		}

		private void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Admin f = new Admin();
			f.InsertFood += F_InsertFood;
			f.DeleteFood += F_DeleteFood;
			f.UpdateFood += F_UpdateFood;
			f.ShowDialog();
		}

		private void F_UpdateFood(object sender, EventArgs e)
		{
			LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
			{
				ShowBill((lsvBill.Tag as Table).ID);
			}
		}

		private void F_DeleteFood(object sender, EventArgs e)
		{
			LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
			{
				ShowBill((lsvBill.Tag as Table).ID);
			}
			LoadTable();
		}

		private void F_InsertFood(object sender, EventArgs e)
		{
			LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag !=null)
			{
			ShowBill((lsvBill.Tag as Table).ID);
			}
		}

		private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = 0;
			ComboBox cb = sender as ComboBox;
			if (cb.SelectedItem == null)
			{
				return;
			}
			Category selected = cb.SelectedItem as Category;
			id = selected.ID;
			LoadFoodListByCategoryID(id);
		}
		private void btnAddFood_Click(object sender, EventArgs e)
		{
			Table table = lsvBill.Tag as Table;
			if (table==null)
			{
				MessageBox.Show("Hãy chọn bàn");
				return;
			}
			int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
			int foodID = (cbFood.SelectedItem as Food).ID;
			int count = (int)nmFoodCount.Value;
			if (idBill==-1)
			{
				BillDAO.Instance.InsertBill(table.ID);
				BillInforDAO.Instance.InsertBillInfor(BillDAO.Instance.GetMaxIDBill(), foodID, count);
			}
			else
			{
				BillInforDAO.Instance.InsertBillInfor(idBill, foodID, count);
			}
			ShowBill(table.ID);
			LoadTable();
		}
		private void btnCheckOut_Click(object sender, EventArgs e)
		{
			Table table = lsvBill.Tag as Table;
			int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
			int discount = (int)nmDiscount.Value;
			double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
			double finalTotalPrice = totalPrice - (totalPrice / 100)*discount;
			if (idBill != -1)
			{
				if(MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho {0}?\n Tổng tiền - (Tổng tiền) x Giảm giá\n={1} - {1} x {2}%\n={3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					BillDAO.Instance.CheckOut(idBill, discount, (int)finalTotalPrice);
					ShowBill(table.ID);
					LoadTable();
				}
			}
		}
		private void btnSwitchTable_Click(object sender, EventArgs e)
		{
			int id1 = (lsvBill.Tag as Table).ID;
			int id2 = (cbSwitchTable.SelectedItem as Table).ID;
			if (MessageBox.Show(string.Format("Bạn có thực sự muốn chuyển bàn {0} qua bàn {1} không?", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.YesNo)==DialogResult.Yes)
			{
				TableDAO.Instance.SwitchTable(id1, id2);
				LoadTable();
			}
		}
		#endregion

	}
}
