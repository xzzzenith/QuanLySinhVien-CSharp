namespace Paint
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusTime = new System.Windows.Forms.ToolStripStatusLabel();

            // ── Panel Đăng nhập ──────────────────────────────────────────
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.lblLoginHeader = new System.Windows.Forms.Label();
            this.lblLoginUser = new System.Windows.Forms.Label();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.lblLoginPass = new System.Windows.Forms.Label();
            this.txtLoginPass = new System.Windows.Forms.TextBox();
            this.btnThucHienDangNhap = new System.Windows.Forms.Button();
            this.btnThoatDangNhap = new System.Windows.Forms.Button();

            // ── TabControl chính ─────────────────────────────────────────
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLop = new System.Windows.Forms.TabPage();
            this.tabHS = new System.Windows.Forms.TabPage();
            this.tabDiem = new System.Windows.Forms.TabPage();

            // === Tab Lớp controls ===
            this.lvLop = new System.Windows.Forms.ListView();
            this.colMaLop = new System.Windows.Forms.ColumnHeader();
            this.colTenLop = new System.Windows.Forms.ColumnHeader();
            this.colSiSo = new System.Windows.Forms.ColumnHeader();
            this.grpLop = new System.Windows.Forms.GroupBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lblSiSo = new System.Windows.Forms.Label();
            this.txtSiSo = new System.Windows.Forms.TextBox();
            this.btnThemLop = new System.Windows.Forms.Button();
            this.btnSuaLop = new System.Windows.Forms.Button();
            this.btnXoaLop = new System.Windows.Forms.Button();

            // === Tab Học sinh controls ===
            this.lblLopHS = new System.Windows.Forms.Label();
            this.cboLopHS = new System.Windows.Forms.ComboBox();
            this.btnTatCaHS = new System.Windows.Forms.Button();
            this.dgvHS = new System.Windows.Forms.DataGridView();
            this.grpHS = new System.Windows.Forms.GroupBox();
            this.lblMaHS = new System.Windows.Forms.Label();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.lblTenHS = new System.Windows.Forms.Label();
            this.txtTenHS = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDTB = new System.Windows.Forms.Label();
            this.txtDTB = new System.Windows.Forms.TextBox();
            this.lblLopChon = new System.Windows.Forms.Label();
            this.cboLopChon = new System.Windows.Forms.ComboBox();
            this.btnThemHS = new System.Windows.Forms.Button();
            this.btnSuaHS = new System.Windows.Forms.Button();
            this.btnXoaHS = new System.Windows.Forms.Button();
            this.btnTimHS = new System.Windows.Forms.Button();

            // === Tab Nhập điểm controls ===
            this.lblLopDiem = new System.Windows.Forms.Label();
            this.cboDiem = new System.Windows.Forms.ComboBox();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.grpDiem = new System.Windows.Forms.GroupBox();
            this.lblMaHSDiem = new System.Windows.Forms.Label();
            this.txtMaHSDiem = new System.Windows.Forms.TextBox();
            this.lblTenHSDiem = new System.Windows.Forms.Label();
            this.txtTenHSDiem = new System.Windows.Forms.TextBox();
            this.lblDiemNhap = new System.Windows.Forms.Label();
            this.txtDiemNhap = new System.Windows.Forms.TextBox();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.txtXepLoai = new System.Windows.Forms.TextBox();
            this.btnLuuDiem = new System.Windows.Forms.Button();

            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLop.SuspendLayout();
            this.tabHS.SuspendLayout();
            this.tabDiem.SuspendLayout();
            this.grpLop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHS)).BeginInit();
            this.grpHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.grpDiem.SuspendLayout();
            this.SuspendLayout();

            // ── menuStrip1 ───────────────────────────────────────────────
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuHeThong });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 28);
            this.menuStrip1.TabIndex = 0;

            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuDangNhap, this.mnuDangXuat, this.mnuSep, this.mnuThoat });
            this.mnuHeThong.Text = "Hệ thống";

            this.mnuDangNhap.Text = "Đăng nhập";
            this.mnuDangNhap.Click += (s, e) => HienThiFormDangNhap();
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Enabled = false;
            this.mnuDangXuat.Click += (s, e) => DangXuat();
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += (s, e) => System.Windows.Forms.Application.Exit();

            // ── statusStrip1 ─────────────────────────────────────────────
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatusUser, this.lblStatusTime });
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(904, 26);
            this.statusStrip1.TabIndex = 2;

            this.lblStatusUser.Spring = true;
            this.lblStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusUser.Text = "  Chưa đăng nhập";

            this.lblStatusTime.Text = "";

            // ── pnlLogin (Giao diện đăng nhập tích hợp sẵn) ─────────────
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlLogin.Controls.Add(this.grpLogin);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 28);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(904, 546);
            this.pnlLogin.TabIndex = 1;

            // grpLogin
            this.grpLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpLogin.BackColor = System.Drawing.Color.White;
            this.grpLogin.Controls.Add(this.lblLoginHeader);
            this.grpLogin.Controls.Add(this.lblLoginUser);
            this.grpLogin.Controls.Add(this.txtLoginUser);
            this.grpLogin.Controls.Add(this.lblLoginPass);
            this.grpLogin.Controls.Add(this.txtLoginPass);
            this.grpLogin.Controls.Add(this.btnThucHienDangNhap);
            this.grpLogin.Controls.Add(this.btnThoatDangNhap);
            this.grpLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpLogin.Location = new System.Drawing.Point(232, 110);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(440, 270);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;

            this.lblLoginHeader.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.lblLoginHeader.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLoginHeader.ForeColor = System.Drawing.Color.FromArgb(24, 76, 120);
            this.lblLoginHeader.Location = new System.Drawing.Point(20, 25);
            this.lblLoginHeader.Size = new System.Drawing.Size(400, 32);
            this.lblLoginHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblLoginUser.Text = "Tên đăng nhập:";
            this.lblLoginUser.Location = new System.Drawing.Point(40, 80);
            this.lblLoginUser.Size = new System.Drawing.Size(120, 25);

            this.txtLoginUser.Location = new System.Drawing.Point(165, 77);
            this.txtLoginUser.Size = new System.Drawing.Size(225, 30);
            this.txtLoginUser.Text = "admin";

            this.lblLoginPass.Text = "Mật khẩu:";
            this.lblLoginPass.Location = new System.Drawing.Point(40, 130);
            this.lblLoginPass.Size = new System.Drawing.Size(120, 25);

            this.txtLoginPass.Location = new System.Drawing.Point(165, 127);
            this.txtLoginPass.Size = new System.Drawing.Size(225, 30);
            this.txtLoginPass.UseSystemPasswordChar = true;
            this.txtLoginPass.Text = "123";
            this.txtLoginPass.KeyDown += (s, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Enter) ThucHienDangNhap(); };

            this.btnThucHienDangNhap.Text = "Đăng nhập";
            this.btnThucHienDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThucHienDangNhap.BackColor = System.Drawing.Color.FromArgb(24, 116, 205);
            this.btnThucHienDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnThucHienDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHienDangNhap.Location = new System.Drawing.Point(110, 190);
            this.btnThucHienDangNhap.Size = new System.Drawing.Size(130, 40);
            this.btnThucHienDangNhap.Click += (s, e) => ThucHienDangNhap();

            this.btnThoatDangNhap.Text = "Thoát";
            this.btnThoatDangNhap.Location = new System.Drawing.Point(260, 190);
            this.btnThoatDangNhap.Size = new System.Drawing.Size(110, 40);
            this.btnThoatDangNhap.Click += (s, e) => System.Windows.Forms.Application.Exit();

            // ── tabControl1 (3 chức năng: Lớp, Học sinh, Điểm) ───────────
            this.tabControl1.Controls.Add(this.tabLop);
            this.tabControl1.Controls.Add(this.tabHS);
            this.tabControl1.Controls.Add(this.tabDiem);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(904, 546);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Visible = false;

            // ════════════════════════════
            //  TAB LỚP
            // ════════════════════════════
            this.tabLop.Text = "  Quản lý Lớp  ";
            this.tabLop.Padding = new System.Windows.Forms.Padding(8);
            this.tabLop.Controls.Add(this.lvLop);
            this.tabLop.Controls.Add(this.grpLop);

            this.lvLop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colMaLop, this.colTenLop, this.colSiSo });
            this.colMaLop.Text = "Mã lớp"; this.colMaLop.Width = 110;
            this.colTenLop.Text = "Tên lớp"; this.colTenLop.Width = 260;
            this.colSiSo.Text = "Sĩ số"; this.colSiSo.Width = 90;
            this.lvLop.FullRowSelect = true;
            this.lvLop.GridLines = true;
            this.lvLop.HideSelection = false;
            this.lvLop.Location = new System.Drawing.Point(10, 10);
            this.lvLop.Size = new System.Drawing.Size(870, 360);
            this.lvLop.View = System.Windows.Forms.View.Details;
            this.lvLop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lvLop.ItemSelectionChanged += (s, e) => { if (e.IsSelected) LvLop_Select(e.Item); };

            this.grpLop.Text = "Thông tin lớp";
            this.grpLop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.grpLop.Location = new System.Drawing.Point(10, 380);
            this.grpLop.Size = new System.Drawing.Size(870, 115);
            this.grpLop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaLop, this.txtMaLop, this.lblTenLop, this.txtTenLop,
                this.lblSiSo, this.txtSiSo, this.btnThemLop, this.btnSuaLop, this.btnXoaLop });

            SetLabelText(this.lblMaLop, "Mã lớp:", 20, 40);
            SetTextBox(this.txtMaLop, 85, 36, 130);
            SetLabelText(this.lblTenLop, "Tên lớp:", 235, 40);
            SetTextBox(this.txtTenLop, 305, 36, 210);
            SetLabelText(this.lblSiSo, "Sĩ số:", 535, 40);
            SetTextBox(this.txtSiSo, 585, 36, 75);
            SetButton(this.btnThemLop, "Thêm", 680, 32, 60, this.btnThemLop_Click);
            SetButton(this.btnSuaLop, "Sửa", 745, 32, 60, this.btnSuaLop_Click);
            SetButton(this.btnXoaLop, "Xóa", 810, 32, 60, this.btnXoaLop_Click);

            // ════════════════════════════
            //  TAB HỌC SINH
            // ════════════════════════════
            this.tabHS.Text = "  Quản lý Học sinh  ";
            this.tabHS.Padding = new System.Windows.Forms.Padding(8);
            this.tabHS.Controls.Add(this.lblLopHS);
            this.tabHS.Controls.Add(this.cboLopHS);
            this.tabHS.Controls.Add(this.btnTatCaHS);
            this.tabHS.Controls.Add(this.dgvHS);
            this.tabHS.Controls.Add(this.grpHS);

            SetLabelText(this.lblLopHS, "Lọc theo lớp:", 10, 16);
            this.cboLopHS.Location = new System.Drawing.Point(110, 11);
            this.cboLopHS.Size = new System.Drawing.Size(180, 29);
            this.cboLopHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopHS.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cboLopHS.SelectedIndexChanged += (s, e) => LoadDSHocSinh();

            this.btnTatCaHS.Text = "Tất cả";
            this.btnTatCaHS.Location = new System.Drawing.Point(300, 10);
            this.btnTatCaHS.Size = new System.Drawing.Size(80, 31);
            this.btnTatCaHS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnTatCaHS.Click += (s, e) => LoadTatCaHS();

            this.dgvHS.Location = new System.Drawing.Point(10, 48);
            this.dgvHS.Size = new System.Drawing.Size(870, 315);
            this.dgvHS.AllowUserToAddRows = false;
            this.dgvHS.AllowUserToDeleteRows = false;
            this.dgvHS.ReadOnly = true;
            this.dgvHS.MultiSelect = false;
            this.dgvHS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHS.BackgroundColor = System.Drawing.Color.White;
            this.dgvHS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvHS.CellClick += (s, e) => DgvHS_CellClick(e.RowIndex);

            this.grpHS.Text = "Thông tin học sinh";
            this.grpHS.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.grpHS.Location = new System.Drawing.Point(10, 375);
            this.grpHS.Size = new System.Drawing.Size(870, 125);
            this.grpHS.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaHS, this.txtMaHS, this.lblTenHS, this.txtTenHS,
                this.lblDiaChi, this.txtDiaChi, this.lblNgaySinh, this.dtpNgaySinh,
                this.lblDTB, this.txtDTB, this.lblLopChon, this.cboLopChon,
                this.btnThemHS, this.btnSuaHS, this.btnXoaHS, this.btnTimHS });

            SetLabelText(this.lblMaHS, "Mã HS:", 12, 32);
            SetTextBox(this.txtMaHS, 72, 28, 100);
            SetLabelText(this.lblTenHS, "Tên HS:", 185, 32);
            SetTextBox(this.txtTenHS, 248, 28, 175);
            SetLabelText(this.lblDiaChi, "Địa chỉ:", 435, 32);
            SetTextBox(this.txtDiaChi, 492, 28, 160);

            SetLabelText(this.lblNgaySinh, "Ngày sinh:", 12, 76);
            this.dtpNgaySinh.Location = new System.Drawing.Point(92, 72);
            this.dtpNgaySinh.Size = new System.Drawing.Size(140, 29);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);

            SetLabelText(this.lblDTB, "Điểm TB:", 245, 76);
            SetTextBox(this.txtDTB, 312, 72, 70);
            SetLabelText(this.lblLopChon, "Lớp:", 395, 76);
            this.cboLopChon.Location = new System.Drawing.Point(435, 72);
            this.cboLopChon.Size = new System.Drawing.Size(140, 29);
            this.cboLopChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);

            SetButton(this.btnThemHS, "Thêm", 665, 26, 60, this.btnThemHS_Click);
            SetButton(this.btnSuaHS, "Sửa", 730, 26, 60, this.btnSuaHS_Click);
            SetButton(this.btnXoaHS, "Xóa", 795, 26, 60, this.btnXoaHS_Click);
            SetButton(this.btnTimHS, "Tìm kiếm", 665, 70, 190, this.btnTimHS_Click);

            // ════════════════════════════
            //  TAB NHẬP ĐIỂM
            // ════════════════════════════
            this.tabDiem.Text = "  Nhập Điểm  ";
            this.tabDiem.Padding = new System.Windows.Forms.Padding(8);
            this.tabDiem.Controls.Add(this.lblLopDiem);
            this.tabDiem.Controls.Add(this.cboDiem);
            this.tabDiem.Controls.Add(this.dgvDiem);
            this.tabDiem.Controls.Add(this.grpDiem);

            SetLabelText(this.lblLopDiem, "Chọn lớp:", 10, 16);
            this.cboDiem.Location = new System.Drawing.Point(95, 11);
            this.cboDiem.Size = new System.Drawing.Size(180, 29);
            this.cboDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cboDiem.SelectedIndexChanged += (s, e) => LoadDSDiem();

            this.dgvDiem.Location = new System.Drawing.Point(10, 48);
            this.dgvDiem.Size = new System.Drawing.Size(870, 335);
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.ReadOnly = true;
            this.dgvDiem.MultiSelect = false;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dgvDiem.CellClick += (s, e) => DgvDiem_CellClick(e.RowIndex);

            this.grpDiem.Text = "Cập nhật điểm";
            this.grpDiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.grpDiem.Location = new System.Drawing.Point(10, 395);
            this.grpDiem.Size = new System.Drawing.Size(870, 100);

            SetLabelText(this.lblMaHSDiem, "Mã HS:", 15, 40);
            SetTextBox(this.txtMaHSDiem, 75, 36, 110);
            this.txtMaHSDiem.ReadOnly = true;

            SetLabelText(this.lblTenHSDiem, "Tên HS:", 200, 40);
            SetTextBox(this.txtTenHSDiem, 265, 36, 190);
            this.txtTenHSDiem.ReadOnly = true;

            SetLabelText(this.lblDiemNhap, "Điểm TB:", 470, 40);
            SetTextBox(this.txtDiemNhap, 545, 36, 80);
            this.txtDiemNhap.TextChanged += (s, e) => CapNhatXepLoai();

            SetLabelText(this.lblXepLoai, "Xếp loại:", 640, 40);
            SetTextBox(this.txtXepLoai, 705, 36, 95);
            this.txtXepLoai.ReadOnly = true;

            SetButton(this.btnLuuDiem, "Lưu điểm", 805, 32, 60, this.btnLuuDiem_Click);

            this.grpDiem.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaHSDiem, this.txtMaHSDiem, this.lblTenHSDiem, this.txtTenHSDiem,
                this.lblDiemNhap, this.txtDiemNhap, this.lblXepLoai, this.txtXepLoai, this.btnLuuDiem });

            // ── frmMain ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 600);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Học sinh (LINQ to SQL)";
            this.Load += (s, e) => frmMain_Load();

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLop.ResumeLayout(false);
            this.tabHS.ResumeLayout(false);
            this.tabDiem.ResumeLayout(false);
            this.grpLop.ResumeLayout(false);
            this.grpLop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHS)).EndInit();
            this.grpHS.ResumeLayout(false);
            this.grpHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.grpDiem.ResumeLayout(false);
            this.grpDiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetLabelText(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
        }

        private void SetTextBox(System.Windows.Forms.TextBox txt, int x, int y, int w)
        {
            txt.Location = new System.Drawing.Point(x, y); txt.Size = new System.Drawing.Size(w, 29);
            txt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
        }

        private void SetButton(System.Windows.Forms.Button btn, string text, int x, int y, int w, System.EventHandler handler)
        {
            btn.Text = text; btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(w, 33);
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            btn.Click += handler;
        }

        // Login Controls
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Label lblLoginHeader, lblLoginUser, lblLoginPass;
        private System.Windows.Forms.TextBox txtLoginUser, txtLoginPass;
        private System.Windows.Forms.Button btnThucHienDangNhap, btnThoatDangNhap;

        // Tab Lớp
        private System.Windows.Forms.ListView lvLop;
        private System.Windows.Forms.ColumnHeader colMaLop, colTenLop, colSiSo;
        private System.Windows.Forms.GroupBox grpLop;
        private System.Windows.Forms.Label lblMaLop, lblTenLop, lblSiSo;
        private System.Windows.Forms.TextBox txtMaLop, txtTenLop, txtSiSo;
        private System.Windows.Forms.Button btnThemLop, btnSuaLop, btnXoaLop;

        // Tab Học sinh
        private System.Windows.Forms.Label lblLopHS, lblMaHS, lblTenHS, lblNgaySinh, lblDiaChi, lblDTB, lblLopChon;
        private System.Windows.Forms.ComboBox cboLopHS, cboLopChon;
        private System.Windows.Forms.Button btnTatCaHS, btnThemHS, btnSuaHS, btnXoaHS, btnTimHS;
        private System.Windows.Forms.DataGridView dgvHS;
        private System.Windows.Forms.GroupBox grpHS;
        private System.Windows.Forms.TextBox txtMaHS, txtTenHS, txtDiaChi, txtDTB;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;

        // Tab Điểm
        private System.Windows.Forms.Label lblLopDiem, lblMaHSDiem, lblTenHSDiem, lblDiemNhap, lblXepLoai;
        private System.Windows.Forms.ComboBox cboDiem;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.GroupBox grpDiem;
        private System.Windows.Forms.TextBox txtMaHSDiem, txtTenHSDiem, txtDiemNhap, txtXepLoai;
        private System.Windows.Forms.Button btnLuuDiem;

        // Menu & Status
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong, mnuDangNhap, mnuDangXuat, mnuThoat;
        private System.Windows.Forms.ToolStripSeparator mnuSep;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUser, lblStatusTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLop, tabHS, tabDiem;
    }
}
