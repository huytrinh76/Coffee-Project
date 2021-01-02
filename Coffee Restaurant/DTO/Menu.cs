using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Project.DTO
{
	public class Menu
	{
		public Menu(string foodName, int count, int price, int totalPrice = 0)
		{
			this.FoodName = foodName;
			this.Count = count;
			this.Price = price;
			this.TotalPrice = totalPrice;
		}
		public Menu(DataRow row)
		{
			this.FoodName = row["name"].ToString();
			this.Count = (int)row["count"];
			this.Price = (int)row["price"];
			this.TotalPrice = (int)row["totalPrice"];
		}

		private int totalPrice;
		private int price;
		private int count;
		private string foodName;

		public string FoodName { get => foodName; set => foodName = value; }
		public int Count { get => count; set => count = value; }
		public int Price { get => price; set => price = value; }
		public int TotalPrice { get => totalPrice; set => totalPrice = value; }
	}
}
