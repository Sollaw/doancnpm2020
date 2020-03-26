using QuanLyNhaXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaXe.DAO
{
    public class CarDAO
    {
        private static CarDAO instance;

        public static CarDAO Instance
        {
            get { if (instance == null) instance = new CarDAO(); return CarDAO.instance; }
            private set { CarDAO.instance = value; }
        }

        public static int CarWidth = 100;
        public static int CarHeight = 110;

        private CarDAO() { }

        public List<Car> LoadCarList()
        {
            List<Car> carList = new List<Car>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetCarList");

            foreach(DataRow item in data.Rows)
            {
                Car car = new Car(item);

                carList.Add(car);
            }

            return carList;
        }
    }
}
