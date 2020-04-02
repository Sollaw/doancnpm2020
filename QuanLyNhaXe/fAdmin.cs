using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyNhaXe.DAO;
using QuanLyNhaXe.DTO;

namespace QuanLyNhaXe
{
    public partial class fAdmin : Form
    {
        BindingSource ticketList = new BindingSource();

        BindingSource accountList = new BindingSource();

        public Account loginAccount;

        public fAdmin()
        {
            InitializeComponent();

            dtgvTicket.DataSource = ticketList;
            dtgvAccount.DataSource = accountList;

            LoadDateTimePicker();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListAccount();
            LoadListTicket();
            AddTicketBinding();
            AddAccountBinding();
            LoadCategoryIntoComboBox(cbTicketCategory);
        }

        #region Methods

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;

            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
        }

        void LoadListTicket()
        {
            ticketList.DataSource = TicketDAO.Instance.GetListTicket();
        }

        void AddTicketBinding()
        {
            txbTicketName.DataBindings.Add(new Binding("Text", dtgvTicket.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbTicketID.DataBindings.Add(new Binding("Text", dtgvTicket.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmTicketPrice.DataBindings.Add(new Binding("Value", dtgvTicket.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        List<Ticket> SearchTicketByName(string name)
        {
            List<Ticket> listTicket = TicketDAO.Instance.SearchTicketByName(name);

            return listTicket;
        }

        void AddAccount(string userName, string displayName, int type)
        {
            try
            {
                if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi");
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã tồn tại");
            }

            LoadListAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi");
            }

            LoadListAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Tài khoản đang được sử dụng");
                return;
            }

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi");
            }

            LoadListAccount();
        }

        void ResetPassWord(string userName)
        {
            if (AccountDAO.Instance.ResetPassWord(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi");
            }

            LoadListAccount();
        }

        #endregion

        #region Events

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPassWord(userName);
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void btnShowTicket_Click(object sender, EventArgs e)
        {
            LoadListTicket();
        }

        private void txbTicketID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvTicket.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvTicket.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);

                    cbTicketCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;

                    foreach (Category item in cbTicketCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbTicketCategory.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            string name = txbTicketName.Text;
            int idCategory = (cbTicketCategory.SelectedItem as Category).ID;
            float price = (float)nmTicketPrice.Value;

            if (TicketDAO.Instance.InsertTicket(name, idCategory, price))
            {
                MessageBox.Show("Thêm vé thành công");

                LoadListTicket();

                if (insertTicket != null)
                {
                    insertTicket(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi");
            }
        }

        private void btnEditTicket_Click(object sender, EventArgs e)
        {
            string name = txbTicketName.Text;
            int idCategory = (cbTicketCategory.SelectedItem as Category).ID;
            float price = (float)nmTicketPrice.Value;
            int id = Convert.ToInt32(txbTicketID.Text);

            if (TicketDAO.Instance.UpdateTicket(id, name, idCategory, price))
            {
                MessageBox.Show("Sửa vé thành công");

                LoadListTicket();

                if (updateTicket != null)
                {
                    updateTicket(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi");
            }
        }

        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            string name = txbTicketName.Text;
            int idCategory = (cbTicketCategory.SelectedItem as Category).ID;
            float price = (float)nmTicketPrice.Value;
            int id = Convert.ToInt32(txbTicketID.Text);

            if (TicketDAO.Instance.DeleteTicket(id))
            {
                MessageBox.Show("Xóa vé thành công");

                LoadListTicket();

                if(deleteTicket != null)
                {
                    deleteTicket(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi");
            }
        }

        private event EventHandler insertTicket;
        public event EventHandler InsertTicket
        {
            add { insertTicket += value; }
            remove { insertTicket -= value; }
        }

        private event EventHandler updateTicket;
        public event EventHandler UpdateTicket
        {
            add { updateTicket += value; }
            remove { updateTicket -= value; }
        }

        private event EventHandler deleteTicket;
        public event EventHandler DeleteTicket
        {
            add { deleteTicket += value; }
            remove { deleteTicket -= value; }
        }

        private void btnSearchTicket_Click(object sender, EventArgs e)
        {
            ticketList.DataSource = SearchTicketByName(txbSearchTicketName.Text);
        }

        #endregion

        private void fAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyNhaxeDataSet1.USP_GetListBillByDateForReport' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateForReportTableAdapter.Fill(this.QuanLyNhaxeDataSet1.USP_GetListBillByDateForReport, dtpkFromDate.Value, dtpkToDate.Value);
            // TODO: This line of code loads data into the 'QuanLyNhaxeDataSet.USP_GetCarList' table. You can move, or remove it, as needed.
            this.USP_GetCarListTableAdapter.Fill(this.QuanLyNhaxeDataSet.USP_GetCarList);

            this.reportViewer1.RefreshReport();
        }
    }
}
