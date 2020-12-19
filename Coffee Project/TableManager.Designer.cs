﻿
namespace Coffee_Project
{
	partial class TableManager
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel2 = new System.Windows.Forms.Panel();
			this.lsvBill = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txbTotalPrice = new System.Windows.Forms.TextBox();
			this.cbSwitchTable = new System.Windows.Forms.ComboBox();
			this.btnSwitchTable = new System.Windows.Forms.Button();
			this.nmDiscount = new System.Windows.Forms.NumericUpDown();
			this.btnDiscount = new System.Windows.Forms.Button();
			this.btnCheckOut = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
			this.btnAddFood = new System.Windows.Forms.Button();
			this.cbFood = new System.Windows.Forms.ComboBox();
			this.cbCategory = new System.Windows.Forms.ComboBox();
			this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
			this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lsvBill);
			this.panel2.Location = new System.Drawing.Point(409, 89);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(379, 300);
			this.panel2.TabIndex = 1;
			// 
			// lsvBill
			// 
			this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lsvBill.GridLines = true;
			this.lsvBill.HideSelection = false;
			this.lsvBill.Location = new System.Drawing.Point(3, 3);
			this.lsvBill.Name = "lsvBill";
			this.lsvBill.Size = new System.Drawing.Size(373, 294);
			this.lsvBill.TabIndex = 0;
			this.lsvBill.UseCompatibleStateImageBehavior = false;
			this.lsvBill.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Tên món";
			this.columnHeader1.Width = 160;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Số lượng";
			this.columnHeader2.Width = 55;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Đơn giá";
			this.columnHeader3.Width = 81;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Thành tiền";
			this.columnHeader4.Width = 71;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.txbTotalPrice);
			this.panel3.Controls.Add(this.cbSwitchTable);
			this.panel3.Controls.Add(this.btnSwitchTable);
			this.panel3.Controls.Add(this.nmDiscount);
			this.panel3.Controls.Add(this.btnDiscount);
			this.panel3.Controls.Add(this.btnCheckOut);
			this.panel3.Location = new System.Drawing.Point(409, 395);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(379, 56);
			this.panel3.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(189, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 21);
			this.label1.TabIndex = 8;
			this.label1.Text = "Tổng tiền:";
			// 
			// txbTotalPrice
			// 
			this.txbTotalPrice.Font = new System.Drawing.Font("Azonix", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txbTotalPrice.ForeColor = System.Drawing.Color.Red;
			this.txbTotalPrice.Location = new System.Drawing.Point(171, 28);
			this.txbTotalPrice.Name = "txbTotalPrice";
			this.txbTotalPrice.ReadOnly = true;
			this.txbTotalPrice.Size = new System.Drawing.Size(121, 24);
			this.txbTotalPrice.TabIndex = 7;
			this.txbTotalPrice.Text = "0";
			this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cbSwitchTable
			// 
			this.cbSwitchTable.FormattingEnabled = true;
			this.cbSwitchTable.Location = new System.Drawing.Point(3, 31);
			this.cbSwitchTable.Name = "cbSwitchTable";
			this.cbSwitchTable.Size = new System.Drawing.Size(78, 21);
			this.cbSwitchTable.TabIndex = 6;
			// 
			// btnSwitchTable
			// 
			this.btnSwitchTable.Location = new System.Drawing.Point(3, 3);
			this.btnSwitchTable.Name = "btnSwitchTable";
			this.btnSwitchTable.Size = new System.Drawing.Size(78, 26);
			this.btnSwitchTable.TabIndex = 5;
			this.btnSwitchTable.Text = "Chuyển bàn";
			this.btnSwitchTable.UseVisualStyleBackColor = true;
			// 
			// nmDiscount
			// 
			this.nmDiscount.Location = new System.Drawing.Point(87, 32);
			this.nmDiscount.Name = "nmDiscount";
			this.nmDiscount.Size = new System.Drawing.Size(78, 20);
			this.nmDiscount.TabIndex = 4;
			this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnDiscount
			// 
			this.btnDiscount.Location = new System.Drawing.Point(87, 4);
			this.btnDiscount.Name = "btnDiscount";
			this.btnDiscount.Size = new System.Drawing.Size(78, 26);
			this.btnDiscount.TabIndex = 4;
			this.btnDiscount.Text = "Giảm giá";
			this.btnDiscount.UseVisualStyleBackColor = true;
			// 
			// btnCheckOut
			// 
			this.btnCheckOut.Location = new System.Drawing.Point(298, 4);
			this.btnCheckOut.Name = "btnCheckOut";
			this.btnCheckOut.Size = new System.Drawing.Size(78, 48);
			this.btnCheckOut.TabIndex = 3;
			this.btnCheckOut.Text = "Thanh toán";
			this.btnCheckOut.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.nmFoodCount);
			this.panel4.Controls.Add(this.btnAddFood);
			this.panel4.Controls.Add(this.cbFood);
			this.panel4.Controls.Add(this.cbCategory);
			this.panel4.Location = new System.Drawing.Point(409, 27);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(379, 56);
			this.panel4.TabIndex = 1;
			// 
			// nmFoodCount
			// 
			this.nmFoodCount.Location = new System.Drawing.Point(338, 19);
			this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.nmFoodCount.Name = "nmFoodCount";
			this.nmFoodCount.Size = new System.Drawing.Size(38, 20);
			this.nmFoodCount.TabIndex = 3;
			this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnAddFood
			// 
			this.btnAddFood.Location = new System.Drawing.Point(254, 3);
			this.btnAddFood.Name = "btnAddFood";
			this.btnAddFood.Size = new System.Drawing.Size(78, 48);
			this.btnAddFood.TabIndex = 2;
			this.btnAddFood.Text = "Thêm món";
			this.btnAddFood.UseVisualStyleBackColor = true;
			this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
			// 
			// cbFood
			// 
			this.cbFood.FormattingEnabled = true;
			this.cbFood.Location = new System.Drawing.Point(3, 30);
			this.cbFood.Name = "cbFood";
			this.cbFood.Size = new System.Drawing.Size(245, 21);
			this.cbFood.TabIndex = 1;
			// 
			// cbCategory
			// 
			this.cbCategory.FormattingEnabled = true;
			this.cbCategory.Location = new System.Drawing.Point(3, 3);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new System.Drawing.Size(245, 21);
			this.cbCategory.TabIndex = 0;
			this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
			// 
			// flpTable
			// 
			this.flpTable.AutoScroll = true;
			this.flpTable.Location = new System.Drawing.Point(12, 27);
			this.flpTable.Name = "flpTable";
			this.flpTable.Size = new System.Drawing.Size(391, 424);
			this.flpTable.TabIndex = 3;
			// 
			// adminToolStripMenuItem
			// 
			this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
			this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.adminToolStripMenuItem.Text = "Admin";
			this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
			// 
			// thôngTinTàiKhoảnToolStripMenuItem
			// 
			this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
			this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
			this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
			this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
			// 
			// thôngTinCáNhânToolStripMenuItem
			// 
			this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
			this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
			this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
			// 
			// đăngXuấtToolStripMenuItem
			// 
			this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
			this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
			this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(814, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// TableManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 463);
			this.Controls.Add(this.flpTable);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TableManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý Quán ăn Ngon";
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListView lsvBill;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cbCategory;
		private System.Windows.Forms.ComboBox cbFood;
		private System.Windows.Forms.Button btnAddFood;
		private System.Windows.Forms.NumericUpDown nmFoodCount;
		public System.Windows.Forms.FlowLayoutPanel flpTable;
		private System.Windows.Forms.Button btnCheckOut;
		private System.Windows.Forms.Button btnDiscount;
		private System.Windows.Forms.NumericUpDown nmDiscount;
		private System.Windows.Forms.Button btnSwitchTable;
		private System.Windows.Forms.ComboBox cbSwitchTable;
		private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TextBox txbTotalPrice;
		private System.Windows.Forms.Label label1;
	}
}