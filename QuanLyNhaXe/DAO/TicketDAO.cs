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
    }
}
