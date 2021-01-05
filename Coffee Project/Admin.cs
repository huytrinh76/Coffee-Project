﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Coffee_Project.DAO;
using Coffee_Project.DTO;

namespace Coffee_Project
{
	public partial class Admin : Form
	{
		BindingSource foodList = new BindingSource();
		BindingSource accountList = new BindingSource();
		public Account loginAccount;
		public Admin()
		{
			InitializeComponent();
			Load();
		}
		#region methods
		void Load()
		{
			dtgvFood.DataSource = foodList;
			LoadDateTimePickerBill();
			LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
			LoadListFood();
			LoadAccount();
			AddFoodBinding();
			LoadCategoryIntoCombobox(cbFoodCategory);
			dtgvAccount.DataSource = accountList;
			AddAccountBinding();
		}
		void LoadDateTimePickerBill()
		{
			DateTime today = DateTime.Now;
			dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
			dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
		}
		void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
		{
			dtgvBill.DataSource= BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
		}
		void LoadListFood()
		{
			foodList.DataSource= FoodDAO.Instance.GetListFood();
		}
		void AddFoodBinding()
		{
			txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
			txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
			nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
		}
		void LoadCategoryIntoCombobox(ComboBox cb)
		{
			cb.DataSource = CategoryDAO.Instance.GetListCategory();
			cb.DisplayMember = "Name";
		}
		List<Food> SearchFoodByName(string name)
		{
			List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
			return listFood;
		}
		void AddAccountBinding()
		{
			txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
			txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
			nmTypeAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
		}
		void LoadAccount()
		{
			accountList.DataSource = AccountDAO.Instance.GetListAccount();
		}
		void AddAccount(string userName, string displayName, int type)
		{
			if(AccountDAO.Instance.InsertAccount(userName, displayName, type))
			{
				MessageBox.Show("Thêm tài khoản thành công");
			}
			else
			{
				MessageBox.Show("Có lỗi trong quá trình thêm tài khoản");
			}
			LoadAccount();
		}
		void EditAccount(string userName, string displayName, int type)
		{
			if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
			{
				MessageBox.Show("Cập nhật tài khoản thành công");
			}
			else
			{
				MessageBox.Show("Có lỗi trong quá trình cập nhật tài khoản");
			}
			LoadAccount();
		}
		void DeleteAccount(string userName)
		{
			if (loginAccount.UserName.Equals(userName))
			{
				MessageBox.Show("Phiên làm việc đang dùng, không thể xóa tài khoản!");
				return;
			}
			if (AccountDAO.Instance.DeleteAccount(userName))
			{
				MessageBox.Show("Xóa tài khoản thành công");
			}
			else
			{
				MessageBox.Show("Có lỗi trong quá trình xóa tài khoản");
			}
			LoadAccount();
		}
		void ResetPass(string userName)
		{
			if (AccountDAO.Instance.ResetPass(userName))
			{
				MessageBox.Show("Thao tác thành công");
			}
			else
			{
				MessageBox.Show("Thao tác thất bại");
			}
		}
		#endregion

		#region events
		private void btnViewBill_Click(object sender, EventArgs e)
		{
			LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
		}

		private void btnShowFood_Click(object sender, EventArgs e)
		{
			LoadListFood();
		}

		private void txbFoodID_TextChanged(object sender, EventArgs e)
		{
			try
			{
			if (dtgvFood.SelectedCells.Count>0)
			{
				int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
				Category category = CategoryDAO.Instance.GetCategoryByID(id);
				cbFoodCategory.SelectedItem = category;
				int index = -1;
				int i = 0;
				foreach (Category item in cbFoodCategory.Items)
				{
					if (item.ID == category.ID)
					{
						index = i;
						break;
					}
					i++;
				}
				cbFoodCategory.SelectedIndex = index;
			}
			}
			catch
			{

			}
		}

		private void btnAddFood_Click(object sender, EventArgs e)
		{
			string name = txbFoodName.Text;
			int categoryID=(cbFoodCategory.SelectedItem as Category).ID;
			int price = (int)nmFoodPrice.Value;
			if (FoodDAO.Instance.InsertFood(name, categoryID, price))
			{
				MessageBox.Show("Thêm món thành công");
				LoadListFood();
				if (insertFood!=null)
				{
					insertFood(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Có lỗi khi thêm :(");
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			string name = txbFoodName.Text;
			int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
			int price = (int)nmFoodPrice.Value;
			int id = Convert.ToInt32(txbFoodID.Text);
			if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
			{
				MessageBox.Show("Sửa món thành công");
				LoadListFood();
				if (updateFood!=null)
				{
					updateFood(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Có lỗi khi sửa :(");
			}
		}

		private void btnDelFood_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(txbFoodID.Text);
			if (FoodDAO.Instance.DeleteFood(id))
			{
				MessageBox.Show("Xóa món thành công");
				LoadListFood();
				if (deleteFood!=null)
				{
					deleteFood(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Có lỗi khi xóa :(");
			}
		}

		private event EventHandler insertFood;
		public event EventHandler InsertFood
		{
			add { insertFood += value; }
			remove { insertFood -= value; }
		}
		private event EventHandler deleteFood;
		public event EventHandler DeleteFood
		{
			add { deleteFood += value; }
			remove { deleteFood -= value; }
		}
		private event EventHandler updateFood;
		public event EventHandler UpdateFood
		{
			add { updateFood += value; }
			remove { updateFood -= value; }
		}

		private void btnSearchFood_Click(object sender, EventArgs e)
		{
			foodList.DataSource= SearchFoodByName(txbSearchFoodName.Text);
		}

		private void btnShowAccount_Click(object sender, EventArgs e)
		{
			LoadAccount();
		}

		private void btnAddAccount_Click(object sender, EventArgs e)
		{
			string userName = txbUserName.Text;
			string displayName = txbDisplayName.Text;
			int type = (int)nmTypeAccount.Value;
			AddAccount(userName, displayName, type);
		}

		private void btnDelAccount_Click(object sender, EventArgs e)
		{
			string userName = txbUserName.Text;
			DeleteAccount(userName);
		}

		private void btnEditAccount_Click(object sender, EventArgs e)
		{
			string userName = txbUserName.Text;
			string displayName = txbDisplayName.Text;
			int type = (int)nmTypeAccount.Value;
			EditAccount(userName, displayName, type);
		}

		private void btnResetPassWord_Click(object sender, EventArgs e)
		{
			string userName = txbUserName.Text;
			ResetPass(userName);
		}

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
			txbPageBill.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
			int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
			int lastPage = sumRecord / 10;
            if (sumRecord%10!=0)
            {
				lastPage++;
            }
				txbPageBill.Text = lastPage.ToString();
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
			dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
			int page = Convert.ToInt32(txbPageBill.Text);
            if (page>1)
            {
				page--;
            }
			txbPageBill.Text = page.ToString();
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
			int page = Convert.ToInt32(txbPageBill.Text);
			int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            if (page<sumRecord)
            {
				page++;
            }
			txbPageBill.Text = page.ToString();
		}
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Bạn có muốn gửi báo cáo", "Gửi báo cáo thành công", MessageBoxButtons.OKCancel);
        }
    }
}
