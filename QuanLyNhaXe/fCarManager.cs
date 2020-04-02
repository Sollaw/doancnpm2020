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
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public fCarManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadCar();
            LoadCategory();
            LoadComboBoxCar(cbSwitchCar);
        }
        #region Methods
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinCáNhânToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

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

        void LoadComboBoxCar(ComboBox cb)
        {
            cb.DataSource = CarDAO.Instance.LoadCarList();
            cb.DisplayMember = "Name";
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

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();

            f.loginAccount = LoginAccount;
            f.InsertTicket += f_InsertTicket;
            f.DeleteTicket += f_DeleteTicket;
            f.UpdateTicket += f_UpdateTicket;
            f.ShowDialog();
        }

        private void f_UpdateTicket(object sender, EventArgs e)
        {
            LoadTicketListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Car).ID);
            }
        }

        private void f_DeleteTicket(object sender, EventArgs e)
        {
            LoadTicketListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Car).ID);
            }
            LoadCar();
        }

        private void f_InsertTicket(object sender, EventArgs e)
        {
            LoadTicketListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Car).ID);
            }
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

            if(car == null)
            {
                MessageBox.Show("Hãy chọn xe");

                return;
            }

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
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0].Replace(".", ""));
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            
            if(idBill != -1)
            {
                if(MessageBox.Show(string.Format("Bạn có muốn thanh toán hóa đơn của {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", car.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(car.ID);

                    LoadCar();
                }
            }
        }

        private void btnSwitchCar_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Car).ID;
            int id2 = (cbSwitchCar.SelectedItem as Car).ID;

            if (MessageBox.Show(string.Format("Bạn có muốn chuyển {0} qua {1}", (lsvBill.Tag as Car).Name, (cbSwitchCar.SelectedItem as Car).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                CarDAO.Instance.SwitchCar(id1, id2);

                LoadCar();
            }
        }
        #endregion
    }
}
