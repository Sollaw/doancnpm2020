namespace QuanLyNhaXe
{
    partial class fAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tpAdmin = new System.Windows.Forms.TabPage();
            this.panel16 = new System.Windows.Forms.Panel();
            this.nmAccountType = new System.Windows.Forms.NumericUpDown();
            this.btnResetPassWord = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnShowAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.panel18 = new System.Windows.Forms.Panel();
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.tpTicket = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txbSearchTicketName = new System.Windows.Forms.TextBox();
            this.btnSearchTicket = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nmTicketPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTicketCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTicketName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTicketID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShowTicket = new System.Windows.Forms.Button();
            this.btnEditTicket = new System.Windows.Forms.Button();
            this.btnDeleteTicket = new System.Windows.Forms.Button();
            this.btnAddTicket = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvTicket = new System.Windows.Forms.DataGridView();
            this.tpBill = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvBill = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpReport = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyNhaxeDataSet = new QuanLyNhaXe.QuanLyNhaxeDataSet();
            this.USP_GetCarListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_GetCarListTableAdapter = new QuanLyNhaXe.QuanLyNhaxeDataSetTableAdapters.USP_GetCarListTableAdapter();
            this.QuanLyNhaxeDataSet1 = new QuanLyNhaXe.QuanLyNhaxeDataSet1();
            this.USP_GetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_GetListBillByDateForReportTableAdapter = new QuanLyNhaXe.QuanLyNhaxeDataSet1TableAdapters.USP_GetListBillByDateForReportTableAdapter();
            this.tpAdmin.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAccountType)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.tpTicket.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTicketPrice)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTicket)).BeginInit();
            this.tpBill.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).BeginInit();
            this.panel4.SuspendLayout();
            this.tcAdmin.SuspendLayout();
            this.tpReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaxeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetCarListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaxeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tpAdmin
            // 
            this.tpAdmin.Controls.Add(this.panel16);
            this.tpAdmin.Controls.Add(this.panel17);
            this.tpAdmin.Controls.Add(this.panel18);
            this.tpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tpAdmin.Name = "tpAdmin";
            this.tpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdmin.Size = new System.Drawing.Size(565, 297);
            this.tpAdmin.TabIndex = 4;
            this.tpAdmin.Text = "Tài khoản";
            this.tpAdmin.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.nmAccountType);
            this.panel16.Controls.Add(this.btnResetPassWord);
            this.panel16.Controls.Add(this.label14);
            this.panel16.Controls.Add(this.label15);
            this.panel16.Controls.Add(this.txbDisplayName);
            this.panel16.Controls.Add(this.label16);
            this.panel16.Controls.Add(this.txbUserName);
            this.panel16.Location = new System.Drawing.Point(336, 60);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(223, 231);
            this.panel16.TabIndex = 9;
            // 
            // nmAccountType
            // 
            this.nmAccountType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nmAccountType.Location = new System.Drawing.Point(122, 96);
            this.nmAccountType.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmAccountType.Name = "nmAccountType";
            this.nmAccountType.Size = new System.Drawing.Size(39, 20);
            this.nmAccountType.TabIndex = 3;
            // 
            // btnResetPassWord
            // 
            this.btnResetPassWord.Location = new System.Drawing.Point(122, 131);
            this.btnResetPassWord.Name = "btnResetPassWord";
            this.btnResetPassWord.Size = new System.Drawing.Size(98, 42);
            this.btnResetPassWord.TabIndex = 4;
            this.btnResetPassWord.Text = "Đặt lại mật khẩu";
            this.btnResetPassWord.UseVisualStyleBackColor = true;
            this.btnResetPassWord.Click += new System.EventHandler(this.btnResetPassWord_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 19);
            this.label14.TabIndex = 10;
            this.label14.Text = "Loại tài khoản";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(0, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 19);
            this.label15.TabIndex = 9;
            this.label15.Text = "Tên hiển thị";
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Location = new System.Drawing.Point(4, 71);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Size = new System.Drawing.Size(216, 20);
            this.txbDisplayName.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(0, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = "Tên tài khoản";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(4, 26);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(216, 20);
            this.txbUserName.TabIndex = 1;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.btnShowAccount);
            this.panel17.Controls.Add(this.btnEditAccount);
            this.panel17.Controls.Add(this.btnDeleteAccount);
            this.panel17.Controls.Add(this.btnAddAccount);
            this.panel17.Location = new System.Drawing.Point(6, 6);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(324, 48);
            this.panel17.TabIndex = 8;
            // 
            // btnShowAccount
            // 
            this.btnShowAccount.Location = new System.Drawing.Point(246, 3);
            this.btnShowAccount.Name = "btnShowAccount";
            this.btnShowAccount.Size = new System.Drawing.Size(75, 42);
            this.btnShowAccount.TabIndex = 5;
            this.btnShowAccount.Text = "Xem";
            this.btnShowAccount.UseVisualStyleBackColor = true;
            this.btnShowAccount.Click += new System.EventHandler(this.btnShowAccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(165, 3);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(75, 42);
            this.btnEditAccount.TabIndex = 4;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(84, 3);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(75, 42);
            this.btnDeleteAccount.TabIndex = 3;
            this.btnDeleteAccount.Text = "Xóa";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(3, 3);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 42);
            this.btnAddAccount.TabIndex = 2;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.dtgvAccount);
            this.panel18.Location = new System.Drawing.Point(6, 60);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(324, 231);
            this.panel18.TabIndex = 7;
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Location = new System.Drawing.Point(4, 4);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.Size = new System.Drawing.Size(317, 224);
            this.dtgvAccount.TabIndex = 0;
            // 
            // tpTicket
            // 
            this.tpTicket.Controls.Add(this.panel6);
            this.tpTicket.Controls.Add(this.panel5);
            this.tpTicket.Controls.Add(this.panel3);
            this.tpTicket.Controls.Add(this.panel2);
            this.tpTicket.Location = new System.Drawing.Point(4, 22);
            this.tpTicket.Name = "tpTicket";
            this.tpTicket.Padding = new System.Windows.Forms.Padding(3);
            this.tpTicket.Size = new System.Drawing.Size(565, 297);
            this.tpTicket.TabIndex = 1;
            this.tpTicket.Text = "Vé";
            this.tpTicket.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txbSearchTicketName);
            this.panel6.Controls.Add(this.btnSearchTicket);
            this.panel6.Location = new System.Drawing.Point(336, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(223, 48);
            this.panel6.TabIndex = 6;
            // 
            // txbSearchTicketName
            // 
            this.txbSearchTicketName.Location = new System.Drawing.Point(4, 15);
            this.txbSearchTicketName.Name = "txbSearchTicketName";
            this.txbSearchTicketName.Size = new System.Drawing.Size(135, 20);
            this.txbSearchTicketName.TabIndex = 7;
            // 
            // btnSearchTicket
            // 
            this.btnSearchTicket.Location = new System.Drawing.Point(145, 3);
            this.btnSearchTicket.Name = "btnSearchTicket";
            this.btnSearchTicket.Size = new System.Drawing.Size(75, 42);
            this.btnSearchTicket.TabIndex = 6;
            this.btnSearchTicket.Text = "Tìm";
            this.btnSearchTicket.UseVisualStyleBackColor = true;
            this.btnSearchTicket.Click += new System.EventHandler(this.btnSearchTicket_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nmTicketPrice);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.cbTicketCategory);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txbTicketName);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txbTicketID);
            this.panel5.Location = new System.Drawing.Point(336, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(223, 231);
            this.panel5.TabIndex = 5;
            // 
            // nmTicketPrice
            // 
            this.nmTicketPrice.Location = new System.Drawing.Point(4, 163);
            this.nmTicketPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmTicketPrice.Name = "nmTicketPrice";
            this.nmTicketPrice.Size = new System.Drawing.Size(216, 20);
            this.nmTicketPrice.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Giá";
            // 
            // cbTicketCategory
            // 
            this.cbTicketCategory.FormattingEnabled = true;
            this.cbTicketCategory.Location = new System.Drawing.Point(4, 117);
            this.cbTicketCategory.Name = "cbTicketCategory";
            this.cbTicketCategory.Size = new System.Drawing.Size(216, 21);
            this.cbTicketCategory.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên vé";
            // 
            // txbTicketName
            // 
            this.txbTicketName.Location = new System.Drawing.Point(4, 71);
            this.txbTicketName.Name = "txbTicketName";
            this.txbTicketName.Size = new System.Drawing.Size(216, 20);
            this.txbTicketName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txbTicketID
            // 
            this.txbTicketID.Location = new System.Drawing.Point(4, 26);
            this.txbTicketID.Name = "txbTicketID";
            this.txbTicketID.ReadOnly = true;
            this.txbTicketID.Size = new System.Drawing.Size(216, 20);
            this.txbTicketID.TabIndex = 1;
            this.txbTicketID.TextChanged += new System.EventHandler(this.txbTicketID_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnShowTicket);
            this.panel3.Controls.Add(this.btnEditTicket);
            this.panel3.Controls.Add(this.btnDeleteTicket);
            this.panel3.Controls.Add(this.btnAddTicket);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 48);
            this.panel3.TabIndex = 4;
            // 
            // btnShowTicket
            // 
            this.btnShowTicket.Location = new System.Drawing.Point(246, 3);
            this.btnShowTicket.Name = "btnShowTicket";
            this.btnShowTicket.Size = new System.Drawing.Size(75, 42);
            this.btnShowTicket.TabIndex = 5;
            this.btnShowTicket.Text = "Xem";
            this.btnShowTicket.UseVisualStyleBackColor = true;
            this.btnShowTicket.Click += new System.EventHandler(this.btnShowTicket_Click);
            // 
            // btnEditTicket
            // 
            this.btnEditTicket.Location = new System.Drawing.Point(165, 3);
            this.btnEditTicket.Name = "btnEditTicket";
            this.btnEditTicket.Size = new System.Drawing.Size(75, 42);
            this.btnEditTicket.TabIndex = 4;
            this.btnEditTicket.Text = "Sửa";
            this.btnEditTicket.UseVisualStyleBackColor = true;
            this.btnEditTicket.Click += new System.EventHandler(this.btnEditTicket_Click);
            // 
            // btnDeleteTicket
            // 
            this.btnDeleteTicket.Location = new System.Drawing.Point(84, 3);
            this.btnDeleteTicket.Name = "btnDeleteTicket";
            this.btnDeleteTicket.Size = new System.Drawing.Size(75, 42);
            this.btnDeleteTicket.TabIndex = 3;
            this.btnDeleteTicket.Text = "Xóa";
            this.btnDeleteTicket.UseVisualStyleBackColor = true;
            this.btnDeleteTicket.Click += new System.EventHandler(this.btnDeleteTicket_Click);
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Location = new System.Drawing.Point(3, 3);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Size = new System.Drawing.Size(75, 42);
            this.btnAddTicket.TabIndex = 2;
            this.btnAddTicket.Text = "Thêm";
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvTicket);
            this.panel2.Location = new System.Drawing.Point(6, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 231);
            this.panel2.TabIndex = 0;
            // 
            // dtgvTicket
            // 
            this.dtgvTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTicket.Location = new System.Drawing.Point(4, 4);
            this.dtgvTicket.Name = "dtgvTicket";
            this.dtgvTicket.Size = new System.Drawing.Size(317, 224);
            this.dtgvTicket.TabIndex = 0;
            // 
            // tpBill
            // 
            this.tpBill.Controls.Add(this.panel1);
            this.tpBill.Controls.Add(this.panel4);
            this.tpBill.Location = new System.Drawing.Point(4, 22);
            this.tpBill.Name = "tpBill";
            this.tpBill.Padding = new System.Windows.Forms.Padding(3);
            this.tpBill.Size = new System.Drawing.Size(565, 297);
            this.tpBill.TabIndex = 0;
            this.tpBill.Text = "Doanh thu";
            this.tpBill.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvBill);
            this.panel1.Location = new System.Drawing.Point(6, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 253);
            this.panel1.TabIndex = 5;
            // 
            // dtgvBill
            // 
            this.dtgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBill.Location = new System.Drawing.Point(3, 3);
            this.dtgvBill.Name = "dtgvBill";
            this.dtgvBill.Size = new System.Drawing.Size(547, 247);
            this.dtgvBill.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtpkToDate);
            this.panel4.Controls.Add(this.dtpkFromDate);
            this.panel4.Controls.Add(this.btnViewBill);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(553, 26);
            this.panel4.TabIndex = 4;
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkToDate.Location = new System.Drawing.Point(350, 3);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkToDate.TabIndex = 4;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFromDate.Location = new System.Drawing.Point(3, 3);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpkFromDate.TabIndex = 3;
            // 
            // btnViewBill
            // 
            this.btnViewBill.Location = new System.Drawing.Point(238, 3);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(75, 20);
            this.btnViewBill.TabIndex = 2;
            this.btnViewBill.Text = "Thống kê";
            this.btnViewBill.UseVisualStyleBackColor = true;
            this.btnViewBill.Click += new System.EventHandler(this.btnViewBill_Click);
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpBill);
            this.tcAdmin.Controls.Add(this.tpTicket);
            this.tcAdmin.Controls.Add(this.tpAdmin);
            this.tcAdmin.Controls.Add(this.tpReport);
            this.tcAdmin.Location = new System.Drawing.Point(13, 13);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(573, 323);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpReport
            // 
            this.tpReport.Controls.Add(this.reportViewer1);
            this.tpReport.Location = new System.Drawing.Point(4, 22);
            this.tpReport.Name = "tpReport";
            this.tpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpReport.Size = new System.Drawing.Size(565, 297);
            this.tpReport.TabIndex = 5;
            this.tpReport.Text = "Report";
            this.tpReport.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_GetListBillByDateForReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhaXe.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(559, 291);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // QuanLyNhaxeDataSet
            // 
            this.QuanLyNhaxeDataSet.DataSetName = "QuanLyNhaxeDataSet";
            this.QuanLyNhaxeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetCarListBindingSource
            // 
            this.USP_GetCarListBindingSource.DataMember = "USP_GetCarList";
            this.USP_GetCarListBindingSource.DataSource = this.QuanLyNhaxeDataSet;
            // 
            // USP_GetCarListTableAdapter
            // 
            this.USP_GetCarListTableAdapter.ClearBeforeFill = true;
            // 
            // QuanLyNhaxeDataSet1
            // 
            this.QuanLyNhaxeDataSet1.DataSetName = "QuanLyNhaxeDataSet1";
            this.QuanLyNhaxeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetListBillByDateForReportBindingSource
            // 
            this.USP_GetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.USP_GetListBillByDateForReportBindingSource.DataSource = this.QuanLyNhaxeDataSet1;
            // 
            // USP_GetListBillByDateForReportTableAdapter
            // 
            this.USP_GetListBillByDateForReportTableAdapter.ClearBeforeFill = true;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 348);
            this.Controls.Add(this.tcAdmin);
            this.Name = "fAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.fAdmin_Load);
            this.tpAdmin.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmAccountType)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.tpTicket.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTicketPrice)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTicket)).EndInit();
            this.tpBill.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBill)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tcAdmin.ResumeLayout(false);
            this.tpReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaxeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetCarListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaxeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tpAdmin;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.NumericUpDown nmAccountType;
        private System.Windows.Forms.Button btnResetPassWord;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbDisplayName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button btnShowAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.TabPage tpTicket;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txbSearchTicketName;
        private System.Windows.Forms.Button btnSearchTicket;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nmTicketPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTicketCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTicketName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTicketID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnShowTicket;
        private System.Windows.Forms.Button btnEditTicket;
        private System.Windows.Forms.Button btnDeleteTicket;
        private System.Windows.Forms.Button btnAddTicket;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvTicket;
        private System.Windows.Forms.TabPage tpBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetCarListBindingSource;
        private QuanLyNhaxeDataSet QuanLyNhaxeDataSet;
        private QuanLyNhaxeDataSetTableAdapters.USP_GetCarListTableAdapter USP_GetCarListTableAdapter;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateForReportBindingSource;
        private QuanLyNhaxeDataSet1 QuanLyNhaxeDataSet1;
        private QuanLyNhaxeDataSet1TableAdapters.USP_GetListBillByDateForReportTableAdapter USP_GetListBillByDateForReportTableAdapter;
    }
}