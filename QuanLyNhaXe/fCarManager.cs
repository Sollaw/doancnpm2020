using QuanLyNhaXe.DAO;
using QuanLyNhaXe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace QuanLyNhaXe
{
    public partial class fCarManager : Form
    {
        public fCarManager()
        {
            InitializeComponent();

            LoadCar();
            LoadCategory();
        }
        #region Methods
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadTicketListByCategoryID(int id)
        {
            List<Ticket> listTicket = TicketDAO.Instance.GetTicketByCategoryID(id);
            cbTicket.DataSource = listTicket;
            cbTicket.DisplayMember = "Name";
        }

        void LoadCar()
        {
            flpCar.Controls.Clear();

            List<Car> carList = CarDAO.Instance.LoadCarList();

            foreach (Car item in carList)
            {
                Button btn = new Button() { Width = CarDAO.CarWidth, Height = CarDAO.CarHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Có người":
                        btn.BackColor = Color.OrangeRed;
                        break;
                    default:
                        btn.BackColor = Color.LightBlue;
                        break;
                }

                flpCar.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();

            List<Board> listBillInfo = BoardDAO.Instance.GetListBoardByCar(id);
            float totalPrice = 0;
            foreach (Board item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TicketName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }


        #endregion

        #region Events
        private void btn_Click(object sender, EventArgs e)
        {
            int carID = ((sender as Button).Tag as Car).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(carID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
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

            LoadTicketListByCategoryID(id);
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            Car car = lsvBill.Tag as Car;

            int idBill = BillDAO.Instance.GetUnCheckOutBillIDByCarID(car.ID);
            int idTicket = (cbTicket.SelectedItem as Ticket).ID;
            int count = (int)nmTicketCount.Value;

            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(car.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idTicket, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idTicket, count);
            }

            ShowBill(car.ID);

            LoadCar();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Car car = lsvBill.Tag as Car;

            int idBill = BillDAO.Instance.GetUnCheckOutBillIDByCarID(car.ID);

            if(idBill != -1)
            {
                if(MessageBox.Show("Bạn có thật sự muốn thanh toán hóa đơn của " + car.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                    ShowBill(car.ID);

                    LoadCar();
                }
            }
        }
        #endregion
    }
}
