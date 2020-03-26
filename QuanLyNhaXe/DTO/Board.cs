using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTO
{
    public class Board
    {
        public Board(string ticketName, int count, float price, float totalPrice = 0)
        {
            this.TicketName = ticketName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Board(DataRow row)
        {
            this.TicketName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        private string ticketName;
        public string TicketName
        {
            get { return ticketName; }
            set { ticketName = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private float price;
        public float Price
        {
            get { return price;}
            set { price = value; }
        }

        private float totalPrice;
        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
    }
}
