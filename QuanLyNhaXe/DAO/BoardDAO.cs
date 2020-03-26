using QuanLyNhaXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DAO
{
    public class BoardDAO
    {
        private static BoardDAO instance;

        public static BoardDAO Instance
        {
            get { if (instance == null) instance = new BoardDAO(); return BoardDAO.instance; }
            private set { BoardDAO.instance = value; }
        }

        private BoardDAO() { }

        public List<Board> GetListBoardByCar(int id)
        {
            List<Board> listBoard = new List<Board>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select t.name, bi.count, t.price, t.price * bi.count as N'totalPrice' from BillInfo as bi, Bill as b, Ticket as t where bi.idBill = b.id and bi.idTicket = t.id and b.status = 0 and b.idCar = " + id);

            foreach(DataRow item in data.Rows)
            {
                Board board = new Board(item);
                listBoard.Add(board);
            }

            return listBoard;
        }
    }
}
