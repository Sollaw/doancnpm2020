using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int iDBill, int iDTicket, int count)
        {
            this.ID = id;
            this.IDBill = iDBill;
            this.IDTicket = iDTicket;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["iDBill"];
            this.IDTicket = (int)row["iDTicket"];
            this.Count = (int)row["count"];
        }

        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private int iDBill;
        public int IDBill
        {
            get { return iDBill; }
            set { iDBill = value; }
        }

        private int iDTicket;
        public int IDTicket
        {
            get { return iDTicket; }
            set { iDTicket = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
