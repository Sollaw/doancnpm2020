using QuanLyNhaXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DAO
{
    public class TicketDAO
    {
        private static TicketDAO instance;

        public static TicketDAO Instance
        {
            get { if (instance == null) instance = new TicketDAO(); return TicketDAO.instance; }
            set { TicketDAO.instance = value; }
        }

        private TicketDAO() { }

        public List<Ticket> GetTicketByCategoryID(int id)
        {
            List<Ticket> list = new List<Ticket>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Ticket where iDCategory = " + id);

            foreach (DataRow item in data.Rows)
            {
                Ticket ticket = new Ticket(item);

                list.Add(ticket);
            }

            return list;
        }

        public List<Ticket> GetListTicket()
        {
            List<Ticket> list = new List<Ticket>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Ticket");

            foreach (DataRow item in data.Rows)
            {
                Ticket ticket = new Ticket(item);

                list.Add(ticket);
            }

            return list;
        }

        public List<Ticket> SearchTicketByName(string name)
        {
            List<Ticket> list = new List<Ticket>();

            DataTable data = DataProvider.Instance.ExecuteQuery(string.Format("select * from Ticket where name like N'%{0}%'", name));

            foreach (DataRow item in data.Rows)
            {
                Ticket ticket = new Ticket(item);

                list.Add(ticket);
            }

            return list;
        }

        public bool InsertTicket(string name, int idCategory, float price)
        {
            string query = string.Format("insert into Ticket (name,idCategory,price) values (N'{0}',{1},{2})", name, idCategory, price);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTicket(int id,string name, int idCategory, float price)
        {
            string query = string.Format("update Ticket set name = N'{0}', idCategory = {1}, price = {2} where id = {3}", name, idCategory, price, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTicket(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByTicketID(id);

            string query = string.Format("delete Ticket where id = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
